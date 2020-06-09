using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter;
using SIMS.Model.ManagerModel;
using SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter;
using SIMS.Model.DoctorModel;
using SIMS.Model.PatientModel;

using SIMS.Repository.CSVFileRepository.MedicalRepository;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;

namespace SIMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Patient p = new Patient();

            //HospitalConverter converter = new HospitalConverter(",");
            //List<Room> testList = new List<Room>();
            //testList.Add(new Room(1, "22", true, 2, RoomType.operation, new Model.ManagerModel.InventoryItem()));
            //testList.Add(new Room(2, "23", true, 2, RoomType.operation, new Model.ManagerModel.InventoryItem()));
            //Hospital hospital = new Hospital(1,"Test hospital", "555-333", "besthospital.com", new List<Room>(), new List<Employee>(), new Address("koste sokice 3",new Location(22,new Country("RS","Srbija"),new City("novi sad","21000"))));
            //HospitalConverter converter = new HospitalConverter(",", ";");
            //List<Room> testList = new List<Room>();
            //List<Employee> employeeList = new List<Employee>();
            //Address address = new Address("koste sokice 3", new Location(22, new Country("RS", "Srbija"), new City("novi sad", "21000")));
            //Doctor doctor = new Doctor(new UserID("D123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", address, "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", new TimeTable(new Dictionary<WorkingDaysEnum, Util.TimeInterval>()), new Hospital("test", address, "555-333", "zzzz"), new Room(1), DocTypeEnum.CARDIOLOGIST);
            //employeeList.Add(doctor);
            //List<InventoryItem> listItem = new List<InventoryItem>();
            //listItem.Add(new InventoryItem("skalpel", 5, 2, new Room(-1)));
            //listItem.Add(new InventoryItem("pera", 10, 3, new Room(-2)));
            //testList.Add(new Room(1, "22", true, 2, RoomType.OPERATION, listItem));
            //testList.Add(new Room(2, "23", true, 2, RoomType.OPERATION, listItem));
            //Hospital hospital = new Hospital(6, "tst hosp", new Address("koste sokice 3", new Location(22, new Country("RS", "Srbija"), new City("novi sad", "21000"))), "555-333", "www.facebook.com", testList, employeeList);
            //string csv = converter.ConvertEntityToCSV(hospital);
            //Console.WriteLine("OLD CSV: " + csv);
            //Hospital newHospital = converter.ConvertCSVToEntity(csv);


            //Console.WriteLine("NEW CSV: " + converter.ConvertEntityToCSV(newHospital));
            //Room testRoom = new Room(22);
            //List<Medicine> medicines = new List<Medicine>();
            //List<InventoryItem> inventoryItems = new List<InventoryItem>();
            //Medicine medicine1 = new Medicine(22, "pera", 33, MedicineType.DROPS, true, new List<Disease>(), new List<Ingredient>(), 5, 6);
            //Medicine medicine2 = new Medicine(77, "pera", 33, MedicineType.DROPS, true, new List<Disease>(), new List<Ingredient>(), 5, 6);

            //InventoryItem inventoryItem1 = new InventoryItem(33, "inventoryItem1", 2, 5, testRoom);
            //InventoryItem inventoryItem2 = new InventoryItem(44, "inventoryItem2", 2, 5, testRoom);

            //medicines.Add(medicine1);
            //medicines.Add(medicine2);

            //inventoryItems.Add(inventoryItem1);
            //inventoryItems.Add(inventoryItem2);

            //InventoryConverter inventoryConverter = new InventoryConverter(",", ";");
            //Inventory inventory = new Inventory(69, inventoryItems, medicines);

            //string csv = inventoryConverter.ConvertEntityToCSV(inventory);
            //Console.WriteLine("OLD CSV: " + csv);

            //Inventory inventoryNew = inventoryConverter.ConvertCSVToEntity(csv);

            //Console.WriteLine("New csv" + inventoryConverter.ConvertEntityToCSV(inventoryNew));
            //Disease disease = new Disease(2);
            //Disease disease1 = new Disease(5);
            //Disease disease2 = new Disease(7);
            //List<Disease> diseaseList = new List<Disease>();
            //diseaseList.Add(disease);
            //diseaseList.Add(disease1);
            //diseaseList.Add(disease2);
            //Ingredient ingredient = new Ingredient(1);
            //Ingredient ingredient1 = new Ingredient(2);
            //Ingredient ingredient2 = new Ingredient(3);
            //List<Ingredient> ingredientList = new List<Ingredient>();
            //ingredientList.Add(ingredient);
            //ingredientList.Add(ingredient1);
            //ingredientList.Add(ingredient2);

            //Medicine medicine = new Medicine(69, "droga", 500, MedicineType.DROPS, true, diseaseList, ingredientList, 6, 9);
            //MedicineConverter medicineConverter = new MedicineConverter(",", ";");
            //string csv = medicineConverter.ConvertEntityToCSV(medicine);
            //Console.WriteLine("OLD CSV: " + csv);
            //Medicine newMedicine = medicineConverter.ConvertCSVToEntity(csv);
            //Console.WriteLine("New CSV: " + medicineConverter.ConvertEntityToCSV(newMedicine));


            //string retVal = converter.ConvertEntityToCSV(hospital);
            //Console.WriteLine(retVal);
            //Console.WriteLine("TEST");

            
            /*
            RoomConverter converter = new RoomConverter();

            Room room2 = new Room(2, "23", true, 3, RoomType.OPERATION);
            Room room1 = new Room(1, "22", true, 2, RoomType.OPERATION);

            string retVal1 = converter.ConvertEntityToCSV(room1);
            string retVal2 = converter.ConvertEntityToCSV(converter.ConvertCSVToEntity(retVal1));

            Console.WriteLine(retVal1.Equals(retVal2));

            */
            /*
            MedicalRecordConverter converter2 = new MedicalRecordConverter("*");

            List <Diagnosis> diagList = new List<Diagnosis>();
            diagList.Add(new Diagnosis(2, new Disease(2),new Therapy(2),new List<Therapy>()));
            diagList.Add(new Diagnosis(4, new Disease(2), new Therapy(5), new List<Therapy>()));

            List<Allergy> alerList = new List<Allergy>();
            alerList.Add(new Allergy(6));
            alerList.Add(new Allergy(8));


            MedicalRecord medRec = new MedicalRecord(2, new Patient(new UserID("P69")), BloodType.AB_NEGATIVE, diagList, alerList);
            List<Diagnosis> lista = medRec.PatientDiagnosis;
            string csv = converter2.ConvertEntityToCSV(medRec);
            
            Console.WriteLine("===================================================");
            Console.WriteLine(csv);
            Console.WriteLine("===================================================");
            MedicalRecord medRec2 = converter2.ConvertCSVToEntity(csv);
            Console.WriteLine(converter2.ConvertEntityToCSV(medRec2));
            Console.WriteLine("===================================================");
            */

            /*
            Secretary secretary = new Secretary(new UserID("s1"), "gergoo", "pass123", DateTime.Now, "Sekretar", "Sekretaric", "M", Sex.OTHER, new DateTime(1980,6,18), "0123456789", new Address("Ulica br 4", new Location(87, "Serbia", "Novi Sad")), "021787878", "0646464646", "email1@email", "email2@email", new TimeTable(78), new Hospital(7));
            SecretaryConverter conv = new SecretaryConverter(";", "dd.MM.yyyy.");
            string secString1 = conv.ConvertEntityToCSV(secretary);
            Console.WriteLine(secString1);
            string secString2 = conv.ConvertEntityToCSV(conv.ConvertCSVToEntity(secString1));
            Console.WriteLine(secString1.Equals(secString2));
            */
            /*
            User user = new User(new UserID("d5677"), "usernaaaa", "passwd", DateTime.Now, true);
            UserConverter conv = new UserConverter(",", "dd.MM.yyyy.");
            string usrString1 = conv.ConvertEntityToCSV(user);
            Console.WriteLine(usrString1);
            string usrString2 = conv.ConvertEntityToCSV(conv.ConvertCSVToEntity(usrString1));
            Console.WriteLine(usrString1.Equals(usrString2));*/

            /** Prescription tests **/

            //Dictionary<Medicine, TherapyDose> medicine = new Dictionary<Medicine, TherapyDose>();
            //Dictionary<TherapyTime, double> dosage1 = new Dictionary<TherapyTime, double>();
            //dosage1.Add(TherapyTime.Afternoon, 7);
            //dosage1.Add(TherapyTime.BeforeBed, 3);
            //dosage1.Add(TherapyTime.WhenIWakeUp, 2);
            //medicine.Add(new Medicine(75), new TherapyDose(dosage1));

            //Dictionary<TherapyTime, double> dosage2 = new Dictionary<TherapyTime, double>();
            //dosage2.Add(TherapyTime.AsNeeded, 1);
            //dosage2.Add(TherapyTime.BeforeBed, 2);
            //dosage2.Add(TherapyTime.Afternoon, 6);
            //medicine.Add(new Medicine(54), new TherapyDose(dosage2));

            //Dictionary<TherapyTime, double> dosage3 = new Dictionary<TherapyTime, double>();
            //dosage3.Add(TherapyTime.AsNeeded, 9);
            //dosage3.Add(TherapyTime.Evening, 5);
            //dosage3.Add(TherapyTime.BeforeBed, 3);
            //medicine.Add(new Medicine(23), new TherapyDose(dosage3));

            //Prescription p = new Prescription(78, PrescriptionStatus.ACTIVE, new Doctor(new UserID("d78")), medicine);

            //PrescriptionConverter conv = new PrescriptionConverter(",","~","#","/","!");
            //string csv1 = conv.ConvertEntityToCSV(p);
            //string csv2 = conv.ConvertEntityToCSV(conv.ConvertCSVToEntity(csv1));

            //Console.WriteLine(csv1.Equals(csv2));


            //Allergy allergy = new Allergy(55);

            //Symptom symptom = new Symptom(1);
            //Symptom symptom1 = new Symptom(2);
            //Symptom symptom2 = new Symptom(3);
            //Symptom symptom3 = new Symptom(4);
            //Symptom symptom4 = new Symptom(5);
            //Symptom symptom5 = new Symptom(6);

            //List<Symptom> symptoms = new List<Symptom>();
            //symptoms.Add(symptom);
            //symptoms.Add(symptom1);
            //symptoms.Add(symptom2);
            //symptoms.Add(symptom3);
            //symptoms.Add(symptom4);
            //symptoms.Add(symptom5);

            //allergy.Symptoms = symptoms;

            //Symptom temp = symptoms[1];
            //temp = new Symptom(6000);



            //AllergyConverter allergyConverter = new AllergyConverter(",", ";");
            //Symptom symptom = new Symptom(1);
            //Symptom symptom1 = new Symptom(2);
            //Ingredient ingredient = new Ingredient(69);

            //List<Symptom> symptom_list = new List<Symptom>();

            //symptom_list.Add(symptom);
            //symptom_list.Add(symptom1);


            ////Allergy allergy = new Allergy(33, "Test alergija", ingredient, symptom_list);
            //Allergy allergy = new Allergy(33, "Test alergija", ingredient, null);

            //string csv = allergyConverter.ConvertEntityToCSV(allergy);

            //Allergy newAllergy = allergyConverter.ConvertCSVToEntity(csv);

            //Console.WriteLine("OLD CSV: " + csv);
            //Console.WriteLine("NEW CSV: " + allergyConverter.ConvertEntityToCSV(newAllergy));
            //String ingredient_path = @"../../files/ingredients.txt";
            //String symptom_path = @"../../files/symptoms.txt";
            //String allergy_path = @"../../files/allergies.txt";


            //IngredientRepository ingredientRepository = new IngredientRepository("ingredient_test", new CSVStream<Ingredient>(ingredient_path, new IngredientConverter(",")), new LongSequencer());
            //SymptomRepository symptomRepository = new SymptomRepository("symptom_repo", new CSVStream<Symptom>(symptom_path, new SymptomConverter(",")), new LongSequencer());
            //AllergyRepository allergyRepository = new AllergyRepository("test", new CSVStream<Allergy>(allergy_path, new AllergyConverter(",",";")), new LongSequencer(), ingredientRepository, symptomRepository);

            //Ingredient ingredient1 = new Ingredient("ingredient_1");
            //Ingredient ingredient2 = new Ingredient("ingredient_2");

            //Symptom symptom1 = new Symptom("Boli me nos", "Jako me boli nos");
            //Symptom symptom2 = new Symptom("Boli me glava", "Jako me boli glava");

            //ingredientRepository.Create(ingredient1);
            //ingredientRepository.Create(ingredient2);

            //symptomRepository.Create(symptom1);
            //symptomRepository.Create(symptom2);

            //List<Symptom> test_list = new List<Symptom>();
            //test_list.Add(symptomRepository.GetByID(1));
            //test_list.Add(symptomRepository.GetByID(2));


            //Allergy allergy = new Allergy("Test allergy", ingredientRepository.GetByID(1), new List<Symptom>());

            //allergyRepository.Create(allergy);


            //String ingredient_path = @"../../files/MedicalFiles/ingredients.txt";
            //String symptom_path = @"../../files/MedicalFiles/symptoms.txt";
            //String allergy_path = @"../../files/MedicalFiles/allergies.txt";


            //IngredientRepository ingredientRepository = new IngredientRepository("ingredient_test", new CSVStream<Ingredient>(ingredient_path, new IngredientConverter(",")), new LongSequencer());
            //SymptomRepository symptomRepository = new SymptomRepository("symptom_repo", new CSVStream<Symptom>(symptom_path, new SymptomConverter(",")), new LongSequencer());
            //AllergyRepository allergyRepository = new AllergyRepository("test", new CSVStream<Allergy>(allergy_path, new AllergyConverter(",", ";")), new LongSequencer(), ingredientRepository, symptomRepository);

            //Ingredient ingredient1 = new Ingredient("ingredient_1");
            //Ingredient ingredient2 = new Ingredient("ingredient_2");

            //Symptom symptom1 = new Symptom("Boli me nos", "Jako me boli nos");
            //Symptom symptom2 = new Symptom("Boli me glava", "Jako me boli glava");

            //ingredientRepository.Create(ingredient1);
            //ingredientRepository.Create(ingredient2);

            //symptomRepository.Create(symptom1);
            //symptomRepository.Create(symptom2);

            //List<Symptom> test_list = new List<Symptom>();
            //test_list.Add(symptomRepository.GetByID(1));
            //test_list.Add(symptomRepository.GetByID(2));


            //Allergy allergy = new Allergy("Test allergy", ingredientRepository.GetByID(1), test_list);

            //Allergy tst = allergyRepository.Create(allergy);

            //foreach (Symptom symp in tst.Symptoms)
            //    Console.WriteLine(symp.Name);
            /*
            AppResources appResources = AppResources.getInstance();

            SymptomRepository symptomRepository = appResources.symptomRepository;
            Symptom symptom1 = new Symptom("B123", "Soba za operacije");
            Symptom symptom2 = new Symptom("B134", "Soba za prijem");
            symptomRepository.Create(symptom1);
            symptomRepository.Create(symptom2);
            

            */


            
            AppResources res = AppResources.getInstance();
            
            /*
            Secretary secretary = new Secretary("secr3450", "passwd", "SekretarIme", "SekretarPrezime", null, Sex.MALE, new DateTime(1999, 5, 5), "4578145236", null, null, null, null, null, null, null);
            Secretary secretary2 = new Secretary("jidhsdi", "123456", "SekretarIme2", "SekretarPrezime2", null, Sex.MALE, new DateTime(2000, 5, 5), "164410546", null, null, null, null, null, null, null);

            res.secretaryRepository.Create(secretary);
            res.secretaryRepository.Create(secretary2);
            */
        }
    }
}
