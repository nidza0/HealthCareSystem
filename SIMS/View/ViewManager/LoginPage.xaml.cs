using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {

        private AppResources appResources;

        public Login()
        {
            InitializeComponent();
            appResources = AppResources.getInstance();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(isManager())
            {
                appResources.userController.Login(UserInput.Text, PassInput.Password);
                NavigationService.Navigate(new Uri("../View/ViewManager/ManagerMainPage.xaml", UriKind.Relative));
            }
            else
            {
                UserInput.Text = "Pogrešno korisničko ime ili lozinka";
                PassInput.Password = "";
            }

            
        }

        private bool isManager()
        {
            foreach(User user in appResources.userController.GetAll())
            {
                if(user.UserName.Equals(UserInput.Text) && user.Password.Equals(PassInput.Password) && user.GetId().ToString().StartsWith("m"))
                {
                    return true;
                }
            }
            return false;
        }

        private void UserInput_GotFocus(object sender, RoutedEventArgs e)
        {
            UserInput.Text = "";
        }
    }
}
