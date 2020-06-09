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

namespace SIMS.View.ViewDoctor
{
    /// <summary>
    /// Interaction logic for MainPageCenter.xaml
    /// </summary>
    public partial class MainPageCenter : Page
    {
        public MainPageCenter()
        {
            InitializeComponent();
        }

        private void Recepti_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OdaberiPacijenta(OdaberiPacijenta.sources.RECEPTI));
        }

        private void Validacija_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ValidacijaLekova());
        }

        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Podesavanja());
        }

        private void Stacionarno_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OdaberiPacijenta(OdaberiPacijenta.sources.STACIONARNO));

        }

        private void Specijalisticko_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OdaberiPacijenta(OdaberiPacijenta.sources.SPECIJALISTICKI));
        }

        private void Laboratorija_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OdaberiPacijenta(OdaberiPacijenta.sources.LABORATORIJSKI));
        }

        private void PatientList_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListaPacijenata());
        }

        private void RightPageBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageRight());
        }

        private void ListaDijagnoza_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ListaDijagnoza());
        }
    }
}
