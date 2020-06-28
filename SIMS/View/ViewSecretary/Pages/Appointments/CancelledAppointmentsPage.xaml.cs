using SIMS.Model.PatientModel;
using SIMS.View.ViewSecretary.ViewModel;
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

namespace SIMS.View.ViewSecretary.Pages.Appointments
{
    /// <summary>
    /// Interaction logic for CancelledAppointmentsPage.xaml
    /// </summary>
    public partial class CancelledAppointmentsPage : Page
    {
        private AppointmentsViewModel appointmentsVM;

        private static CancelledAppointmentsPage instance = null;

        public static CancelledAppointmentsPage GetInstance()
        {
            if (instance == null)
                instance = new CancelledAppointmentsPage();
            instance.Refresh();
            return instance;
        }

        private CancelledAppointmentsPage()
        {
            InitializeComponent();
            appointmentsVM = new AppointmentsViewModel();
            DataContext = appointmentsVM;
            //Refresh();
        }

        public void Refresh()
        {
            appointmentsVM.LoadCancelledAppointments();
            Console.WriteLine(appointmentsVM.Appointments.Count());
            checkAppointments();
        }

        private void dataGridCancelledAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Appointment selectedAppointment = dataGridCancelledAppointments.SelectedItem as Appointment;
            if(selectedAppointment != null)
            {
                FrameManager.getInstance().SideFrame.Navigate(new AppointmentDetailsPage(selectedAppointment));
            }
        }

        private void dataGridCancelledAppointments_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Add row number
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void checkAppointments()
        {
            if (appointmentsVM.Appointments.Count == 0)
            {
                errNoCancelledAppointments.Visibility = Visibility.Visible;
                dataGridCancelledAppointments.Visibility = Visibility.Collapsed;
            }
            else
            {
                errNoCancelledAppointments.Visibility = Visibility.Collapsed;
                dataGridCancelledAppointments.Visibility = Visibility.Visible;
            }
        }
    }
}
