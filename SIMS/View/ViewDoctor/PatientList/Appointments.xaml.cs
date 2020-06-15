using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Util;
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

namespace SIMS.View.ViewDoctor.PatientList
{
    /// <summary>
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Page
    {
        Patient patient;
        List<Model.PatientModel.Appointment> allApps;
        public Appointments(Patient selektovaniPacijent)
        {
            patient = selektovaniPacijent;
            Console.WriteLine(patient.Name);
            string name = patient.Name;
            string surname = patient.Surname;
            string naslov = "Kontrole - " + name + " " + surname;

            
            InitializeComponent();
            Naslov.Text = naslov;
            ActiveDate.SelectedDate = DateTime.Now;
            //NewApp.Visibility = Visibility.Hidden;
            EditAppointment.IsEnabled = false;
            CancelAppointment.IsEnabled = false;
            fillDataGrid();
        }

        private void fillDataGrid()
        {
            Console.WriteLine(AppResources.getLoggedInUser().GetId());
            /*
            List<Appointment> allApps = AppResources.getInstance().appointmentRepository.GetPatientAppointments(patient).ToList();
            if(allApps.Count > 1)
            {
                allApps = allApps.Where(app => app.DoctorInAppointment.GetId()
            .Equals(AppResources.getLoggedInUser().GetId()) && app.TimeInterval.StartTime.Day == ActiveDate.SelectedDate.Value.Day).ToList();
            }
            AppointmentList.ItemsSource = allApps;
            */
            allApps = new List<Model.PatientModel.Appointment>();
            allApps.Add(new Appointment(151, AppResources.getLoggedInUser(), AppResources.getInstance().patientRepository.GetPatientByDoctor(AppResources.getLoggedInUser()).SingleOrDefault(patient => patient.Name == "Mika"),
                new Model.UserModel.Room("111A", false, 1, Model.UserModel.RoomType.EXAMINATION), AppointmentType.checkup, new TimeInterval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(1).AddMinutes(15))));
            AppointmentList.ItemsSource = allApps;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ActiveDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillDataGrid();
        }

        private void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            NewAppointment app = new NewAppointment(patient, NewApp, AppointmentList, allApps);
            app.VerticalAlignment = VerticalAlignment.Center;
            app.Height = 400;
            app.Width = 400;
            // NewApp.Visibility = Visibility.Visible;
           // AppointmentList.Visibility = Visibility.Hidden;

            

            NewApp.Children.Add(app);
        }

        private void EditAppointment_Click(object sender, RoutedEventArgs e)
        {
            EditAppointment app = new EditAppointment((Appointment) AppointmentList.SelectedItem, NewApp, AppointmentList, allApps);
            app.VerticalAlignment = VerticalAlignment.Center;
            app.Height = 400;
            app.Width = 400;

            NewApp.Children.Add(app);
        }

        private void CancelAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment temp = (Appointment)AppointmentList.SelectedItem;
            temp.Canceled = true;
            //AppResources.getInstance().appointmentRepository.Delete(temp);
            AppointmentList.Items.Refresh();
        }

        private void AppointmentList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if(AppointmentList.SelectedItem != null)
            {
                EditAppointment.IsEnabled = true;
                CancelAppointment.IsEnabled = true;
            }
        }

        private void AppointmentList_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            fillDataGrid();
        }

        private void Back_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
