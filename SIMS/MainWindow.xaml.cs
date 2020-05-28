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
        }
    }
}
