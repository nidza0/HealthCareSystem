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

        public NewAppointment(Patient selectedPatient)
        {
            patient = selectedPatient;
            this.Visibility = Visibility.Hidden;
            InitializeComponent();
            fillComboBoxes();
        }

        private void fillComboBoxes()
        {
            RoomsCombo.ItemsSource = AppResources.getInstance().roomRepository.GetAll();
            
        }

        private void TimePicker_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(!DateTime.TryParse(TimePicker.Text, out time))
            {
                TimePicker.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 21, 0));
                TimePicker.BorderThickness = new Thickness(2);
            }
        }

        private void RoomsCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            room = (Model.UserModel.Room) RoomsCombo.SelectedItem;
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
            date = (DateTime) DatePicker.SelectedDate;
            AppResources.getInstance().appointmentRepository.Create(new Model.PatientModel.Appointment(AppResources.getLoggedInUser(), patient, room, type, new TimeInterval(time, time.AddMinutes(standardTime))));
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}
