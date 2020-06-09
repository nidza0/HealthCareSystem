using SIMS.View.ViewDoctor.MainPages;
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
        private System.Windows.Point startPoint;
        public MainPageCenter()
        {
            InitializeComponent();
        }

        private void Recepti_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatientList.OdaberiPacijenta(PatientList.OdaberiPacijenta.sources.RECEPTI));
        }

        private void Validacija_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Functions.ValidacijaLekova());
        }

        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Settings.Podesavanja());
        }

        private void Stacionarno_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatientList.OdaberiPacijenta(PatientList.OdaberiPacijenta.sources.STACIONARNO));

        }

        private void Specijalisticko_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatientList.OdaberiPacijenta(PatientList.OdaberiPacijenta.sources.SPECIJALISTICKI));
        }

        private void Laboratorija_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatientList.OdaberiPacijenta(PatientList.OdaberiPacijenta.sources.LABORATORIJSKI));
        }

        private void PatientList_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatientList.ListaPacijenata());
        }

        private void RightPageBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPages.MainPageRight());
        }

        private void ListaDijagnoza_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Functions.ListaDijagnoza());
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            Point currPos = e.GetPosition(null);
            Vector differential = currPos - startPoint;
            Vector backUp = currPos - startPoint;

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(differential.X) > SystemParameters.MinimumHorizontalDragDistance)
            {
                if (backUp.X > 0)
                    NavigationService.Navigate(new MainPageRight());
                else if (backUp.X < 0)
                    NavigationService.Navigate(new MainPageLeft());
            }
        }
    }
}
