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
    /// Interaction logic for NewAppointment.xaml
    /// </summary>
    public partial class NewAppointment : UserControl
    {
        private DateTime date;
        private DateTime time;
        private Model.UserModel.Room room;
        private Model.PatientModel.AppointmentType type;
        private Model.UserModel.Patient patient;
        private double standardTime = 15;
        private StackPanel panel;
        private DataGrid dg;
        private List<Appointment> allAppointments;

        public NewAppointment(Patient selectedPatient, StackPanel panel, DataGrid dg, List<Appointment>allApps)
        {
            allAppointments = allApps;
            this.dg = dg;
            this.panel = panel;
            patient = selectedPatient;
            //this.Visibility = Visibility.Hidden;
            InitializeComponent();
            fillComboBoxes();
        }

        private void fillComboBoxes()
        {
            RoomsCombo.ItemsSource = AppResources.getInstance().roomRepository.GetAll().Select(room => room.RoomNumber);
            
        }

        private void TimePicker_TextChanged(object sender, TextChangedEventArgs e)
        {
            DateTime StartTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            if (!DateTime.TryParseExact(TimePicker.Text, "HH:mm", null, System.Globalization.DateTimeStyles.None, out time))
            {
                TimePicker.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 21, 0));
                TimePicker.BorderThickness = new Thickness(2);
            }
            else
            {
                TimePicker.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 66, 245, 75));
                TimePicker.BorderThickness = new Thickness(2);
                time = DateTime.ParseExact(TimePicker.Text, "HH:mm", null);
                Console.WriteLine(time.ToString());
            }
        }

        private void RoomsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            room = AppResources.getInstance().roomRepository.GetRoomByName(RoomsCombo.SelectedItem.ToString());
        }

        // TODO: obican doktor ne moze da zakaze operaciju
        private void TypeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TypeCombo.SelectedIndex == 0)
            {
                type = Model.PatientModel.AppointmentType.checkup;
            } else if(TypeCombo.SelectedIndex == 0)
            {
                type = Model.PatientModel.AppointmentType.operation;
            }
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TypeCombo.SelectedIndex == 1 && AppResources.getLoggedInUser().DocTypeEnum == Model.DoctorModel.DocTypeEnum.FAMILYMEDICINE)
            {
                MessageBoxButton button1 = MessageBoxButton.OK;
                string caption1 = "Nije moguće zakazati operacju";
                string messageBoxText1 = "Nije moguće zakazati operacju pošto niste specijalista.";
                MessageBox.Show(messageBoxText1, caption1, button1);
            }
            else
            {
                date = (DateTime)DatePicker.SelectedDate;
                DateTime StartTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                if (allAppointments.SingleOrDefault(app => app.TimeInterval.StartTime == time) == null)
                {


                    //AppResources.getInstance().appointmentRepository.Create(new Model.PatientModel.Appointment(AppResources.getLoggedInUser(), patient, room, type, new TimeInterval(time, time.AddMinutes(standardTime))));
                    //this.Visibility = Visibility.Hidden;
                    allAppointments.Add(new Model.PatientModel.Appointment(AppResources.getLoggedInUser(), patient, room, type, new TimeInterval(time, time.AddMinutes(standardTime))));

                    panel.Children.Remove(this);
                    dg.Items.Refresh();


                    MessageBoxButton button = MessageBoxButton.OK;
                    string caption = "Uspešno ste zakazali pregled";
                    string messageBoxText = "Uspešno ste zakazali pregled pacijentu.";
                    MessageBox.Show(messageBoxText, caption, button);
                }
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            panel.Children.Remove(this);
            //this.Visibility = Visibility.Hidden;
        }
    }
}
