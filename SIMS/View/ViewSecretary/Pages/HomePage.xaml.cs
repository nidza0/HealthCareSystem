using iText.Html2pdf;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.View.ViewSecretary.Pages.Appointments;
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

namespace SIMS.View.ViewSecretary.Pages
{

    public partial class HomePage : Page
    {
        private ChartData chartData = new ChartData();
        private AppointmentsViewModel appointmentsVM = new AppointmentsViewModel();
        private DoctorsViewModel doctorsVM = new DoctorsViewModel();
        public HomePage()
        {
            InitializeComponent();
            chartData.LoadRoomChart();
            chartRooms.DataContext = chartData;
            dataGridAppointments.DataContext = appointmentsVM;
            appointmentsVM.LoadCurrentAppointments();
            dataGridDoctors.DataContext = doctorsVM;
            doctorsVM.LoadDoctorsAtWork();
        }

        private void dataGridAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Appointment selected = dataGridAppointments.SelectedItem as Appointment;
            if(selected != null)
            {
                FrameManager.getInstance().SideFrame.Navigate(new AppointmentDetailsPage(selected));
            }
        }

        private void dataGridAppointments_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Add row number
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void dataGridDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Doctor selected = dataGridDoctors.SelectedItem as Doctor;
            if(selected != null)
            {
                FrameManager.getInstance().SideFrame.Navigate(new DoctorDetailsPage(selected));
            }
        }

        private void dataGridDoctors_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Add row number
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
