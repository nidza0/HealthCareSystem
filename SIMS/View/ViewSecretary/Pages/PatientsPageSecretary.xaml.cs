using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SIMS.View.ViewSecretary.Pages
{
    /// <summary>
    /// Interaction logic for PatientsPageSecretary.xaml
    /// </summary
    public partial class PatientsPageSecretary : Page
    {
        private ObservableCollection<Patient> patients = new ObservableCollection<Patient>();

        public ObservableCollection<Patient> Patients { get => patients; set => patients = value; }

        public PatientsPageSecretary()
        {
            InitializeComponent();
            this.DataContext = this;
            loadPatients();
            checkPatients();
        }

        private void checkPatients()
        {
            if(Patients.Count == 0)
            {
                errNoPatients.Visibility = Visibility.Visible;
            }
        }
        private void loadPatients()
        {
            //TODO: PatientController > Get All Patients
            patients.Add(new Patient(new UserID("p1"),
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

            patients.Add(new Patient(new UserID("p3"),
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

            patients.Add(new Patient(new UserID("p1"),
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
                                        null));
        }

        private void dataGridPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: open patient details page
            Patient selectedPatient = (Patient)dataGridPatients.SelectedItem;
            FrameManager.getInstance().SideFrame.Navigate(new PatientDetailsPageSecretary(selectedPatient));
        }

        private void dataGridPatients_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Add row number
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
