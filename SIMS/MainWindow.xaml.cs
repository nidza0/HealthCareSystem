﻿using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter;
using SIMS.Model.ManagerModel;
using SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter;
using SIMS.Model.DoctorModel;
using SIMS.Model.PatientModel;

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

            RoomConverter converter = new RoomConverter(",");
            List<InventoryItem> testlist = new List<InventoryItem>
            {
                new InventoryItem(3),
                new InventoryItem(4)
            };


            Room room2 = new Room(2, "23", true, 3, RoomType.OPERATION, new List<InventoryItem>());
            testlist.Add(new InventoryItem(5,"kita",2,1,room2));
            Room room1 = new Room(1, "22", true, 2, RoomType.OPERATION, testlist);

            string retVal1 = converter.ConvertEntityToCSV(room1);
            string retVal2 = converter.ConvertEntityToCSV(room2);

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(retVal1);
            Console.WriteLine(retVal2);
            Console.WriteLine("--------------------------------------------------");
            Room room3 = converter.ConvertCSVToEntity(retVal1);
            Console.WriteLine(room3);
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine(converter.ConvertEntityToCSV(room3));
            Console.WriteLine("--------------------------------------------------");


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


        }
    }
}
