using SIMS.Model.UserModel;
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

namespace SIMS.View.ViewSecretary.Pages.Doctors
{
    /// <summary>
    /// Interaction logic for DoctorDetailsPage.xaml
    /// </summary>
    public partial class DoctorDetailsPage : Page
    {
        DoctorViewModel doctorVM;
        public DoctorDetailsPage()
        {
            InitializeComponent();
        }
        public DoctorDetailsPage(Doctor doctor)
        {
            InitializeComponent();
            doctorVM = new DoctorViewModel(doctor);
            DataContext = doctorVM;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (FrameManager.getInstance().SideFrame.CanGoBack)
                FrameManager.getInstance().SideFrame.GoBack();
        }

        private void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Open send message frame
            User recipient = (User)doctorVM.Doctor;
        }

        private void dataGridAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridAppointments_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Add row number
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
