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
using System.ComponentModel;
using SIMS.Util;

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

        private double screen_height;
        private double screen_width;
        public MakeAnAppointment(double screen_height, double screen_width)
        {
            this.screen_height = screen_height;
            this.screen_width = screen_width;
            this.DataContext = this;
            InitializeComponent();
            RecentChecked(this, null); //Refreshes list.

        }

        private void RecentChecked(object sender, RoutedEventArgs e)
        {
            Doctors.Clear();

            TimeInterval timeInterval = new TimeInterval(new DateTime(2020, 10, 6, 8, 0, 0), new DateTime(2020, 10, 6, 16, 0, 0));
            Dictionary<WorkingDaysEnum, TimeInterval> dict = new Dictionary<WorkingDaysEnum, TimeInterval>();
            dict.Add(WorkingDaysEnum.MONDAY, timeInterval);
            dict.Add(WorkingDaysEnum.TUESDAY, timeInterval);
            dict.Add(WorkingDaysEnum.WEDNESDAY, timeInterval);
            dict.Add(WorkingDaysEnum.THURSDAY, timeInterval);
            dict.Add(WorkingDaysEnum.FRIDAY, timeInterval);
            dict.Add(WorkingDaysEnum.SATURDAY, timeInterval);
            dict.Add(WorkingDaysEnum.SUNDAY, timeInterval);
            TimeTable timeTable = new TimeTable(dict);

            List<Doctor> retVal = new List<Doctor>();
            Doctor doctor = new Doctor(new UserID("d123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Bulevar Oslobodjenja 69", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B123", false, 5, RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            Doctor doctor1 = new Doctor(new UserID("d1266"), "pera", "pera123", DateTime.Now, "Nikola", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B124", false, 5, RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            Doctor doctor2 = new Doctor(new UserID("d1267"), "pera", "pera123", DateTime.Now, "Veljko", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B125", false, 5, RoomType.EXAMINATION), DocTypeEnum.INFECTOLOGIST);

            Doctors.Add(doctor);
            Doctors.Add(doctor1);
            Doctors.Add(doctor2);
            foreach (Doctor doc in getAllDoctors())
                Doctors.Add(doc);


            refreshDoctorList();
        }

        private IEnumerable<Doctor> getAllDoctors()
        {
            //zamenisi sa kotnrolerom

            TimeInterval timeInterval = new TimeInterval(new DateTime(2020,10,6,8,0,0), new DateTime(2020, 10, 6, 16, 0, 0));
            Dictionary<WorkingDaysEnum, TimeInterval> dict = new Dictionary<WorkingDaysEnum, TimeInterval>();
            dict.Add(WorkingDaysEnum.MONDAY, timeInterval);
            dict.Add(WorkingDaysEnum.TUESDAY, timeInterval);
            dict.Add(WorkingDaysEnum.WEDNESDAY, timeInterval);
            dict.Add(WorkingDaysEnum.THURSDAY, timeInterval);
            dict.Add(WorkingDaysEnum.FRIDAY, timeInterval);
            dict.Add(WorkingDaysEnum.SATURDAY, timeInterval);
            dict.Add(WorkingDaysEnum.SUNDAY, timeInterval);
            TimeTable timeTable = new TimeTable(dict);
            
            List<Doctor> retVal = new List<Doctor>();
            Doctor doctor = new Doctor(new UserID("d123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Bulevar Oslobodjenja 69", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B123",false,5,RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            Doctor doctor1 = new Doctor(new UserID("d1266"), "pera", "pera123", DateTime.Now, "Nikola", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B124", false, 5, RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            Doctor doctor2 = new Doctor(new UserID("d1267"), "pera", "pera123", DateTime.Now, "Veljko", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B125", false, 5, RoomType.EXAMINATION), DocTypeEnum.INFECTOLOGIST);
            Doctor doctor3 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com",timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B126", false, 5, RoomType.EXAMINATION), DocTypeEnum.INFECTOLOGIST);
            Doctor doctor4 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B127", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);
            Doctor doctor5 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B128", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);
            Doctor doctor6 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B129", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);
            retVal.Add(doctor);
            retVal.Add(doctor1);
            retVal.Add(doctor2);
            retVal.Add(doctor3);
            retVal.Add(doctor4);
            retVal.Add(doctor5);
            retVal.Add(doctor6);

            return retVal;
        }

        private void refreshDoctorList()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Doctors);
            view.Refresh();
        }

        private void FamilyMedicineChecked(object sender, RoutedEventArgs e)
        {
            Doctors.Clear();
            IEnumerable<Doctor> allDoctors = getAllDoctors();

            foreach(Doctor doctor in allDoctors)
            {
                if (doctor.DocTypeEnum == DocTypeEnum.FAMILYMEDICINE)
                    Doctors.Add(doctor);
            }
            refreshDoctorList();
            
        }

        private void CardiologistChecked(object sender, RoutedEventArgs e)
        {
            Doctors.Clear();
            IEnumerable<Doctor> allDoctors = getAllDoctors();

            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.DocTypeEnum == DocTypeEnum.CARDIOLOGIST)
                    Doctors.Add(doctor);
            }
            refreshDoctorList();
        }

        private void DermatologistChecked(object sender, RoutedEventArgs e)
        {
            Doctors.Clear();
            IEnumerable<Doctor> allDoctors = getAllDoctors();

            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.DocTypeEnum == DocTypeEnum.DERMATOLOGIST)
                    Doctors.Add(doctor);
            }
            refreshDoctorList();
        }

        private void InfectologistChecked(object sender, RoutedEventArgs e)
        {
            Doctors.Clear();
            IEnumerable<Doctor> allDoctors = getAllDoctors();

            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.DocTypeEnum == DocTypeEnum.INFECTOLOGIST)
                    Doctors.Add(doctor);
            }
            refreshDoctorList();
        }

        private void OphtamologistChecked(object sender, RoutedEventArgs e)
        {
            Doctors.Clear();
            IEnumerable<Doctor> allDoctors = getAllDoctors();

            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.DocTypeEnum == DocTypeEnum.OPHTAMOLOGIST)
                    Doctors.Add(doctor);
            }
            refreshDoctorList();
        }

        private void EndocriniologistChecked(object sender, RoutedEventArgs e)
        {
            Doctors.Clear();
            IEnumerable<Doctor> allDoctors = getAllDoctors();

            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.DocTypeEnum == DocTypeEnum.ENDOCRINIOLOGIST)
                    Doctors.Add(doctor);
            }
            refreshDoctorList();
        }

        private void GastroenerologistChecked(object sender, RoutedEventArgs e)
        {
            Doctors.Clear();
            IEnumerable<Doctor> allDoctors = getAllDoctors();

            foreach (Doctor doctor in allDoctors)
            {
                if (doctor.DocTypeEnum == DocTypeEnum.GASTROENEROLOGIST)
                    Doctors.Add(doctor);
            }
            refreshDoctorList();
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

        public double Screen_height { get => screen_height; set => screen_height = value; }
        public double Screen_width { get => screen_width; set => screen_width = value; }

        private void ResetFilterButton_Click(object sender, RoutedEventArgs e)
        {
            first_name_textbox.Text = "";
            last_name_textbox.Text = "";
            hospital_combobox.SelectedIndex = 0;

        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            string filter_name = first_name_textbox.Text;
            string filter_lastname = last_name_textbox.Text;
            ObservableCollection<Doctor> newList = new ObservableCollection<Doctor>();
            foreach(Doctor doctor in getAllDoctors().Where(doc => filter_name == "" ? true :  doc.Name.Contains(filter_name) && (filter_lastname == "" ? true : doc.Name.Contains(filter_lastname))))
            {
                newList.Add(doctor);
            }

            ObservableCollection<Doctor> backUpList = new ObservableCollection<Doctor>();

            Doctors.Clear();

            foreach (Doctor doctor in newList)
                Doctors.Add(doctor);

            refreshDoctorList();

            //return values for next query

        }

        private void MakeAnAppointment_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Doctor doctor = button.DataContext as Doctor;


            BookAnAppointment bookAnAppointment = new BookAnAppointment(doctor);
            bookAnAppointment.Owner = Application.Current.MainWindow;
            bookAnAppointment.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            bookAnAppointment.Width = bookAnAppointment.Owner.Width - 50;
            bookAnAppointment.Height = bookAnAppointment.Owner.Height - 30;
            bookAnAppointment.ShowDialog();
        }
    }
}
