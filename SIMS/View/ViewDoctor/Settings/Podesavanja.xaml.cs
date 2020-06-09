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

namespace SIMS.View.ViewDoctor.Settings
{
    /// <summary>
    /// Interaction logic for Podesavanja.xaml
    /// </summary>
    public partial class Podesavanja : Page
    {
        private enum notificationTypes
        {
            ADMIN,
            NEWMED,
            PATIENT,
            APPOINTMENT
        }

        private bool areNotificationsActive;
        private bool adminNotifications;
        private bool newMedNotifications;
        private bool patientRelatedNotifications;
        private bool appointmentNotifications;

        public Podesavanja()
        {
            InitializeComponent();
            setNotificationStatus();
        }

        private void setNotificationStatus()
        {
            if ((bool)CheckBox_Notifications.IsChecked)
            {
                areNotificationsActive = true;
            }
            else
            {
                areNotificationsActive = false;
            }

            updateFields();
        }

        private void updateFields()
        {
            if (!areNotificationsActive)
            {
                deactivateAllNotifications();
            }
            else
            {
                activateAllNotifications();
            }
        }

        private void deactivateAllNotifications()
        {
            //  Obavestenja za dodavanje novog leka
            newMedBtn.IsEnabled = false;
            CheckBox_NewMed.IsEnabled = false;

            //  Obavestenja od administracije
            adminBtn.IsEnabled = false;
            CheckBox_Admin.IsEnabled = false;

            //  Obavestenja za preglede
            appointmentBtn.IsEnabled = false;
            CheckBox_Appointments.IsEnabled = false;

            //  Obavestenja za pacijente
            patientBtn.IsEnabled = false;
            CheckBox_Patient.IsEnabled = false;
        }

        private void activateAllNotifications()
        {
            //  Obavestenja za dodavanje novog leka
            newMedBtn.IsEnabled = true;
            CheckBox_NewMed.IsEnabled = true;


            //  Obavestenja od administracije
            adminBtn.IsEnabled = true;
            CheckBox_Admin.IsEnabled = true;


            //  Obavestenja za preglede
            appointmentBtn.IsEnabled = true;
            CheckBox_Appointments.IsEnabled = true;

            //  Obavestenja za pacijente
            patientBtn.IsEnabled = true;
            CheckBox_Patient.IsEnabled = true;
        }

        private void updateNotificationStatus(notificationTypes type)
        {
            if (type == notificationTypes.ADMIN)
            {
                adminNotifications = (bool)CheckBox_Admin.IsEnabled;
            }
            else if (type == notificationTypes.NEWMED)
            {
                newMedNotifications = (bool)CheckBox_NewMed.IsEnabled;
            }
            else if (type == notificationTypes.APPOINTMENT)
            {
                appointmentNotifications = (bool)CheckBox_Appointments.IsEnabled;
            }
            else if (type == notificationTypes.PATIENT)
            {
                patientRelatedNotifications = (bool)CheckBox_Patient.IsEnabled;
            }
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
        }

        private void Notifications_Button_Click(object sender, RoutedEventArgs e)
        {
            CheckBox_Notifications.IsChecked = !CheckBox_Notifications.IsChecked;
            setNotificationStatus();

        }

        private void NewMed_Button_Click(object sender, RoutedEventArgs e)
        {
            CheckBox_NewMed.IsChecked = !CheckBox_NewMed.IsChecked;
            updateNotificationStatus(notificationTypes.NEWMED);
        }

        private void adminBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckBox_Admin.IsChecked = !CheckBox_Admin.IsChecked;
            updateNotificationStatus(notificationTypes.ADMIN);
        }

        private void patientBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckBox_Patient.IsChecked = !CheckBox_Patient.IsChecked;
            updateNotificationStatus(notificationTypes.PATIENT);
        }

        private void appointmentBtn_Click(object sender, RoutedEventArgs e)
        {
            CheckBox_Appointments.IsChecked = !CheckBox_Appointments.IsChecked;
            updateNotificationStatus(notificationTypes.APPOINTMENT);
        }

        private void Account_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Settings.PodesavanjeNaloga());
        }
    }
}
