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
    /// Interaction logic for PodesavanjeNaloga.xaml
    /// </summary>
    public partial class PodesavanjeNaloga : Page
    {

        private string examplePassword = "LukaKrickovic";
        private string currentPassword;
        private izmeniBtnStatus stanje;
        private izmeniBtnStatus ime;
        private izmeniBtnStatus prz;


        private enum izmeniBtnStatus
        {
            IZMENI,
            POTVRDI
        }

        public PodesavanjeNaloga()
        {
            InitializeComponent();
            currentPassword = examplePassword;
            disableHiddenFields();
            Email_TextBox.IsEnabled = false;
            Name_TextBox.IsEnabled = false;
            Surname_TextBox.IsEnabled = false;

            stanje = izmeniBtnStatus.IZMENI;
            ime = izmeniBtnStatus.IZMENI;
            prz = izmeniBtnStatus.IZMENI;

        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Podesavanja());
        }


        private void PasswordCheckBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPasswordBox.Password == currentPassword)
            {
                enableHiddenFields();
            }
        }

        private void enableHiddenFields()
        {
            NewPass_TextBlock.Visibility = Visibility.Visible;
            NewPass_TextBox.Visibility = Visibility.Visible;

            Confirm_TextBlock.Visibility = Visibility.Visible;
            Confirm_TextBox.Visibility = Visibility.Visible;
            ConfirmPasswordBtn.Visibility = Visibility.Visible;
        }

        private void disableHiddenFields()
        {
            NewPass_TextBlock.Visibility = Visibility.Hidden;
            NewPass_TextBox.Visibility = Visibility.Hidden;

            Confirm_TextBlock.Visibility = Visibility.Hidden;
            Confirm_TextBox.Visibility = Visibility.Hidden;
            ConfirmPasswordBtn.Visibility = Visibility.Hidden;
        }


        private void ConfirmPasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (NewPass_TextBox.Password == Confirm_TextBox.Password)
            {
                currentPassword = NewPass_TextBox.Password;
                MessageBoxButton button = MessageBoxButton.OK;
                string caption = "Izmenjena šifra";
                string messageBoxText = "Izmenili ste šifru.";
                MessageBox.Show(messageBoxText, caption, button);
            }
            else
            {
                MessageBoxButton button = MessageBoxButton.OK;
                string caption = "Ne poklapaju se šifre";
                string messageBoxText = "Ne poklapaju se šifre koje ste uneli. Pokušajte ponovo.";
                MessageBox.Show(messageBoxText, caption, button);
                NewPass_TextBox.Password = "";
                Confirm_TextBox.Password = "";
            }

        }

        private void IzmeniBtn_Click(object sender, RoutedEventArgs e)
        {
            if (stanje == izmeniBtnStatus.IZMENI)
            {
                IzmeniBtn.Content = "Potvrdi";
                Email_TextBox.IsEnabled = true;
                stanje = izmeniBtnStatus.POTVRDI;
            }
            else
            {
                MessageBoxButton button = MessageBoxButton.OK;
                string caption = "Izmenjen email";
                string messageBoxText = "Izmenili ste email.";
                MessageBox.Show(messageBoxText, caption, button);
                IzmeniBtn.Content = "Izmeni";
                Email_TextBox.IsEnabled = false;
                stanje = izmeniBtnStatus.IZMENI;
            }
        }

        private void SurameIzmeniBtn_Click(object sender, RoutedEventArgs e)
        {
            if (prz == izmeniBtnStatus.IZMENI)
            {
                SurameIzmeniBtn.Content = "Potvrdi";
                Surname_TextBox.IsEnabled = true;
                prz = izmeniBtnStatus.POTVRDI;

            }
            else
            {
                MessageBoxButton button = MessageBoxButton.OK;
                string caption = "Izmenjeno prezime";
                string messageBoxText = "Izmenili ste prezime.";
                MessageBox.Show(messageBoxText, caption, button);
                SurameIzmeniBtn.Content = "Izmeni";
                Surname_TextBox.IsEnabled = false;
                prz = izmeniBtnStatus.IZMENI;
            }
        }

        private void NameChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ime == izmeniBtnStatus.IZMENI)
            {
                NameChangeBtn.Content = "Potvrdi";
                Name_TextBox.IsEnabled = true;
                ime = izmeniBtnStatus.POTVRDI;

            }
            else
            {
                MessageBoxButton button = MessageBoxButton.OK;
                string caption = "Izmenjeno ime";
                string messageBoxText = "Izmenili ste ime.";
                MessageBox.Show(messageBoxText, caption, button);
                NameChangeBtn.Content = "Izmeni";
                Name_TextBox.IsEnabled = false;
                ime = izmeniBtnStatus.IZMENI;
            }
        }




    }
}
