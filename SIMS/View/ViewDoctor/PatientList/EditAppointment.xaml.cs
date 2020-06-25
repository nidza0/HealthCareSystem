using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
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
    /// Interaction logic for EditAppointment.xaml
    /// </summary>
    public partial class EditAppointment : UserControl
    {
        Appointment appointment;

        private DateTime date;
        private DateTime time;
        private Model.UserModel.Room room;
        private Model.PatientModel.AppointmentType type;
        private Model.UserModel.Patient patient;
        private double standardTime = 15;
        private StackPanel panel;
        private DataGrid dg;
        private List<Appointment> apps;
        public EditAppointment(Appointment selected, StackPanel panel, DataGrid dg, List<Appointment> allApps)
        {
            apps = allApps;
            this.dg = dg;
            this.panel = panel;
            appointment = selected;
            InitializeComponent();
            fillComboBoxes();
            fillData();
        }

        private void fillData()
        {
            DatePicker.SelectedDate = appointment.TimeInterval.StartTime;
            TimePicker.Text = appointment.TimeInterval.StartTime.ToString("HH:mm");
            RoomsCombo.SelectedItem = appointment.Room;
            TypeCombo.SelectedIndex = (int)appointment.AppointmentType;
        }

        private void fillComboBoxes()
        {
            RoomsCombo.ItemsSource = AppResources.getInstance().roomController.GetAll();

        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if(TypeCombo.SelectedIndex == 1 && AppResources.getLoggedInUser().DocTypeEnum == Model.DoctorModel.DocTypeEnum.FAMILYMEDICINE)
            {
                MessageBoxButton button1 = MessageBoxButton.OK;
                string caption1 = "Nije moguće zakazati operacju";
                string messageBoxText1 = "Nije moguće zakazati operacju pošto niste specijalista.";
                MessageBox.Show(messageBoxText1, caption1, button1);
            } else { 
            apps.Remove(appointment);
            appointment.AppointmentType = type;
            appointment.TimeInterval.StartTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            appointment.TimeInterval.EndTime = appointment.TimeInterval.StartTime.AddMinutes(15);
            appointment.Room = room;
            apps.Add(appointment);

            AppResources.getInstance().appointmentController.Update(appointment);
            panel.Children.Remove(this);

            dg.Items.Refresh();

            MessageBoxButton button = MessageBoxButton.OK;
            string caption = "Uspešno ste izmenili pregled";
            string messageBoxText = "Uspešno ste izmenili pregled pacijentu.";
            MessageBox.Show(messageBoxText, caption, button);
            }
        }

        private void TypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            type = (AppointmentType)TypeCombo.SelectedIndex;
        }

        private void RoomsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            room = (Room)RoomsCombo.SelectedItem;
        }

        private void TimePicker_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!DateTime.TryParse(TimePicker.Text, out time))
            {
                TimePicker.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 21, 0));
                TimePicker.BorderThickness = new Thickness(2);
            }
        }
    }
}
