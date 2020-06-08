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
    /// Interaction logic for MakeAnAppointment.xaml
    /// </summary>
    public partial class MakeAnAppointment : Window
    {
        private ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();

        public ObservableCollection<Doctor> Doctors { get => doctors; set => doctors = value; }

        private Hospital _chosenHospital = null;

        public MakeAnAppointment()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void RecentChecked(object sender, RoutedEventArgs e)
        {
            Doctors.Clear();

            Doctor doctor = new Doctor(new UserID("d123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", new TimeTable(3, new Dictionary<WorkingDaysEnum, Util.TimeInterval>()), new Hospital("test", new Address("Bulevar Oslobodjenja 69", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room(1), DocTypeEnum.CARDIOLOGIST);
            Doctor doctor1 = new Doctor(new UserID("d1266"), "pera", "pera123", DateTime.Now, "Nikola", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", new TimeTable(3, new Dictionary<WorkingDaysEnum, Util.TimeInterval>()), new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room(1), DocTypeEnum.CARDIOLOGIST);
            Doctors.Add(doctor);
            Doctors.Add(doctor1);
            //call get recent from controller
        }

        private void FamilyMedicineChecked(object sender, RoutedEventArgs e)
        {

        }

        private void CardiologistChecked(object sender, RoutedEventArgs e)
        {

        }

        private void DermatologistChecked(object sender, RoutedEventArgs e)
        {

        }

        private void InfectologistChecked(object sender, RoutedEventArgs e)
        {

        }

        private void OphtamologistChecked(object sender, RoutedEventArgs e)
        {

        }

        private void EndocriniologistChecked(object sender, RoutedEventArgs e)
        {

        }

        private void GastroenerologistChecked(object sender, RoutedEventArgs e)
        {

        }

        public Hospital ChosenHospital
        {
            get
            {
                return _chosenHospital;
            }
            set
            {
                _chosenHospital = value;
            }
        }

        public ObservableCollection<Hospital> Hospitals
        {
            get
            {
                //call controller -> service -> repo getAll
                Hospital hospital1 = new Hospital(63, "Decje", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "testsajt", new List<Room>(), new List<Employee>());
                Hospital hospital2 = new Hospital(63, "Perina bolnica", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "testsajt", new List<Room>(), new List<Employee>());
                Hospital hospital3 = new Hospital(63, "miroljub bolnica", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "testsajt", new List<Room>(), new List<Employee>());
                ObservableCollection<Hospital> retVal = new ObservableCollection<Hospital>();
                retVal.Add(hospital1);
                retVal.Add(hospital2);
                retVal.Add(hospital3);
                return retVal;
            }
        }
         
    }
}
