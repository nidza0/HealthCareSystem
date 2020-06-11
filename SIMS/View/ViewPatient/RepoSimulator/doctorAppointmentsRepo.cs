using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SIMS.Model.UserModel;
using SIMS.Model.DoctorModel;
using SIMS.Model.PatientModel;
using SIMS.Util;

namespace SIMS.View.ViewPatient.RepoSimulator
{
    class DoctorAppointmentsRepo
    {
        private static DoctorAppointmentsRepo instance = null;

        private UserRepo userRepo;

        private Dictionary<Doctor, List<Appointment>> takenAppointments;

        public static DoctorAppointmentsRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DoctorAppointmentsRepo();
                }
                return instance;
            }
        }

        public List<Appointment> getDoctorAppointments(Doctor doc)
        {
           

            return takenAppointments[doc];
        }
       

        private DoctorAppointmentsRepo()
        {
            userRepo = UserRepo.Instance;
            takenAppointments = new Dictionary<Doctor, List<Appointment>>();
            List<Doctor> allDoctors = userRepo.DoctorList.ToList();
            foreach(Doctor doctor in allDoctors)
            {
                takenAppointments.Add(doctor, new List<Appointment>());

            }
        }

        public void cancelAnAppointment(Appointment appointment)
        {
            Doctor doctor = appointment.DoctorInAppointment;

            if(doctor != null)
            {
                List<Appointment> appointmentList;
                try
                {
                    appointmentList = takenAppointments[doctor];
                }catch(Exception e)
                {
                    return;
                }
                Appointment toRemove = null;
                foreach (Appointment currAppointment in appointmentList)
                {
                    if (currAppointment.TimeInterval.StartTime.Equals(appointment.TimeInterval.StartTime))
                    {
                        toRemove = currAppointment;
                        break;
                    }
                }

                if(toRemove != null)
                    appointmentList.Remove(toRemove);
            }


        }

        public void takeAnAppointment(Appointment appointment)
        {
            Doctor doc = appointment.DoctorInAppointment;
            List<Appointment> appList = takenAppointments[doc];

            Console.WriteLine(appList.Count);

            appList.Add(appointment);
        } 

        public List<Appointment> GetTakenAppointments(Doctor doctor)
        {
            List<Appointment> retVal = takenAppointments[doctor];

            return retVal == null ? new List<Appointment>() : retVal;
        }



        private TimeInterval GetDoctorTimeIntervalForDate(Doctor doctor,DateTime date)
        {
            TimeTable doctorTimeTable = doctor.TimeTable;
            DayOfWeek dayOfWeek = date.DayOfWeek;
            WorkingDaysEnum workingDaysEnum = (WorkingDaysEnum)dayOfWeek;

            TimeInterval retVal = null;
            try
            {
                Dictionary<WorkingDaysEnum, TimeInterval> workingHour = doctorTimeTable.WorkingHours;
                retVal = workingHour[workingDaysEnum];
            }
            catch (Exception e)
            {

            }

            return retVal;
        }



        private void generateAppointmentSlots(Doctor doctor)
        {
            //Kreiramo prazne appointment slots.
            TimeInterval timeInterval = GetDoctorTimeIntervalForDate(doctor,DateTime.Now.Date.AddDays(1));

            //simulacija dodavanja nekih zauzetih termina od strane nepoznatih pacijemnata ali to nije bitno za moj deo hci-a

            if (timeInterval != null)
            {
                //Ako tad radi doktor
                DateTime currTime = timeInterval.StartTime;
                DateTime moveTime = currTime.AddMinutes(20);
                DateTime endTime = timeInterval.EndTime;

                if (!takenAppointments.ContainsKey(doctor))
                {
                    takenAppointments.Add(doctor, new List<Appointment>());
                }

                List<Appointment> appointments = takenAppointments[doctor];
                Random randomizer = new Random();
                while (moveTime <= endTime)
                {
                    int randNum = randomizer.Next(2, 30);
                    TimeInterval appointmentTimeInterval = new TimeInterval(currTime, moveTime);
                    if(randNum == 5)
                    {
                        //zauzimamo termin 
                        appointments.Add(new Appointment(doctor, new Patient(new UserID("P1234")), doctor.Office, AppointmentType.checkup, appointmentTimeInterval));
                    }
             

                    currTime = currTime.AddMinutes(20);
                    moveTime = moveTime.AddMinutes(20);
                }
            }


        }
    }
}
