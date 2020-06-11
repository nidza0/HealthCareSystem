using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIMS.Model.UserModel;
using SIMS.Model.DoctorModel;
using SIMS.Util;
using SIMS.View.ViewPatient.Exceptions;
using SIMS.Repository.CSVFileRepository.UsersRepository;

namespace SIMS.View.ViewPatient.RepoSimulator
{
    class UserRepo
    {

        private static UserRepo instance = null;

        private UserID[] availableIDS = { new UserID("P004"), new UserID("P005"), new UserID("P006"), new UserID("P007"), new UserID("P008"), new UserID("P009"), new UserID("P010"), new UserID("P011"), new UserID("P012"), new UserID("P013") };
        private int tracker = 0;


        public static UserRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserRepo();
                }
                return instance;
            }
        }

        public List<Doctor> DoctorList { get => doctorList; set => doctorList = value; }

        private List<Patient> patientList;
        private List<Doctor> doctorList;

        private UserRepo()
        {
            patientList = new List<Patient>();
            doctorList = new List<Doctor>();
            fillPatientList();
            fillDoctorList();
        }


        private void fillDoctorList()
        {
            TimeInterval timeInterval = new TimeInterval(new DateTime(2020, 10, 6, 8, 0, 0), new DateTime(2020, 10, 6, 16, 0, 0));
            TimeInterval timeInterval1 = new TimeInterval(new DateTime(2020, 10, 6, 16, 0, 0), new DateTime(2020, 10, 6, 22, 0, 0));
            Dictionary<WorkingDaysEnum, TimeInterval> dict = new Dictionary<WorkingDaysEnum, TimeInterval>();

            dict.Add(WorkingDaysEnum.MONDAY, timeInterval1);
            dict.Add(WorkingDaysEnum.TUESDAY, timeInterval1);
            dict.Add(WorkingDaysEnum.WEDNESDAY, timeInterval1);
            dict.Add(WorkingDaysEnum.THURSDAY, timeInterval1);
            dict.Add(WorkingDaysEnum.FRIDAY, timeInterval1);
            dict.Add(WorkingDaysEnum.SATURDAY, timeInterval);
            dict.Add(WorkingDaysEnum.SUNDAY, timeInterval);

            Dictionary<WorkingDaysEnum, TimeInterval> dict1 = new Dictionary<WorkingDaysEnum, TimeInterval>();
            dict1.Add(WorkingDaysEnum.MONDAY, timeInterval);
            dict1.Add(WorkingDaysEnum.TUESDAY, timeInterval1);
            dict1.Add(WorkingDaysEnum.WEDNESDAY, timeInterval);
            dict1.Add(WorkingDaysEnum.THURSDAY, timeInterval);
            dict1.Add(WorkingDaysEnum.FRIDAY, timeInterval1);
            dict1.Add(WorkingDaysEnum.SATURDAY, timeInterval);
            dict1.Add(WorkingDaysEnum.SUNDAY, timeInterval1);
            TimeTable timeTable = new TimeTable(dict);
            TimeTable timeTable1 = new TimeTable(dict1);
            Doctor doctor = new Doctor(new UserID("d123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Bulevar Oslobodjenja 68", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B123", false, 5, RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            Doctor doctor1 = new Doctor(new UserID("d1266"), "pera", "pera123", DateTime.Now, "Nikola", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-367", "zzzz"), new Room("B124", false, 5, RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            Doctor doctor2 = new Doctor(new UserID("d1267"), "pera", "pera123", DateTime.Now, "Veljko", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Petra perica 8", new Location(45, "Srbija", "Novi Sad")), "555-321321", "zzzz"), new Room("B125", false, 5, RoomType.EXAMINATION), DocTypeEnum.INFECTOLOGIST);
            Doctor doctor3 = new Doctor(new UserID("d1268"), "pera", "pera123", DateTime.Now, "Pera", "Petkovic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable1, new Hospital("test", new Address("Alekse Perica 5", new Location(45, "Srbija", "Novi Sad")), "555-6666666", "zzzz"), new Room("B126", false, 5, RoomType.EXAMINATION), DocTypeEnum.INFECTOLOGIST);
            Doctor doctor4 = new Doctor(new UserID("d1269"), "pera", "pera123", DateTime.Now, "Pera", "Peric", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable1, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-TEST-123", "zzzz"), new Room("B127", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);
            Doctor doctor5 = new Doctor(new UserID("d1271"), "pera", "pera123", DateTime.Now, "Pera", "Zeljic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable1, new Hospital("test", new Address("Koste Sokice 6777", new Location(45, "Srbija", "Novi Sad")), "555-TEST2-132", "zzzz"), new Room("B128", false, 5, RoomType.EXAMINATION), DocTypeEnum.FAMILYMEDICINE);

            doctorList.Add(doctor);
            doctorList.Add(doctor1);
            doctorList.Add(doctor2);
            doctorList.Add(doctor3);
            doctorList.Add(doctor4);
            doctorList.Add(doctor5);
        }


        private void fillPatientList()
        {
            this.patientList.Add(
                    new Patient(new UserID("P001"),
                                          "mika",
                                          "mikamika",
                                          DateTime.Now,
                                          "Milica",
                                          "Mikic",
                                          "Milos",
                                          Sex.FEMALE,
                                          new DateTime(1992, 11, 7),
                                          "9876543221",
                                          new Address("Partizanska 5", new Location(1, "Serbia", "Novi Sad")),
                                          "0213698569",
                                          "06454545454",
                                          "milica@gmail.com",
                                          "",
                                          new EmergencyContact("Milana", "Milanović", "", "0217474859"),
                                          PatientType.GENERAL,
                                          null)
                );

            this.patientList.Add(
                    new Patient(new UserID("P002"),
                                          "pera",
                                          "perapera",
                                          DateTime.Now,
                                          "Petar",
                                          "Vunic",
                                          "Puck",
                                          Sex.MALE,
                                          new DateTime(1997, 11, 7),
                                          "9696943221",
                                          new Address("Partizanska 19", new Location(1, "Serbia", "Beograd")),
                                          "021/555-333",
                                          "064/555-333",
                                          "perica@gmail.com",
                                          "",
                                          new EmergencyContact("Zeljko", "Zeljic", "", "02474859"),
                                          PatientType.GENERAL,
                                          null)
                );
            this.patientList.Add(
                    new Patient(new UserID("P003"),
                                          "pera",
                                          "perapera",
                                          DateTime.Now,
                                          "Andrej",
                                          "Vunic",
                                          "Johnson",
                                          Sex.OTHER,
                                          new DateTime(1972, 11, 7),
                                          "9696222222",
                                          new Address("Milana Rakica 18", new Location(1, "Serbia", "Novi Sad")),
                                          "021/555-666",
                                          "064/555-666",
                                          "andrej@gmail.com",
                                          "",
                                          new EmergencyContact("Zeljko", "Zeljic", "", "02474859"),
                                          PatientType.GENERAL,
                                          null)
                );

        }

        public Patient login(string username, string password)
        {
            Patient loggedInPatient = null;
            foreach(Patient patient in patientList)
            {
                if(patient.UserName.Equals(username) && patient.Password.Equals(password))
                {
                    loggedInPatient = patient;
                }
            }

            return loggedInPatient;
        }


        public Patient register(Patient patient)
        {
            //ako postoji user sa istim username || email vrati gresku 
            Patient registeredPatient = null;

            foreach(Patient pat in patientList)
            {
                if (patient.UserName.Equals(pat.UserName))
                    throw new RegistrationException(String.Format("Username {0} is already taken!", patient.UserName));
                else if (patient.Email1.Equals(pat.Email1))
                    throw new RegistrationException(String.Format("Email {0} is already registered with another account!", patient.Email1));
            }

           


            //aako smo ovde stigli znaci da nismo nasli nijednog drugog usera sa tim ID-om
            registeredPatient = patient;
            registeredPatient.UserID = availableIDS[tracker++];
            patientList.Add(registeredPatient);

            return registeredPatient;
        }


        public Patient updatePatient(Patient patient)
        {

            Patient oldPatient = null;

            foreach (Patient pat in patientList)
            {
                if (patient.GetId().Equals(pat.GetId()))
                {
                    oldPatient = pat;
                    break;
                }
            }

            if(oldPatient == null)
            {
                throw new RegistrationException("ERROR: Patient not found in the database!");
            }
            else
            {
                oldPatient.Name = patient.Name;
                oldPatient.Surname = patient.Surname;
                oldPatient.MiddleName = patient.MiddleName;
                oldPatient.DateOfBirth = patient.DateOfBirth;
                oldPatient.Address = patient.Address;
                oldPatient.Sex = patient.Sex;
                oldPatient.HomePhone = patient.HomePhone;
                oldPatient.CellPhone = patient.CellPhone;
                oldPatient.Email1 = patient.Email1;
                oldPatient.Email2 = patient.Email2;
                oldPatient.EmergencyContact = patient.EmergencyContact;
                oldPatient.UserName = patient.UserName;
                oldPatient.Password = patient.Password;
                oldPatient.Uidn = patient.Uidn;
            }

            return oldPatient; //updated

            

        }

    }
}
