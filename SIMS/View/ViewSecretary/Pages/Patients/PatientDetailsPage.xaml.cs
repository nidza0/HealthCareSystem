using SIMS.Model.UserModel;
using SIMS.View.ViewSecretary.Pages.Doctors;
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

namespace SIMS.View.ViewSecretary.Pages.Patients
{

    public partial class PatientDetailsPage : Page
    {
        PatientViewModel patientVM;
        public PatientDetailsPage(Patient p)
        {
            InitializeComponent();
            patientVM = new PatientViewModel(p);
            DataContext = patientVM;
            Refresh();
        }

        public PatientDetailsPage()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (FrameManager.getInstance().SideFrame.CanGoBack)
                FrameManager.getInstance().SideFrame.GoBack();

        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Open send message frame
            User recipient = (User)patientVM.Patient;
        }

        private void btnEditPatient_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Open edit patient frame
        }

        public void Refresh()
        {
            if (patientVM.Patient != null)
            {
                if(patientVM.Patient.SelectedDoctor != null)
                {
                    SelectedDoctorPanel.Visibility = Visibility.Visible;
                    SelectedDoctorPanelError.Visibility = Visibility.Hidden;
                }
                else
                {
                    SelectedDoctorPanel.Visibility = Visibility.Hidden;
                    SelectedDoctorPanelError.Visibility = Visibility.Visible;
                }
            }
        }

        private void btnSelectedDoctorDetails_Click(object sender, RoutedEventArgs e)
        {
            Doctor selectedDoctor = patientVM.Patient.SelectedDoctor;
            if (selectedDoctor != null)
            {
                FrameManager.getInstance().SideFrame.Navigate(new DoctorDetailsPage(selectedDoctor));
            }
        }
    }
}
