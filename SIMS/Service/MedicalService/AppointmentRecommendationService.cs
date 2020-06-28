using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Service.UsersService;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.MedicalService
{
    public class AppointmentRecommendationService
    {
        private AppointmentService _appointmentService;
        private DoctorService _doctorService;
        private int _duration = 15;
        private int _minimumAppointments = 1;
        private int _extensionDays = 5;

        public AppointmentRecommendationService(AppointmentService appointmentService, DoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _doctorService = doctorService;
        }

        public List<Appointment> GetRecommendedAppointments(AppointmentRecommendationDTO recommendationDTO)
        {
            List<Appointment> freeAppointments = GetRecommendedAppointmentsCandidates(recommendationDTO.Doctor, recommendationDTO.TimeInterval);

            if (freeAppointments.Count >= _minimumAppointments)
                return freeAppointments;
            else
            {
                List<Appointment> freeAppointmentsByPriority = GetRecommendedAppointmentsByPriority(recommendationDTO);
                return MergeAppointments(freeAppointments, freeAppointmentsByPriority);
            }
        }

        private List<Appointment> MergeAppointments(List<Appointment> freeAppointments, List<Appointment> freeAppointmentsByPriority)
        {
            List<Appointment> mergedAppointments = new List<Appointment>(freeAppointments);

            mergedAppointments.AddRange(freeAppointmentsByPriority.Where(ap => !ContainsAppointment(ap, freeAppointments)));

            return mergedAppointments;
        }

        private bool ContainsAppointment(Appointment appointment, List<Appointment> freeAppointments)
        {
            return freeAppointments.Where(ap => CheckAppointmentEquality(ap, appointment)).Count() > 0;
        }

        private bool CheckAppointmentEquality(Appointment appointmentPriority, Appointment freeAppointment)
        {
            return appointmentPriority.TimeInterval.StartTime == freeAppointment.TimeInterval.StartTime && appointmentPriority.DoctorInAppointment.Equals(freeAppointment.DoctorInAppointment);
        }

        private List<Appointment> GetRecommendedAppointmentsCandidates(Doctor doctor, TimeInterval timeInterval)
        {
            List<RecommendationDTO> takenAppointments = GetTakenAppointmentsInfo(doctor, timeInterval);
            List<Appointment> freeAppointments = GetFreeAppointments(timeInterval, takenAppointments);
            return freeAppointments;
        }

        private List<Appointment> GetRecommendedAppointmentsByPriority(AppointmentRecommendationDTO recommendationDTO)
        {
            if (recommendationDTO.Priority == RecommendationPriority.DOCTOR)
                return GetRecommendedAppointmentsByDoctorPriority(recommendationDTO);
            else
                return GetRecommendedAppointmentsByTimeIntervalPriority(recommendationDTO);
        }

        private List<Appointment> GetRecommendedAppointmentsByTimeIntervalPriority(AppointmentRecommendationDTO recommendationDTO)
        {
            List<Doctor> doctors = _doctorService.GetDoctorByType(recommendationDTO.Doctor.DoctorType).ToList();
            List<Appointment> recommendedCandidates = new List<Appointment>();

            foreach(Doctor doctor in doctors)
            {
                List<Appointment> doctorsFreeAppointments = GetRecommendedAppointmentsCandidates(doctor, recommendationDTO.TimeInterval);
                recommendedCandidates.AddRange(doctorsFreeAppointments);
            }

            return recommendedCandidates;
        }

        private List<Appointment> GetRecommendedAppointmentsByDoctorPriority(AppointmentRecommendationDTO recommendationDTO)
        {
            TimeInterval time = recommendationDTO.TimeInterval;
            time.EndTime = time.EndTime.AddDays(_extensionDays);
            return GetRecommendedAppointmentsCandidates(recommendationDTO.Doctor, recommendationDTO.TimeInterval);
        }

        private List<Appointment> GetFreeAppointments(TimeInterval time, List<RecommendationDTO> takenAppointments)
        {
            List<Appointment> freeAppointments = new List<Appointment>();

            for (int k = 0; k < takenAppointments.Count; k++)
            {
                var freeAppointmentsDay = GetFreeAppointmentsForDay(time, takenAppointments[k]);
                freeAppointments.AddRange(freeAppointmentsDay);
            }

            return freeAppointments;
        }

        private List<Appointment> GetFreeAppointmentsForDay(TimeInterval time, RecommendationDTO appointmentsDay)
        {
            List<Appointment> freeAppointments = new List<Appointment>();
            List<Appointment> takenAppointments = appointmentsDay.TakenAppointments;

            TimeIterator timeIterator = GetTimeIterator(time, appointmentsDay.DoctorShift);

            // iterate through every taken appointment
            for (int i = 0; i < takenAppointments.Count(); i++)
            {
                Appointment takenAp = takenAppointments[i];
                FillFreeAppointmentsUntilTaken(freeAppointments, timeIterator, takenAp);

                // skip taken appointment
                timeIterator.SkipInterval(takenAp.TimeInterval);

                // if taken appointment is the last one for given day, fill the rest of the time with free appointments
                if (i == takenAppointments.Count() - 1) //last one
                    FillFreeAppointmentsRestOfTheDay(freeAppointments, timeIterator);
            }

            // if no taken appointments exist for given day, fill the list with free appointments for that day
            if (takenAppointments.Count() == 0)
                FillFreeAppointmentsRestOfTheDay(freeAppointments, timeIterator);

            return freeAppointments;
        }

        private void FillFreeAppointmentsRestOfTheDay(List<Appointment> freeAppointments, TimeIterator timeIterator)
        {
            while (timeIterator.HasNext())
            {
                AddFreeAppointment(freeAppointments, timeIterator);
                timeIterator.Next();
            }
        }

        private void FillFreeAppointmentsUntilTaken(List<Appointment> freeAppointments, TimeIterator timeIterator, Appointment takenAp)
        {
            while (!takenAp.TimeInterval.IsOverlappingWith(timeIterator.GetCurrentTimeFrame()))
            {
                AddFreeAppointment(freeAppointments, timeIterator);
                timeIterator.Next();
            }
        }

        private TimeIterator GetTimeIterator(TimeInterval time, TimeInterval shift)
        {
            // if doctor's shift is later than specified start of interval, use doctor's shift
            DateTime start = shift.StartTime > time.StartTime ? shift.StartTime : time.StartTime;
            // if doctor's shift is earlier than specified end of time interval, use doctor's shift
            DateTime end = shift.EndTime < time.EndTime ? shift.EndTime : time.EndTime;

            return new TimeIterator(_duration, new TimeInterval(start, end));
        }

        private void AddFreeAppointment(List<Appointment> freeAppointments, TimeIterator timeIt)
        {
            freeAppointments.Add(new Appointment(null, null, null, AppointmentType.checkup, timeIt.GetCurrentTimeFrame()));
        }

        private List<RecommendationDTO> GetTakenAppointmentsInfo(Doctor doctor, TimeInterval time)
        {
            List<Appointment> allTakenAppointments = GetAllTakenAppointments(doctor, time);

            List<RecommendationDTO> takenAppointments = new List<RecommendationDTO>();

            DateTime startTime = time.StartTime;

            while (startTime <= time.EndTime)
            {
                // splitting parameter 'time' by days
                TimeInterval shift = GetDoctorShift(doctor, startTime);
                startTime.AddDays(1);
                if (shift == null)
                    continue;
                takenAppointments.Add(new RecommendationDTO(shift, allTakenAppointments.Where(ap => shift.IsDateTimeBetween(ap.TimeInterval)).ToList()));
            }

            return takenAppointments;
        }

        private TimeInterval GetRealShift(DateTime startTime, TimeInterval shift)
        {
            // setting real shift date for starttime day

            DateTime startDate = new DateTime(startTime.Year, startTime.Month, startTime.Day, shift.StartTime.Hour, shift.StartTime.Minute, shift.StartTime.Second);
            DateTime endDate = new DateTime(startTime.Year, startTime.Month, startTime.Day, shift.EndTime.Hour, shift.EndTime.Minute, shift.EndTime.Second);
            return new TimeInterval(startDate, endDate);
        }

        private TimeInterval GetDoctorShift(Doctor doctor, DateTime date)
        {
            WorkingDaysEnum day = GetDayOfWeek(date.DayOfWeek);
            TimeInterval shift = null;

            doctor.TimeTable.getWorkingHours().TryGetValue(day, out shift);

            return shift == null ? null : GetRealShift(date, shift);
        }

        private List<Appointment> GetAllTakenAppointments(Doctor doctor, TimeInterval time)
            => _appointmentService.GetAppointmentsByTime(time).Where(ap => !ap.Canceled && ap.DoctorInAppointment.Equals(doctor)).OrderBy(ap => ap.TimeInterval.StartTime).ToList();

        private WorkingDaysEnum GetDayOfWeek(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return WorkingDaysEnum.MONDAY;
                case DayOfWeek.Tuesday:
                    return WorkingDaysEnum.TUESDAY;
                case DayOfWeek.Wednesday:
                    return WorkingDaysEnum.WEDNESDAY;
                case DayOfWeek.Thursday:
                    return WorkingDaysEnum.THURSDAY;
                case DayOfWeek.Friday:
                    return WorkingDaysEnum.FRIDAY;
                case DayOfWeek.Saturday:
                    return WorkingDaysEnum.SATURDAY;
                default:
                    return WorkingDaysEnum.SUNDAY;
            };
        }
    }
}
