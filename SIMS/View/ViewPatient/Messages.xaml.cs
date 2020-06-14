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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using SIMS.Model.UserModel;
using SIMS.Model.DoctorModel;


namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for Messages.xaml
    /// </summary>
    public partial class Messages : Window
    {
        public ObservableCollection<Message> myMessages = new ObservableCollection<Message>();
        private ObservableCollection<User> distinctConversationist;
        private User selected;


        public Messages()
        {
            InitializeComponent();

            this.DataContext = this;
            //Patient p = new Patient();

            //HospitalConverter converter = new HospitalConverter(",");
            //List<Room> testList = new List<Room>();
            //testList.Add(new Room(1, "22", true, 2, RoomType.operation, new Model.ManagerModel.InventoryItem()));
            //testList.Add(new Room(2, "23", true, 2, RoomType.operation, new Model.ManagerModel.InventoryItem()));
            //Hospital hospital = new Hospital(1,"Test hospital", "555-333", "besthospital.com", new List<Room>(), new List<Employee>(), new Address("koste sokice 3",new Location(22,new Country("RS","Srbija"),new City("novi sad","21000"))));
            List<Room> testList = new List<Room>();
            List<Employee> employeeList = new List<Employee>();
            Address address = new Address("Koste Sokice 3", new Location(22, "SRBIJA", "NOVI SAD"));
            Doctor doctor1 = new Doctor(new UserID("D123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", address, "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", new TimeTable(new Dictionary<WorkingDaysEnum, Util.TimeInterval>()), new Hospital("test", address, "555-333", "zzzz"), new Room(1), DocTypeEnum.CARDIOLOGIST);
            //string retVal = converter.ConvertEntityToCSV(hospital);
            //Console.WriteLine(retVal);

            Doctor doctor2 = new Doctor(new UserID("D123"), "pera", "pera123", DateTime.Now, "Nikola", "Dragic", "Pzzz", Sex.MALE, DateTime.Now, "12345667", address, "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", new TimeTable(new Dictionary<WorkingDaysEnum, Util.TimeInterval>()), new Hospital("test", address, "555-333", "zzzz"), new Room(1), DocTypeEnum.CARDIOLOGIST);
            Doctor doctor3 = new Doctor(new UserID("D123"), "pera", "pera123", DateTime.Now, "Aleksa", "Vunic", "yyyyy", Sex.MALE, DateTime.Now, "12345667", address, "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", new TimeTable(new Dictionary<WorkingDaysEnum, Util.TimeInterval>()), new Hospital("test", address, "555-333", "zzzz"), new Room(1), DocTypeEnum.CARDIOLOGIST);


            Message message1 = new Message(69, "Cao ja sam Nikola", doctor1, doctor1, DateTime.Now);
            Message message2 = new Message(61, "Cao ja sam Nikola", doctor2, doctor2, DateTime.Now);
            Message message3 = new Message(62, "Cao ja sam Nikola", doctor3, doctor3, DateTime.Now);
            Message message4 = new Message(668, "Caooooo", doctor1, doctor3, DateTime.Now);


            myMessages.Add(message1);
            myMessages.Add(message2);
            myMessages.Add(message3);


           
        }


        public ObservableCollection<User> DistinctConversationist
        {
            get
            {
                IEnumerable<User> recepients = myMessages.Select(message => message.Recipient).Distinct();
                IEnumerable<User> senders = myMessages.Select(message => message.Sender).Distinct();
                Console.WriteLine(((recepients.Concat(senders)).Distinct().ToList()).Count);
                return new ObservableCollection<User>((recepients.Concat(senders)).Distinct());
            }

            set
            {
                distinctConversationist = value;
            }

        }

        public User Selected {
            get => selected; set => selected = value;
        }
    }
}