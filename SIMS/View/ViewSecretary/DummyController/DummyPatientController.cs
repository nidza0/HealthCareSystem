using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewSecretary.DummyController
{
    class DummyPatientController
    {
        private static DummyPatientController _instance;
        public List<Patient> Patients;

        private DummyPatientController() {
            LoadDummyPatients();
        }

        public static DummyPatientController getInstance()
        {
            if (_instance == null)
                _instance = new DummyPatientController();
            return _instance;
        }
        public void LoadDummyPatients()
        {
            Patients.Add(new Patient(new UserID("p1"),
                                        "peraaa13",
                                        "",
                                        DateTime.Now,
                                        "Pera",
                                        "Peric",
                                        "P.",
                                        Sex.MALE,
                                        new DateTime(1987, 10, 12),
                                        "01234678",
                                        new Address("Bul. Mihajla Pupina 6", new Location(1, "Serbia", "Novi Sad")),
                                        "0217878787",
                                        "25848596532",
                                        "pera@peric.rs",
                                        "",
                                        new EmergencyContact("Milan", "Milanovic", "", "025478956325"),
                                        PatientType.GENERAL,
                                        null));

            Patients.Add(new Patient(new UserID("p3"),
                                        "milica92",
                                        "",
                                        DateTime.Now,
                                        "Milica",
                                        "Mikic",
                                        "M.",
                                        Sex.FEMALE,
                                        new DateTime(1992, 11, 7),
                                        "9876543221",
                                        new Address("Partizanska 5", new Location(1, "Serbia", "Novi Sad")),
                                        "0213698569",
                                        "06454545454",
                                        "milica@gmail.com",
                                        "",
                                        new EmergencyContact("Milana", "Milanovic", "", "0217474859"),
                                        PatientType.GENERAL,
                                        null));

            Patients.Add(new Patient(new UserID("p1"),
                                        "alien65",
                                        "",
                                        DateTime.Now,
                                        "X Æ A-Xii",
                                        "Musk",
                                        "X.",
                                        Sex.OTHER,
                                        new DateTime(2020, 5, 4),
                                        "8742154780000",
                                        new Address("Some fancy stree", new Location(2, "Los Angeles", "USA")),
                                        "545846543",
                                        "56202154821",
                                        "xaeaxii@elonmusk.com",
                                        "",
                                        new EmergencyContact("Elon", "Musk", "elon@musk.com", "75315454545"),
                                        PatientType.GENERAL,
                                        DummyDoctorController.getInstance().Doctor));
        }
    }
}
