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
    /// <summary>
    /// Interaction logic for SettingsPageSecretary.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            InitializeButtons();
        }

        private void InitializeButtons()
        {
            if(Application.Current.Resources["UiPrimaryColor"] == Brushes.RoyalBlue)
            {
                radioBlue.IsChecked = true;
            }
            else if (Application.Current.Resources["UiPrimaryColor"] == Brushes.SeaGreen)
            {
                radioGreen.IsChecked = true;
            }
            else if(Application.Current.Resources["UiPrimaryColor"] == Brushes.Brown)
            {
                radioRed.IsChecked = true;
            }
        }

        private void color_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            SolidColorBrush primary = null;
            SolidColorBrush secondary = null;
            switch (btn.Name)
            {
                case "radioBlue":
                    primary = Brushes.RoyalBlue;
                    secondary = Brushes.AliceBlue;
                    break;
                case "radioGreen":
                    primary = Brushes.SeaGreen;
                    secondary = Brushes.Honeydew;
                    break;
                case "radioRed":
                    primary = Brushes.Brown;
                    secondary = Brushes.SeaShell;
                    break;
            }
            Application.Current.Resources["UiPrimaryColor"] = primary;
            Application.Current.Resources["UiSecondaryColor"] = secondary;
        }

        private void btnFeedback_Click(object sender, RoutedEventArgs e)
        {
            User loggedInUser = UserViewModel.GetInstance().LoggedInUser;
            var feedback = AppResources.getInstance().feedbackController.GetByUser(loggedInUser);
            
            if(feedback == null)
            {
                FrameManager.getInstance().SideFrame.Navigate(new FeedbackPage());
            }
            else
            {
                FrameManager.getInstance().SideFrame.Navigate(new FeedbackPage(feedback));
            }
        }
    }
}
