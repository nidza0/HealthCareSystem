using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.View.ViewSecretary.Pages.Doctors;
using SIMS.View.ViewSecretary.Pages.Patients;
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
    /// Interaction logic for AppointmentDetailsPage.xaml
    /// </summary>
    public partial class AppointmentDetailsPage : Page
    {
        public AppointmentDetailsPage()
        {
            InitializeComponent();
        }

        private AppointmentViewModel appointmentVM;

        public AppointmentDetailsPage(Appointment a)
        {
            InitializeComponent();
            appointmentVM = new AppointmentViewModel(a);
            DataContext = appointmentVM;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (FrameManager.getInstance().SideFrame.CanGoBack)
                FrameManager.getInstance().SideFrame.GoBack();
        }

        private void DoctorDetails_Click(object sender, RoutedEventArgs e)
        {
            Doctor selectedDoctor = appointmentVM.Appointment.DoctorInAppointment;
            if (selectedDoctor != null)
            {
                FrameManager.getInstance().SideFrame.Navigate(new DoctorDetailsPage(selectedDoctor));
            }
        }

        private void PatientDetails_Click(object sender, RoutedEventArgs e)
        {
            Patient selectedPatient = appointmentVM.Appointment.Patient;
            if (selectedPatient != null)
            {
                FrameManager.getInstance().SideFrame.Navigate(new PatientDetailsPage(selectedPatient));
            }
        }
    }
}
