using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace SIMS.View.ViewManager
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        Dummies.DummyDoctors dummy = new Dummies.DummyDoctors();

        public static ObservableCollection<Doctor> doctors;
        public static ObservableCollection<InventoryItem> items;
        public static ObservableCollection<Room> rooms;
        public static ObservableCollection<Medicine> medicines;
        public static ObservableCollection<Appointment> appointments;


        public static int iter = 3;

        public Login()
        {
            InitializeComponent();

            doctors = new ObservableCollection<Doctor>();

            foreach (Doctor doc in Dummies.DummyDoctors.doctorsList)
                doctors.Add(doc);

            items = new ObservableCollection<InventoryItem>();

            foreach (InventoryItem item in Dummies.DummyDoctors.itemsList)
                items.Add(item);

            rooms = new ObservableCollection<Room>();

            foreach (Room room in Dummies.DummyDoctors.roomsList)
                rooms.Add(room);

            medicines = new ObservableCollection<Medicine>();

            foreach (Medicine med in Dummies.DummyDoctors.medicineList)
                medicines.Add(med);

            appointments = new ObservableCollection<Appointment>();

            foreach (Appointment app in Dummies.DummyDoctors.appointmentsList)
                appointments.Add(app);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/ManagerMainPage.xaml", UriKind.Relative));
        }
    }
}
