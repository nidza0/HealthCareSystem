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
using System.Windows.Shapes;
using SIMS.Model.UserModel;
using SIMS.Model.PatientModel;
using System.Collections.ObjectModel;
using SIMS.Util;
using SIMS.View.ViewPatient.Exceptions;

using System.Text.RegularExpressions;
using SIMS.View.ViewPatient.RepoSimulator;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Controller.UsersController;
using SIMS.Exceptions;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    /// 

    public partial class Registration : Window
    {

        private string firstName = "";
        private string lastName = "";
        private string middleName = "";
        private DateTime dateOfBirth;
        private string countryOfOrigin = "";
        private Sex gender;
        private string uidn = "";
        private string address = "";
        private string country = "";
        private string city = "";
        private string homePhone = "";
        private string mobilePhone = "";
        private string email = "";
        private string secondaryEmail = "";
        private string emergencyFirstName = "";
        private string emergencyLastName = "";
        private string emergencyPhoneNumber = "";
        private string emergencyEmail = "";
        private string username = "";
       

        private bool firstNameValid;
        private bool lastNameValid;
        private bool middleNameValid = true;
        private bool dateOfBirthValid;
        private bool uidnValid;
        private bool addressValid;
        private bool cityValid;
        private bool homePhoneValid = true;
        private bool mobilePhoneValid;
        private bool emailValid;
        private bool secondaryEmailValid = true;
        private bool emergencyFirstNameValid = true;
        private bool emergencyLastNameValid = true;
        private bool emergencyPhoneNumberValid = true;
        private bool emergencyEmailValid = true;
        private bool usernameValid;
        private bool passwordValid;
        private bool checkBoxValid;

        private Brush defaultBorderColor;


        private bool update;

        

        private ObservableCollection<string> countries;

        private UserRepo userRepo;


        public Registration(Patient patient)
        {
            userRepo = UserRepo.Instance;
            this.DataContext = this;
            FirstName = patient.Name;
            LastName = patient.Surname;
            MiddleName = patient.MiddleName;
            DateOfBirth = patient.DateOfBirth;
            CountryOfOrigin = "Srbija";
            Gender = patient.Sex;
            Address = patient.Address.Street;
            Country = patient.Address.Location.Country;
            HomePhone = patient.HomePhone;
            MobilePhone = patient.CellPhone;
            Email = patient.Email1;
            SecondaryEmail = patient.Email2;
            EmergencyFirstName = patient.EmergencyContact.Name;
            EmergencyLastName = patient.EmergencyContact.Surname;
            EmergencyPhoneNumber = patient.EmergencyContact.PhoneNumber;
            EmergencyEmail = patient.EmergencyContact.Email;
            Username = patient.UserName;
            Uidn = patient.Uidn;
            City = patient.Address.Location.City;

          
            InitializeComponent();

            passwordTextBox.Password = AppResources.getInstance().userController.GetByID(patient.GetId()).Password;
            cityTextBox.Text = patient.Address.Location.City;

            genderComboBox.ItemsSource = Enum.GetValues(typeof(Sex)).Cast<Sex>();
            countryComboBox.SelectedIndex = 0;
            countryOfOriginComboBox.SelectedIndex = (int)Gender;
            defaultBorderColor = firstNameTextBox.BorderBrush;

            termsCheckBox.IsChecked = true;
            checkBoxValid = true;


            termsCheckBox.IsEnabled = false;
            update = true;

            usernameTextBox.IsEnabled = false;
            //passwordTextBox.IsEnabled = false;
        }

        public Registration()
        {
            userRepo = UserRepo.Instance;
            this.DataContext = this;
            InitializeComponent();

            genderComboBox.ItemsSource = Enum.GetValues(typeof(Sex)).Cast<Sex>();
            countryComboBox.SelectedIndex = 0;
            countryOfOriginComboBox.SelectedIndex = 0;
            defaultBorderColor = firstNameTextBox.BorderBrush;


            dateOfBirthDatePicker.SelectedDate = new DateTime(1980, 1, 1);
        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string MiddleName { get => middleName; set => middleName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public string CountryOfOrigin { get => countryOfOrigin; set => countryOfOrigin = value; }
        public Sex Gender { get => gender; set => gender = value; }
        public string Uidn { get => uidn; set => uidn = value; }
        public string Address { get => address; set => address = value; }
        public string Country { get => country; set => country = value; }
        public string City { get => city; set => city = value; }
        public string HomePhone { get => homePhone; set => homePhone = value; }
        public string MobilePhone { get => mobilePhone; set => mobilePhone = value; }
        public string Email { get => email; set => email = value; }
        public string SecondaryEmail { get => secondaryEmail; set => secondaryEmail = value; }
        public string EmergencyFirstName { get => emergencyFirstName; set => emergencyFirstName = value; }
        public string EmergencyLastName { get => emergencyLastName; set => emergencyLastName = value; }
        public string EmergencyPhoneNumber { get => emergencyPhoneNumber; set => emergencyPhoneNumber = value; }
        public string EmergencyEmail { get => emergencyEmail; set => emergencyEmail = value; }
        public ObservableCollection<string> Countries {
            get
            {
                ObservableCollection<string> countriesList = new ObservableCollection<string>();

                foreach(string country in GetCountries())
                {
                    countriesList.Add(country);
                }

                return countriesList;
            }
            set => countries = value;
        }

        public string Username { get => username; set => username = value; }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            AppResources appResources = AppResources.getInstance();
            PatientController patientController = appResources.patientController;
            UserController userController = appResources.userController;
            if (update)
            {
                try {
                    Patient updatedPatient = new Patient(HomePage.loggedPatient.GetId(), Username, passwordTextBox.Password, DateTime.Now, FirstName, LastName, MiddleName, Gender, DateOfBirth, Uidn, new Address(Address, new Location(Country, City)), HomePhone, MobilePhone, Email, SecondaryEmail, new EmergencyContact(emergencyFirstName, EmergencyLastName, EmergencyEmail, EmergencyPhoneNumber), HomePage.loggedPatient.PatientType, HomePage.loggedPatient.SelectedDoctor);
                    patientController.Update(updatedPatient);
                    MessageBox.Show("Successfully changed profile!");
                }catch(InvalidUserException invalidUserException){
                    MessageBox.Show(invalidUserException.Message);
                }catch(NotUniqueException notUniqueException)
                {
                    MessageBox.Show(notUniqueException.Message);
                }
            }
            else
            {
                //call controller to register patient profile
                try {
                    patientController.Create(new Patient(Username, passwordTextBox.Password, FirstName, LastName, MiddleName, Gender, DateOfBirth, Uidn, new Address(Address, new Location(Country, City)), HomePhone, MobilePhone, Email, SecondaryEmail, new EmergencyContact(emergencyFirstName, EmergencyLastName, EmergencyEmail, EmergencyPhoneNumber), PatientType.GENERAL, null));
                    MessageBox.Show("Account successfully created, you can login now.");
                    this.Close();
                }catch (InvalidUserException invalidUserException)
                {
                    MessageBox.Show(invalidUserException.Message);
                }
                catch (NotUniqueException notUniqueException)
                {
                    MessageBox.Show(notUniqueException.Message);
                }



            }
        }


        private List<string> GetCountries()
        {
            List<string> retVal = new List<string>();

            retVal.Add("Srbija");
            retVal.Add("Bosna i Hercegovina");
            retVal.Add("Hrvatska");

            return retVal;
        }


        private void verifyForm()
        {
           if(submitButton != null)
            {
                if (formValid())
                    submitButton.IsEnabled = true;
                else
                    submitButton.IsEnabled = false;
            }
        }

        private bool formValid()
        {
            return firstNameValid
       && lastNameValid
       && middleNameValid
       && dateOfBirthValid
       && uidnValid
       && addressValid
       && cityValid
       && homePhoneValid
       && mobilePhoneValid
       && emailValid
       && secondaryEmailValid
       && emergencyFirstNameValid
       && emergencyLastNameValid
       && emergencyPhoneNumberValid
       && emergencyEmailValid
       && usernameValid
       && passwordValid
       && checkBoxValid;

    }

        private void FirstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(firstNameTextBox.Text, ValidationRegex.GetNameRegex());

            if (!match.Success)
            {
                firstNameValid = false;
                firstNameTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                firstNameValid = true;
                firstNameTextBox.BorderBrush = defaultBorderColor;
            }
            verifyForm();
        }

        private void DateOfBirthDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(dateOfBirthDatePicker.SelectedDate >= DateTime.Now.Date || dateOfBirthDatePicker.SelectedDate == null)
            {
                dateOfBirthValid = false;
                dateOfBirthDatePicker.BorderBrush = Brushes.Red;
            }
            else
            {
                dateOfBirthValid = true;
                dateOfBirthDatePicker.BorderBrush = defaultBorderColor;
            }

            verifyForm();
        }

        private void MiddleNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(middleNameTextBox.Text, ValidationRegex.GetNameRegex());

            if (match.Success || middleNameTextBox.Text == "")
            {
                
                middleNameValid = true;
                middleNameTextBox.BorderBrush = defaultBorderColor;
            }
            else
            {
                middleNameValid = false;
                middleNameTextBox.BorderBrush = Brushes.Red;
            }
            verifyForm();
        }

        private void LastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(lastNameTextBox.Text, ValidationRegex.GetNameRegex());

            if (!match.Success)
            {
                lastNameValid = false;
                lastNameTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                lastNameValid = true;
                lastNameTextBox.BorderBrush = defaultBorderColor;
            }
            verifyForm();
        }

        private void UidnTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(uidnTextBox.Text, ValidationRegex.GetUIDNRegex());

            if (!match.Success)
            {
                uidnValid = false;
                uidnTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                uidnValid = true;
                uidnTextBox.BorderBrush = defaultBorderColor;
            }
            verifyForm();
        }

        private void AddressTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(addressTextBox.Text, ValidationRegex.GetAddressRegex());

            if (!match.Success)
            {
                addressValid = false;
                addressTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                addressValid = true;
                addressTextBox.BorderBrush = defaultBorderColor;
            }
            verifyForm();
        }

        private void CityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(cityTextBox.Text, ValidationRegex.GetNameRegex());

            if (!match.Success)
            {
                cityValid = false;
               cityTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                cityValid = true;
                cityTextBox.BorderBrush = defaultBorderColor;
            }
            verifyForm();
        }

        private void HomePhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(homePhoneTextBox.Text, ValidationRegex.GetPhoneNumberRegex());

            if (match.Success || homePhoneTextBox.Text == "")
            {
                homePhoneValid = true;
                homePhoneTextBox.BorderBrush = defaultBorderColor;
            }
            else
            {
                homePhoneValid = false;
                homePhoneTextBox.BorderBrush = Brushes.Red;
                
            }
            verifyForm();
        }

        private void MobilePhoneTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(mobilePhoneTextBox.Text, ValidationRegex.GetPhoneNumberRegex());

            if (!match.Success)
            {
                mobilePhoneValid = false;
                mobilePhoneTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                mobilePhoneValid = true;
                mobilePhoneTextBox.BorderBrush = defaultBorderColor;
            }
            verifyForm();
        }

        private void EmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(emailTextBox.Text, ValidationRegex.GetEmailRegex());

            if (!match.Success)
            {
                emailValid = false;
                emailTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
               emailValid = true;
                emailTextBox.BorderBrush = defaultBorderColor;
            }
            verifyForm();
        }

        private void SecondaryEmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(secondaryEmailTextBox.Text, ValidationRegex.GetEmailRegex());

            if (match.Success || secondaryEmailTextBox.Text == "")
            {
                
                secondaryEmailValid = true;
                secondaryEmailTextBox.BorderBrush = defaultBorderColor;
            }
            else
            {
                secondaryEmailValid = false;
                secondaryEmailTextBox.BorderBrush = Brushes.Red;
            }
            verifyForm();
        }

        private void EmergencyFirstNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(emergencyFirstNameTextBox.Text, ValidationRegex.GetNameRegex());

            if (match.Success || emergencyFirstNameTextBox.Text == "")
            {

                emergencyFirstNameValid = true;
                emergencyFirstNameTextBox.BorderBrush = defaultBorderColor;
            }
            else
            {
                emergencyFirstNameValid = false;
                emergencyFirstNameTextBox.BorderBrush = Brushes.Red;
            }
            verifyForm();

        }

        private void EmergencyLastNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(emergencyLastNameTextBox.Text, ValidationRegex.GetNameRegex());

            if (match.Success || emergencyLastNameTextBox.Text == "")
            {

                emergencyLastNameValid = true;
                emergencyLastNameTextBox.BorderBrush = defaultBorderColor;
            }
            else
            {
                emergencyLastNameValid = false;
                emergencyLastNameTextBox.BorderBrush = Brushes.Red;
            }
            verifyForm();
        }

        private void EmergencyPhoneNumberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(emergencyPhoneNumberTextBox.Text, ValidationRegex.GetPhoneNumberRegex());

            if (match.Success || emergencyPhoneNumberTextBox.Text == "")
            {

                emergencyPhoneNumberValid = true;
                emergencyPhoneNumberTextBox.BorderBrush = defaultBorderColor;
            }
            else
            {
                emergencyPhoneNumberValid = false;
                emergencyPhoneNumberTextBox.BorderBrush = Brushes.Red;
            }
            verifyForm();
        }

        private void EmergencyEmailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(emergencyEmailTextBox.Text, ValidationRegex.GetEmailRegex());

            if (match.Success)
            {

                emergencyEmailValid = true;
                emergencyEmailTextBox.BorderBrush = defaultBorderColor;
            }
            else
            {
                emergencyEmailValid = false;
                emergencyEmailTextBox.BorderBrush = Brushes.Red;
            }
            verifyForm();
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(usernameTextBox.Text, ValidationRegex.GetUserNameRegex());

            if (!match.Success)
            {
                usernameValid = false;
                usernameTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                usernameValid = true;
                usernameTextBox.BorderBrush = defaultBorderColor;
            }
            verifyForm();
        }

        private void PasswordTextBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var match = Regex.Match(passwordTextBox.Password, ValidationRegex.GetPasswordRegex());

            if (!match.Success)
            {
                passwordValid = false;
                passwordTextBox.BorderBrush = Brushes.Red;
            }
            else
            {
                passwordValid = true;
                passwordTextBox.BorderBrush = defaultBorderColor;
            }
            verifyForm();
        }

        private void TermsCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)termsCheckBox.IsChecked)
            {
                checkBoxValid = true;
            }
            else
            {
                checkBoxValid = false;
            }

            verifyForm();
        }
    }
}
