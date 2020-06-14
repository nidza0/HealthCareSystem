using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
    /// Interaction logic for DemoDoctorsAdding1.xaml
    /// </summary>
    public partial class DemoDoctorsAdding1 : Page
    {
        private bool flag = false;

        public DemoDoctorsAdding1()
        {
            InitializeComponent();
            ComboInit();

            

            nextButton.IsEnabled = false;

            Function();
        }

        
        private async void Function()
        {
            await Task.Delay(1500);
            nameInput.Text = "Petar";
            await Task.Delay(2000);
            surnameInput.Text = "Petrovic";
            await Task.Delay(2000);
            middlenameInput.Text="Petar";
            await Task.Delay(2000);
            sexCombo.SelectedIndex = 0;
            await Task.Delay(2000);
            DatumPicker.SelectedDate = new DateTime(1980, 5, 15);
            await Task.Delay(2000);
            jmbgInput.Text = "1505980800123";
            await Task.Delay(2000);
            adressInput.Text = "Njegova ulica 12/Novi Sad/Vojvodina";

            await Task.Delay(2000);
            nextButton.IsEnabled = true;

            Sex yes;
            if (sexCombo.SelectedItem.Equals(Sex.MALE))
                yes = Sex.MALE;
            else
                yes = Sex.FEMALE;
            if (!flag)
                NavigationService.Navigate(new DemoAddingPage2(nameInput.Text, surnameInput.Text, middlenameInput.Text, yes, (DateTime)DatumPicker.SelectedDate, jmbgInput.Text, adressInput.Text));



        }

        private bool name = false;
        private bool surname = false;
        private bool middlename = false;
        private bool date = false;
        private bool jmbg = false;
        private bool address = false;

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
            if (!Regex.Match(name, "^[A-Z][a-zA-Z]*$").Success)
                return true;
            return false;
        }

        private void DatePicker_LostFocus(object sender, RoutedEventArgs e)
        {
            if (DatumPicker.SelectedDate >= new DateTime(1995, 1, 1))
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
            if (!Regex.Match(jmbgInput.Text, "^[0-9]{13}$").Success)
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

            if (!adressInput.Text.Equals(""))
            {
                string[] tokens = adressInput.Text.Split('/');
                if (tokens.Length == 3)
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

            NavigationService.Navigate(new DoctorAddingPage2(nameInput.Text, surnameInput.Text, middlenameInput.Text, yes, (DateTime)DatumPicker.SelectedDate, jmbgInput.Text, adressInput.Text));
        }

        private void checkButton()
        {
            if (name && surname && middlename && date && jmbg && address)
                nextButton.IsEnabled = true;
            else
                nextButton.IsEnabled = false;
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            NavigationService.Navigate(new ManagerMainPage());
        }
    }
}

