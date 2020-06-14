using SIMS.Model.UserModel;
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
            //TODO: Login
            
            String username = txtUsername.Text;
            String password = passwordBox.Password.ToString();

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
            /*
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(this);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            // Change the page of the frame.
            if (pageFrame != null)
            {
                pageFrame.Navigate(new MainWindowPage());
            }
            */
        }
    }
}
