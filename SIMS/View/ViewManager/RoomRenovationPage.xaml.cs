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

namespace SIMS.View.ViewManager
{
    /// <summary>
    /// Interaction logic for RoomRenovationPage.xaml
    /// </summary>
    public partial class RoomRenovationPage : Page
    {
        private bool pPicker = false;
        private bool kPicker = false;
        private bool pCombo = false;
        private bool kCombo = false;
        private bool tip = false;
        private DateTime start;
        private DateTime end;

        Room sRoom;
        public RoomRenovationPage(Room room)
        {
            InitializeComponent();
            sRoom = room;

            initCombos();

            reserveButton.IsEnabled = false;
        }

        private void initCombos()
        {
            for (int i = 0; i < 24; i++)
            {
                pocetakCombo.Items.Add(i.ToString() + ":00");
                pocetakCombo.Items.Add(i.ToString() + ":30");
                krajCombo.Items.Add(i.ToString() + ":00");
                krajCombo.Items.Add(i.ToString() + ":30");
            }

            tipCombo.Items.Add("Operaciona sala");
            tipCombo.Items.Add("Sala za pregede");
            tipCombo.Items.Add("Soba za oporavak");

            tipCombo.SelectedIndex = 1;

            pocetakCombo.SelectedIndex = 0;
            krajCombo.SelectedIndex = 0;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void reserveButton_Click(object sender, RoutedEventArgs e)
        {
            if(proveriVreme())
            {
                Appointment appointment = new Appointment(420, null, null, sRoom, AppointmentType.renovation, new Util.TimeInterval(start,end));
                Console.WriteLine("uspesno rezervisano");
                Login.appointments.Add(appointment);

                NavigationService.Navigate(new RoomTimetable(sRoom));
            }
            else
            {
                pPicker = false;
                kPicker = false;
                pCombo = false;
                kCombo = false;

                krajPicker.Background = Brushes.PaleVioletRed;
                pocetakPicker.Background = Brushes.PaleVioletRed;
                pocetakCombo.Background = Brushes.PaleVioletRed;
                krajCombo.Background = Brushes.PaleVioletRed;

                checkButton();
            }
        }

        private void krajPicker_LostFocus(object sender, RoutedEventArgs e)
        {
            if(pocetakPicker.SelectedDate.HasValue && krajPicker.SelectedDate.HasValue)
            {
                if (DateTime.Compare(DateTime.Now, (DateTime)krajPicker.SelectedDate) <= 0 && DateTime.Compare((DateTime)krajPicker.SelectedDate, (DateTime)pocetakPicker.SelectedDate) >= 0)
                {
                    krajPicker.Background = Brushes.Transparent;
                    kPicker = true;
                    checkButton();
                }
                else
                {
                    krajPicker.Background = Brushes.PaleVioletRed;
                    kPicker = false;
                }
            }
        }

        private void pocetakPicker_LostFocus(object sender, RoutedEventArgs e)
        {
            if(pocetakPicker.SelectedDate.HasValue)
            {
                if (DateTime.Compare(DateTime.Now, (DateTime)pocetakPicker.SelectedDate) >= 0)
                {
                    pocetakPicker.Background = Brushes.PaleVioletRed;
                    pPicker = false;
                }
                else
                {
                    pocetakPicker.Background = Brushes.Transparent;
                    pPicker = true;
                    checkButton();
                }
            }
            
        }

        private void tipCombo_LostFocus(object sender, RoutedEventArgs e)
        {
            tip = true;
            checkButton();
        }

        private void krajCombo_LostFocus(object sender, RoutedEventArgs e)
        {
            krajCombo.Background = Brushes.Transparent;
            kCombo = true;
            checkButton();
        }

        private void pocetakCombo_LostFocus(object sender, RoutedEventArgs e)
        {
            pocetakCombo.Background = Brushes.Transparent;
            pCombo = true;
            checkButton();
        }

        private bool proveriVreme()
        {
            DateTime selectedBegin = (DateTime)pocetakPicker.SelectedDate;

            DateTime selectedEnd = (DateTime) krajPicker.SelectedDate;

            String[] selectedComboBegin = pocetakCombo.SelectedItem.ToString().Split(':');
            String[] selectedComboEnd = krajCombo.SelectedItem.ToString().Split(':');

            selectedBegin = selectedBegin.AddHours(double.Parse(selectedComboBegin[0]));
            selectedBegin = selectedBegin.AddMinutes(double.Parse(selectedComboBegin[1]));

            selectedEnd = selectedEnd.AddHours(double.Parse(selectedComboEnd[0]));
            selectedEnd = selectedEnd.AddMinutes(double.Parse(selectedComboEnd[1]));

            if (DateTime.Compare(selectedBegin, selectedEnd) < 0)
            {
                start = selectedBegin;
                end = selectedEnd;
                return true;
            }
            return false;
        }

        private void checkButton()
        {
            if (pCombo && pPicker && kCombo && kPicker && tip)
            {

                reserveButton.IsEnabled = true;
            }
            else
                reserveButton.IsEnabled = false;
        }
    }
}
