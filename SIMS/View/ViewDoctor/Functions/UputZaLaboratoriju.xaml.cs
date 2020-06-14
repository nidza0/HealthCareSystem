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
    /// Interaction logic for UputZaLaboratoriju.xaml
    /// </summary>
    public partial class UputZaLaboratoriju : Page
    {
        Patient patient;
        public UputZaLaboratoriju(Patient selected)
        {
            patient = selected;
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new OdaberiPacijenta(OdaberiPacijenta.sources.LABORATORIJSKI));
            this.NavigationService.GoBack();

        }

        private void CANCEL_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
            MessageBoxButton button = MessageBoxButton.OK;
            string caption = "Uspešno ste izdali uput";
            string messageBoxText = "Uspešno ste izdali uput za laboratorijski pregled.";
            MessageBox.Show(messageBoxText, caption, button);
        }
    }
}
