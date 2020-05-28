using SIMS.Model.UserModel;
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
            ////Console.WriteLine(converter.ConvertEntityToCSV(hospital));
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
            
            Console.WriteLine("===================================================");
            Console.WriteLine(converter2.ConvertEntityToCSV(medRec));
            Console.WriteLine("===================================================");

        }
    }
}
