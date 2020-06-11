using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIMS.Model.PatientModel;
using SIMS.Util;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;


namespace SIMS.View.ViewPatient.RepoSimulator
{

    
    class TherapyRepo
    {
        private List<Therapy> therapyList;

        private static TherapyRepo instance = null;


        public static TherapyRepo Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TherapyRepo();
                }
                return instance;
            }
        }

        private TherapyRepo()
        {
            therapyList = new List<Therapy>();
            fillTherapyList();
        }

        private void fillTherapyList()
        {
            //dummy data
            Medicine medicine1 = new Medicine("Brufen", 50, MedicineType.PILL, 5, 7);
            Medicine medicine2 = new Medicine("Kapi za nos", 10, MedicineType.DROPS, 5, 7);
            Medicine medicine3 = new Medicine("Perobrufen", 68, MedicineType.PILL, 5, 7);
            Medicine medicine4 = new Medicine("Oljaprofen", 68, MedicineType.INJECTIONS, 5, 7);
            Medicine medicine5 = new Medicine("Ketaprofen", 68, MedicineType.SUPPOSITORIES, 5, 7);
            Medicine medicine6 = new Medicine("Zetaprofen", 68, MedicineType.TOPICAL_MEDICINE, 5, 7);

            Dictionary<Medicine, TherapyDose> medicine = new Dictionary<Medicine, TherapyDose>();
            Dictionary<Medicine, TherapyDose> medicineDict = new Dictionary<Medicine, TherapyDose>();
            Dictionary<TherapyTime, double> dosage1 = new Dictionary<TherapyTime, double>();
            Dictionary<TherapyTime, double> dosage2 = new Dictionary<TherapyTime, double>();
            Dictionary<TherapyTime, double> dosage3 = new Dictionary<TherapyTime, double>();
            dosage1.Add(TherapyTime.Afternoon, 7);
            dosage1.Add(TherapyTime.BeforeBed, 3);
            dosage1.Add(TherapyTime.WhenIWakeUp, 2);

            dosage2.Add(TherapyTime.BeforeBed, 1);
            dosage2.Add(TherapyTime.AsNeeded, 6);

            dosage3.Add(TherapyTime.Afternoon, 22);

            medicine.Add(medicine1, new TherapyDose(dosage1));
            medicine.Add(medicine2, new TherapyDose(dosage2));
            medicine.Add(medicine3, new TherapyDose(dosage3));

            medicineDict.Add(medicine4, new TherapyDose(dosage2));
            medicineDict.Add(medicine5, new TherapyDose(dosage1));
            medicineDict.Add(medicine6, new TherapyDose(dosage3));

            Doctor doctor = new Doctor(new UserID("d123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", new TimeTable(3, new Dictionary<WorkingDaysEnum, Util.TimeInterval>()), new Hospital("test", new Address("Bulevar Oslobodjenja 69", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room(1), DocTypeEnum.CARDIOLOGIST);
            Doctor doctor1 = new Doctor(new UserID("d124"), "pera", "pera123", DateTime.Now, "Olja", "Oljic", "Puck", Sex.FEMALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", new TimeTable(3, new Dictionary<WorkingDaysEnum, Util.TimeInterval>()), new Hospital("test", new Address("Bulevar Oslobodjenja 69", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room(1), DocTypeEnum.SURGEON);

            Prescription p1 = new Prescription(78, PrescriptionStatus.ACTIVE, doctor, medicine);
            Prescription p2 = new Prescription(78, PrescriptionStatus.ACTIVE, doctor1, medicineDict);
            //Prescription p2 = new Prescription(78, PrescriptionStatus.ACTIVE, new Doctor(new UserID("d78")), medicine);
            //Prescription p3 = new Prescription(78, PrescriptionStatus.ACTIVE, new Doctor(new UserID("d78")), medicine);

            Therapy therapy1 = new Therapy(new TimeInterval(DateTime.Now, DateTime.Now.AddDays(18)), p1);
            Therapy therapy2 = new Therapy(new TimeInterval(DateTime.Now.AddDays(4), DateTime.Now.AddDays(14)), p2);
            //Therapy therapy2 = new Therapy(new TimeInterval(DateTime.Now, DateTime.Now.AddDays(18)), p2);

            //retVal.Add(therapy1);
            //retVal.Add(therapy2);

            therapyList.Add(therapy1);
            therapyList.Add(therapy2);
        }

        public List<Therapy> TherapyList { get => therapyList; set => therapyList = value; }
    }
}
