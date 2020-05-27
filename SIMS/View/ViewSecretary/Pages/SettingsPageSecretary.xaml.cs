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
    public partial class SettingsPageSecretary : Page
    {
        public SettingsPageSecretary()
        {
            InitializeComponent();
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
    }
}
