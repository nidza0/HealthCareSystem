using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for PageAddingPage.xaml
    /// </summary>
    public partial class PageAddingPage : Page
    {
        private bool name = false;
        private bool surname = false;
        private bool middlename = false;
        private bool date = false;
        private bool jmbg = false;
        private bool address = false;

        public PageAddingPage()
        {
            InitializeComponent();

            

            ComboInit();

            nextButton.IsEnabled = false;
        }

        private void ComboInit()
        {
            sexCombo.Items.Add("Muški");
            sexCombo.Items.Add("Ženski");
            sexCombo.SelectedIndex = 0;

        }

        private void nameInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (verifyName(nameInput.Text.ToString()))
            {
                nameInput.Background = Brushes.PaleVioletRed;
                name = false;
            }
            else
            {
                nameInput.Background = Brushes.Transparent;
                name = true;
                checkButton();
            }
                
        }

        

        private void surnameInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (verifyName(surnameInput.Text.ToString()))
            {
                surnameInput.Background = Brushes.PaleVioletRed;
                surname = false;
            }
            else
            {
                surnameInput.Background = Brushes.Transparent;
                surname = true;
                checkButton();
            }
                
        }

        private void middlenameInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (verifyName(middlenameInput.Text.ToString()))
            {
                middlenameInput.Background = Brushes.PaleVioletRed;
                middlename = false;
            }    
            else
            {
                middlenameInput.Background = Brushes.Transparent;
                middlename = true;
                checkButton();
            }
        }

        private bool verifyName(string name)
        {
            if (!Regex.Match(name, Regexes.nameRegex).Success)
                return true;
            return false;
        }

        private void DatePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DatumPicker.SelectedDate >= new DateTime(1995,1,1))
            {
                DatumPicker.Background = Brushes.PaleVioletRed;
                date = false;
            }
            else
            {
                DatumPicker.Background = Brushes.Transparent;
                date = true;
                checkButton();
            }
        }

        private void jmbgInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!Regex.Match(jmbgInput.Text, Regexes.uidnRegex).Success)
            {
                jmbgInput.Background = Brushes.PaleVioletRed;
                jmbg = false;
            } 
            else
            {
                jmbgInput.Background = Brushes.Transparent;
                jmbg = true;
                checkButton();
            }
        }

        private void adressInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (adressInput.Text.Equals(""))
                adressInput.Text = "ulica/grad/drzava";

            if(!adressInput.Text.Equals(""))
            {
                string[] tokens = adressInput.Text.Split('/');
                if(tokens.Length == 3)
                {

                    if (verifyAddress(tokens[0]) && verifyAddress(tokens[1]) && verifyAddress(tokens[2]))
                    {
                        adressInput.Background = Brushes.Transparent;
                        address = true;
                        checkButton();
                    }
                    else
                    {
                        adressInput.Background = Brushes.PaleVioletRed;
                        adressInput.Text = "ulica/grad/drzava";
                        address = false;
                    }
                }
                else
                {
                    adressInput.Background = Brushes.PaleVioletRed;
                    adressInput.Text = "ulica/grad/drzava";
                    address = false;
                }

            }
        }

        private void adressInput_GotFocus(object sender, RoutedEventArgs e)
        {
            if (adressInput.Text.Equals("ulica/grad/drzava"))
                adressInput.Text = "";
        }

        private bool verifyAddress(string address)
        {
            if (!Regex.Match(address, "^([a-zA-Z 0-9]*)$").Success)
                return false;
            return true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sex yes;
            if (sexCombo.SelectedItem.Equals(Sex.MALE))
                yes = Sex.MALE;
            else
                yes = Sex.FEMALE;

            NavigationService.Navigate(new DoctorAddingPage2(nameInput.Text ,surnameInput.Text, middlenameInput.Text, yes,(DateTime) DatumPicker.SelectedDate, jmbgInput.Text, adressInput.Text));
        }

        private void checkButton()
        {
            if (name && surname && middlename && date && jmbg && address)
                nextButton.IsEnabled = true;
            else
                nextButton.IsEnabled = false;
        }
    }
}
