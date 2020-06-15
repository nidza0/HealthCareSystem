using SIMS.Model.UserModel;
using SIMS.View.ViewDoctor.Forms;
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

namespace SIMS.View.ViewDoctor.Functions
{
    /// <summary>
    /// Interaction logic for UputZaStacionarno.xaml
    /// </summary>
    public partial class UputZaStacionarno : Page
    {
        private DateTime vremeKontrole;
        private string nalaz;
        private string nijeZadrzanZbog;
        private Patient patient;
        private DateTime time;
        public UputZaStacionarno(Patient selected)
        {
            patient = selected;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new OdaberiPacijenta(OdaberiPacijenta.sources.STACIONARNO));
            this.NavigationService.GoBack();
        }

        private void CANCEL_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            
            if(DateTime.TryParseExact(TimeTextBox.Text, "HH:mm", null, System.Globalization.DateTimeStyles.None, out time)) { 
                NavigationService.Navigate(new MainPageCenter());
                MessageBoxButton button = MessageBoxButton.OK;
                string caption = "Uspešno ste izdali uput";
                string messageBoxText = "Uspešno ste izdali uput za stacionarno lečenje.";
                MessageBox.Show(messageBoxText, caption, button);
            } else
            {
                MessageBoxButton button = MessageBoxButton.OK;
                string caption = "Niste uneli validno vreme";
                string messageBoxText = "Vreme mora biti u formatu HH:mm.";
                MessageBox.Show(messageBoxText, caption, button);
            }
        }

        private void fillRemaining()
        {
            nalaz = Nalaz_TextBox.Text;
            nijeZadrzanZbog = Razlog_TextBox.Text;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void NowButton_Click(object sender, RoutedEventArgs e)
        {
            //NowCheckBox.IsChecked = !NowCheckBox.IsChecked;
            //disableOrEnableDateInput((bool) NowCheckBox.IsChecked);
        }

        

        private void TimeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!DateTime.TryParseExact(TimeTextBox.Text, "HH:mm", null, System.Globalization.DateTimeStyles.None, out time))
            {
                TimeTextBox.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 255, 21, 0));
                TimeTextBox.BorderThickness = new Thickness(2);
            }
            else
            {
                TimeTextBox.BorderBrush = new SolidColorBrush(Color.FromArgb(100, 66, 245, 75));
                TimeTextBox.BorderThickness = new Thickness(2);
                //time = DateTime.ParseExact(TimePicker.Text, "HH:mm", null);
                //Console.WriteLine(time.ToString());
            }
        }
    }
}
