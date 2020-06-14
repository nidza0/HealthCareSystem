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

namespace SIMS.View.ViewDoctor.Help
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : Page
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void PreglediBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PreglediHelp());
        }

        private void PatientBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PacijentiHelp());
        }

        private void DiagnosisBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListaDijagnozaHelp());
        }

        private void KalendarBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new KalendarHelp());
        }

        private void ValidationBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ValidacijaLekovaHelp());
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PodesavanjaHelp());
        }
    }
}
