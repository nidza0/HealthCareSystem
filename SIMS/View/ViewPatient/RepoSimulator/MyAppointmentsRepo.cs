using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIMS.Util;
using SIMS.Model.PatientModel;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;

namespace SIMS.View.ViewPatient.RepoSimulator
{
    public class MyAppointmentsRepo
    {

        private static MyAppointmentsRepo instance = null;
        private DoctorAppointmentsRepo doctorAppointmentsRepo = DoctorAppointmentsRepo.Instance;
        private UserRepo userRepo = UserRepo.Instance;


        public static MyAppointmentsRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyAppointmentsRepo();
                }
                return instance;
            }
        }

        private MyAppointmentsRepo()
        {
            fillAppointmentsList();
        }

        private List<Appointment> myAppointments;

  

        public List<Appointment> MyAppointments { get => myAppointments; set => myAppointments = value; }


        //update appointment
        public void updateAppointment(Appointment appointment)
        {
            //todo : find appointment with taht id


            //edit it 

            Appointment ourAppointment = null;

            foreach(Appointment app in myAppointments)
            {
                if(app.GetId() == appointment.GetId())
                {
                    ourAppointment = app;
                    break;
                }
            }


            if(ourAppointment != null)
            {
                //if papointment found
                ourAppointment.DoctorInAppointment = appointment.DoctorInAppointment;
                ourAppointment.AppointmentType = appointment.AppointmentType;
                ourAppointment.Canceled = appointment.Canceled;
                ourAppointment.Patient = appointment.Patient;
                ourAppointment.Room = appointment.Room;
                ourAppointment.TimeInterval = appointment.TimeInterval;
            }
        }

        public void cancelAppointment(Appointment appointment)
        {
            Appointment ourAppointment = null;

            foreach (Appointment app in myAppointments)
            {
                if (app.GetId() == appointment.GetId())
                {
                    ourAppointment = app;
                    break;
                }
            }

            if(ourAppointment != null)
            {
                myAppointments.Remove(ourAppointment);
            }
        }

        private void fillAppointmentsList()
        {
            myAppointments = new List<Appointment>();

            TimeInterval timeInterval = new TimeInterval(new DateTime(2020, 10, 6, 8, 0, 0), new DateTime(2020, 10, 6, 16, 0, 0));
            Dictionary<WorkingDaysEnum, TimeInterval> dict = new Dictionary<WorkingDaysEnum, TimeInterval>();
            dict.Add(WorkingDaysEnum.MONDAY, timeInterval);
            dict.Add(WorkingDaysEnum.TUESDAY, timeInterval);
            dict.Add(WorkingDaysEnum.WEDNESDAY, timeInterval);
            dict.Add(WorkingDaysEnum.THURSDAY, timeInterval);
            dict.Add(WorkingDaysEnum.FRIDAY, timeInterval);
            dict.Add(WorkingDaysEnum.SATURDAY, timeInterval);
            dict.Add(WorkingDaysEnum.SUNDAY, timeInterval);
            TimeTable timeTable = new TimeTable(dict);
            List<Doctor> doctorList = userRepo.DoctorList;
            Doctor doctor = doctorList.ElementAt(0);
            Doctor doctor1 = doctorList.ElementAt(1);
            Doctor doctor2 = doctorList.ElementAt(2);
            Doctor doctor3 = doctorList.ElementAt(3);
            Doctor doctor4 = doctorList.ElementAt(4);
            Doctor doctor5 = doctorList.ElementAt(5);
            //Doctor doctor = new Doctor(new UserID("d123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Bulevar Oslobodjenja 69", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B123", false, 5, RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            //Doctor doctor1 = new Doctor(new UserID("d1266"), "pera", "pera123", DateTime.Now, "Nikola", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-367", "zzzz"), new Room("B124", false, 5, RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            //Doctor doctor2 = new Doctor(new UserID("d1267"), "pera", "pera123", DateTime.Now, "Veljko", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-321321", "zzzz"), new Room("B125", false, 5, RoomType.EXAMINATION), DocTypeEnum.INFECTOLOGIST);
            //Doctor doctor3 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Petkovic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-6666666", "zzzz"), new Room("B126", false, 5, RoomType.EXAMINATION), DocTypeEnum.INFECTOLOGIST);
            //Doctor doctor4 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Peric", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-TEST-123", "zzzz"), new Room("B127", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);
            //Doctor doctor5 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Zeljic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-TEST2-132", "zzzz"), new Room("B128", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);
            //Doctor doctor6 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Kupusarevic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B129", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);
            
            Appointment appointment = new Appointment(1,doctor1, HomePage.loggedPatient, doctor1.Office, AppointmentType.checkup, timeInterval);
            DateTime temp = timeInterval.StartTime.AddMinutes(20);
            DateTime tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment1 = new Appointment(2,doctor2, HomePage.loggedPatient, doctor2.Office, AppointmentType.operation, timeInterval);
            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);

            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);


            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment2 = new Appointment(3,doctor3, HomePage.loggedPatient, doctor3.Office, AppointmentType.operation, timeInterval);
            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment3 = new Appointment(4,doctor4, HomePage.loggedPatient, doctor4.Office, AppointmentType.checkup, timeInterval);
            timeInterval = new TimeInterval(new DateTime(2020, 6, 15, 8, 0, 0), new DateTime(2020, 6, 15, 16, 0, 0));
            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);

            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);

            //Appointment appointment4 = new Appointment(5,doctor6, HomePage.loggedPatient, doctor5.Office, AppointmentType.checkup, timeInterval);
            //temp = timeInterval.StartTime.AddMinutes(20);
            //tempEnd = temp.AddMinutes(20);
            //timeInterval = new TimeInterval(temp, tempEnd);
            //Appointment appointment5 = new Appointment(6,doctor6, HomePage.loggedPatient, doctor5.Office, AppointmentType.checkup, timeInterval);


            List<Appointment> patientAppointments = new List<Appointment>();

           myAppointments.Add(appointment);
            doctorAppointmentsRepo.takeAnAppointment(appointment);
           myAppointments.Add(appointment1);
           myAppointments.Add(appointment2);
           myAppointments.Add(appointment3);
            doctorAppointmentsRepo.takeAnAppointment(appointment1);
            doctorAppointmentsRepo.takeAnAppointment(appointment2);
            doctorAppointmentsRepo.takeAnAppointment(appointment3);
            //myAppointments.Add(appointment4);
            // myAppointments.Add(appointment5);



        }




        
    }

}
