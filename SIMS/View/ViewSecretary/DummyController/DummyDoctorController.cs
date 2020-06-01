using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewSecretary.DummyController
{

    class DummyDoctorController
    {
        private static DummyDoctorController _instance;
        public List<Doctor> Doctors;
        public Doctor Doctor;

        private DummyDoctorController()
        {
            LoadDummyDoctors();
        }

        private void LoadDummyDoctors()
        {
            Doctor = new Doctor(new UserID("d678"), "drstrange", "", DateTime.Now, "Stephen", "Strange", "Doctor", Sex.MALE, DateTime.Now, "4578457854", new Address("Boulevard of Amercia", new Location(785, "USA", "New York")), "0081747474", "", "drstrange@marvel.com", "stephen.strange@marvel.com", new TimeTable(63), new Hospital(23), new Room(125), Model.DoctorModel.DocTypeEnum.SURGEON);

            Doctors.Add(Doctor);
            Doctors.Add(new Doctor(new UserID("d685"), "p.kon", "", DateTime.Now, "Predrag", "Kon", "", Sex.MALE, DateTime.Now, "113543545488", new Address("Ulica bb", new Location(100, "Serbia", "Belgrade")), "0118754786", "", "dr.kon@zdrav.gov.rs", "", new TimeTable(62), new Hospital(21), new Room(3), Model.DoctorModel.DocTypeEnum.INFECTOLOGIST));
            Doctors.Add(new Doctor(new UserID("d682"), "darija", "", DateTime.Now, "Darija", "Kisic", "", Sex.FEMALE, DateTime.Now, "251812065115", new Address("Bulevar oslobodjenja", new Location(100, "Serbia", "Belgrade")), "0118798449", "", "darija.kk@gmail.com", "", new TimeTable(18), new Hospital(21), new Room(4), Model.DoctorModel.DocTypeEnum.INFECTOLOGIST));
        }

        public static DummyDoctorController getInstance()
        {
            if (_instance == null)
                _instance = new DummyDoctorController();
            return _instance;
        }
    }
}
