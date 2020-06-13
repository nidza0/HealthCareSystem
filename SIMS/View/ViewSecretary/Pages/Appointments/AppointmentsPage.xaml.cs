using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Util;
using SIMS.View.ViewSecretary.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace SIMS.View.ViewSecretary.Pages.Appointments
{
    /// <summary>
    /// Interaction logic for AppointmentsPageSecretary.xaml
    /// </summary>
    public partial class AppointmentsPage : Page
    {
        private DateTime previousDate = new DateTime();

        AppointmentsViewModel appointmentsVM = new AppointmentsViewModel();

        private static AppointmentsPage instance = null;

        public static AppointmentsPage GetInstance()
        {
            if (instance == null)
                instance = new AppointmentsPage();
            return instance;
        }
        private AppointmentsPage()
        {
            InitializeComponent();
            DataContext = appointmentsVM;
            AppointmentDate.SelectedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void dataGridAppointments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Appointment selectedAppointment = (Appointment)dataGridAppointments.SelectedItem;
            if (selectedAppointment != null)
            {
                if(selectedAppointment.AppointmentType == AppointmentType.free)
                {
                    //TODO new appointment with room and time interval
                    FrameManager.getInstance().SideFrame.Navigate(new CreateUpdateAppointmentPage(selectedAppointment.TimeInterval, selectedAppointment.Room));

                }
                else
                {
                    FrameManager.getInstance().SideFrame.Navigate(new AppointmentDetailsPage(selectedAppointment));
                }
            }
        }

        private void dataGridAppointments_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Add row number
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }

        private void btnYesterday_Click(object sender, RoutedEventArgs e)
        {
            AppointmentDate.SelectedDate = AppointmentDate.SelectedDate.Value.AddDays(-1);
        }

        private void btnTomorrow_Click(object sender, RoutedEventArgs e)
        {
            AppointmentDate.SelectedDate = AppointmentDate.SelectedDate.Value.AddDays(1);
        }

        private void AppointmentDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DatePicker picker = (DatePicker)sender;
            if (!previousDate.Equals(picker.SelectedDate.Value))
            {
                Console.WriteLine(picker.SelectedDate);
                previousDate = picker.SelectedDate.Value;

                Room selectedRoom = (Room)cbRooms.SelectedItem;
                if (selectedRoom == null)
                {
                    appointmentsVM.LoadAppointments(AppointmentDate.SelectedDate.Value);
                    dataGridAppointments.Items.Refresh();
                    checkAppointments();
                }
                else
                {
                    appointmentsVM.LoadAppointmentsByRoomWithFreeTime(AppointmentDate.SelectedDate.Value, selectedRoom);
                    dataGridAppointments.Items.Refresh();
                    checkAppointments();
                }
            }
        }

        private void SortDataGrid()
        {
            dataGridAppointments.Items.SortDescriptions.Clear();
            dataGridAppointments.Items.SortDescriptions.Add(new SortDescription("Start Time", ListSortDirection.Ascending));
            dataGridAppointments.Items.Refresh();
        }

        private void checkAppointments()
        {
            if(appointmentsVM.Appointments.Count == 0)
            {
                errNoAppointments.Visibility = Visibility.Visible;
                dataGridAppointments.Visibility = Visibility.Collapsed;
            }
            else
            {
                errNoAppointments.Visibility = Visibility.Collapsed;
                dataGridAppointments.Visibility = Visibility.Visible;
            }
        }

        public void Refresh()
        {
            appointmentsVM.LoadAppointments(AppointmentDate.SelectedDate.Value);
            dataGridAppointments.Items.Refresh();
            //SortDataGrid();
            checkAppointments();
        }

        private void cbRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room selectedRoom = (Room)cbRooms.SelectedItem;
            if(selectedRoom == null)
            {
                appointmentsVM.LoadAppointments(AppointmentDate.SelectedDate.Value);
                dataGridAppointments.Items.Refresh();
                checkAppointments();
            }
            else
            {
                Console.WriteLine("Combobox selected room: " + selectedRoom.GetId());
                appointmentsVM.LoadAppointmentsByRoomWithFreeTime(AppointmentDate.SelectedDate.Value, selectedRoom);
                dataGridAppointments.Items.Refresh();
                checkAppointments();
            }
        }

        private void btnAllRooms_Click(object sender, RoutedEventArgs e)
        {
            cbRooms.SelectedItem = null;
        }
    }
}
