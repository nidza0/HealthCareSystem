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

using SIMS.View;

using System.Text.RegularExpressions;
using SIMS.Model.UserModel;
using SIMS.View.ViewPatient.Exceptions;
using SIMS.View.ViewPatient.RepoSimulator;
using SIMS.Service.UsersService;
using SIMS.Util;
using SIMS.Model.DoctorModel;
using SIMS.Model.PatientModel;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        private ValidationRegex validationRegex;
        private UserRepo userRepo;
        private bool usernameValid;
        private bool passwordValid;

        private Brush defaultBorderColor;
        public Login()
        {
            validationRegex = new ValidationRegex();
            userRepo = UserRepo.Instance;
            InitializeComponent();
            defaultBorderColor = username.BorderBrush;


        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.username.Text = "";
            this.password.Password = "";
            confirmButton.IsEnabled = false;
            usernameValid = false;
            passwordValid = false;

        }


        private void verifyForm()
        {
            if (confirmButton != null)
            {
                if (formValid())
                    confirmButton.IsEnabled = true;
                else
                    confirmButton.IsEnabled = false;
            }
        }

        private bool formValid()
        {
            return usernameValid && passwordValid;

        }


        private void ConfirmButton_Click_1(object sender, RoutedEventArgs e)
        {
            String username = this.username.Text;
            String password = this.password.Password;

            //TODO: Check if username and password valid.
            AppResources appResources = AppResources.getInstance(); 
            try
            {
                appResources.userController.Login(username, password);
                HomePage homePage = new HomePage(appResources.loggedInUser);
                homePage.WindowState = WindowState.Maximized;

                this.Close();
                homePage.Show();
            }
            catch(InvalidLoginException invalidLoginException)
            {
                MessageBox.Show(invalidLoginException.Message);
            }
        }

        private void validateInput(object sender, TextChangedEventArgs e)
        {
            var match = Regex.Match(username.Text, ValidationRegex.GetUserNameRegex());

            if (!match.Success)
            {
                usernameValid = false;
                username.BorderBrush = Brushes.Red;
            }
            else
            {
                usernameValid = true;
                username.BorderBrush = defaultBorderColor;
            }
            verifyForm();
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var match = Regex.Match(password.Password, ValidationRegex.GetPasswordRegex());

            if (!match.Success)
            {
                passwordValid = false;
                password.BorderBrush = Brushes.Red;
            }
            else
            {
                passwordValid = true;
                password.BorderBrush = defaultBorderColor;
            }
            verifyForm();
        }

        private void RegisterLinkClick(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            VideoTutorial videoTutorial = new VideoTutorial();
            videoTutorial.Show();
        }


        

        private void appointmentsData()
        {
          
        }
    }
}
