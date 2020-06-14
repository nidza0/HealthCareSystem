using SIMS.Model.UserModel;
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

namespace SIMS.View.ViewDoctor.Functions
{
    /// <summary>
    /// Interaction logic for UputZaSpecijalisticko.xaml
    /// </summary>
    public partial class UputZaSpecijalisticko : Page
    {
        Patient patient;
        public UputZaSpecijalisticko(Patient selected)
        {
            patient = selected;
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new OdaberiPacijenta(OdaberiPacijenta.sources.SPECIJALISTICKI));
            this.NavigationService.GoBack();
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
            MessageBoxButton button = MessageBoxButton.OK;
            string caption = "Uspešno ste izdali uput";
            string messageBoxText = "Uspešno ste izdali uput za specijalistički pregled.";
            MessageBox.Show(messageBoxText, caption, button);
        }

        private void CANCEL_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
        }
    }
}
