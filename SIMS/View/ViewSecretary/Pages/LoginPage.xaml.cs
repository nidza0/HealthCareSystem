using SIMS.Model.UserModel;
using SIMS.Service.UsersService;
using SIMS.View.ViewSecretary.ViewModel;
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

namespace SIMS.View.ViewSecretary.Pages
{

    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = passwordBox.Password.ToString();
            
            try
            {
                AppResources.getInstance().userController.Login(username, password);
                User loggedUser = AppResources.getInstance().loggedInUser;
                UserViewModel.GetInstance().LoggedInUser = AppResources.getInstance().secretaryController.GetByID(loggedUser.GetId());
                FrameManager.getInstance().MainFrame.Navigate(new MainWindowPage());
            }
            catch(InvalidLoginException ex)
            {
                MessageBox.Show(ex.Message, "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            /*
            User user = SecretaryAppResources.GetInstance().userRepository.GetByUsername(username);

            if(user == null)
            {
                errLogin.Visibility = Visibility.Visible;
                return;
            }

            if(user.Password != password)
            {
                errLogin.Visibility = Visibility.Visible;
                return;
            }

            errLogin.Visibility = Visibility.Collapsed;
            UserViewModel.GetInstance().LoggedInUser = SecretaryAppResources.GetInstance().secretaryRepository.GetEager(user.GetId());
            
            //NAVIGATE TO MAIN WINDOW

            FrameManager.getInstance().MainFrame.Navigate(new MainWindowPage());
            */
        }
    }
}
