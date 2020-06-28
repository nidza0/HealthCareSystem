using SIMS.View.ViewSecretary.Pages.Appointments;
using SIMS.View.ViewSecretary.Pages.Doctors;
using SIMS.View.ViewSecretary.Pages.Patients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for MainWindowPageSecretary.xaml
    /// </summary>
    public partial class MainWindowPage : Page, INotifyPropertyChanged
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        DateTime currDateTime = new DateTime();

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public DateTime CurrDateTime { get => currDateTime; set => currDateTime = value; }

        public MainWindowPage()
        {
            InitializeComponent();
            DataContext = this;
            InitializeDateTime();
            FrameManager.getInstance().CentralFrame = CentralFrame;
            FrameManager.getInstance().SideFrame = SideFrame;
            CentralFrame.Navigate(new HomePage());
            SideFrame.Navigate(new CompanyPage());
        }

        private void InitializeDateTime()
        {
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            CurrDateTime = DateTime.Now;
            OnPropertyChanged();
        }

        private void btn_newpatient_Click(object sender, RoutedEventArgs e)
        {
            CentralFrame.Navigate(new NewPatientPage());
        }
        /*
        private void btn_sidebar_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
        }
        */
        private void btn_newappointment_Click(object sender, RoutedEventArgs e)
        {
            SideFrame.Content = new CreateUpdateAppointmentPage();
        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {
            CentralFrame.Navigate(new HomePage());
        }

        private void btn_appointments_Click(object sender, RoutedEventArgs e)
        {
            CentralFrame.Navigate(AppointmentsPage.GetInstance());
        }

        private void btn_cancelledappointments_Click(object sender, RoutedEventArgs e)
        {
            CentralFrame.Navigate(CancelledAppointmentsPage.GetInstance());
        }

        private void btn_doctors_Click(object sender, RoutedEventArgs e)
        {
            CentralFrame.Navigate(new DoctorsPage());
        }

        private void btn_patients_Click(object sender, RoutedEventArgs e)
        {
            CentralFrame.Navigate(new PatientsPage());
        }

        private void btn_profile_Click(object sender, RoutedEventArgs e)
        {
            CentralFrame.Navigate(new ProfilePage());
        }

        private void btn_inbox_Click(object sender, RoutedEventArgs e)
        {
            //CentralFrame.Navigate(new InboxPage());
        }

        private void btn_settings_Click(object sender, RoutedEventArgs e)
        {
            CentralFrame.Navigate(new SettingsPage());
        }

        private void btn_report_Click(object sender, RoutedEventArgs e)
        {
            FrameManager.getInstance().CentralFrame.Navigate(new ReportPage());
        }
    }
}
