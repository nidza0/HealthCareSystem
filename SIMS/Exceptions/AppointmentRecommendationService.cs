using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.MedicalService
{
    class AppointmentRecommendationService
    {
        private AppointmentService _appointmentService;
        private int _duration = 15;
        private int _n = 1;

        public AppointmentRecommendationService(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IEnumerable<Appointment> GetRecommendedAppointments(Doctor doctor, TimeInterval time)
        {
            List<RecommendationDTO> takenAppointments = GetTakenAppointmentsInfo(doctor, time);

            List<Appointment> freeAppointments = GetFreeAppointments(time, takenAppointments);

            if (freeAppointments.Count >= _n)
            {
                return freeAppointments;
            }



            return null;
        }

        private List<Appointment> GetFreeAppointments(TimeInterval time, List<RecommendationDTO> takenAppointments)
        {
            List<Appointment> freeAppointments = new List<Appointment>();

            for (int k = 0; k < takenAppointments.Count; k++)
            {
                TimeInterval shift = takenAppointments[k].DoctorShift;

                // if doctor's shift is later than specified start of interval, use doctor's shift
                DateTime start1 = shift.StartTime > time.StartTime ? shift.StartTime : time.StartTime;
                DateTime start2 = start1.AddMinutes(_duration);

                // if doctor's shift is earlier than specified end of time interval, use doctor's shift
                DateTime end = shift.EndTime < time.EndTime ? shift.EndTime : time.EndTime;

                // iterate through every day
                for (int i = 0; i < takenAppointments[k].TakenAppointments.Count(); i++)
                {
                    Appointment takenAp = takenAppointments[k].TakenAppointments[i];
                    while (!takenAp.TimeInterval.IsOverlappingWith(new TimeInterval(start1, start2)))
                        AddFreeAppointment(freeAppointments, ref start1, ref start2);

                    // skip taken appointment
                    start1 = takenAp.TimeInterval.EndTime;
                    start2 = start1.AddMinutes(_duration);

                    // if taken appointment is the last one for given day, fill the rest of the time with free appointments
                    if (i == takenAppointments[k].TakenAppointments.Count() - 1) //last one
                    {
                        while (start2 <= end)
                            AddFreeAppointment(freeAppointments, ref start1, ref start2);
                    }
                }

                // if no taken appointments exist for given day, fill the list with free appointments for that day
                if (takenAppointments[k].TakenAppointments.Count() == 0)
                {
                    while (start2 <= end)
                        AddFreeAppointment(freeAppointments, ref start1, ref start2);
                }
            }

            return freeAppointments;
        }

        private void AddFreeAppointment(List<Appointment> freeAppointments, ref DateTime start1, ref DateTime start2)
        {
            freeAppointments.Add(new Appointment(null, null, null, AppointmentType.checkup, new TimeInterval(start1, start2)));
            start1 = start2;
            start2 = start1.AddMinutes(_duration);
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
