using SIMS.Model.PatientModel;
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

namespace SIMS.View.ViewManager
{
    /// <summary>
    /// Interaction logic for MedicineDetailPage.xaml
    /// </summary>
    public partial class MedicineDetailPage : Page
    {
        private Medicine sMed;

        public MedicineDetailPage(Medicine med)
        {
            InitializeComponent();

            NameLabel.Content = med.Name;
            dozaLabel.Content = med.Strength.ToString();
            idLabel.Content = med.GetId().ToString();
            minNumberLabel.Content = med.MinNumber.ToString();
            inStockLabel.Content = med.InStock.ToString();
            isValidLabel.Content = med.IsValid.ToString();

            sMed = med;
        }

        //Menu buttons
        private void MenuSmene_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/ShiftsOverviewPage.xaml", UriKind.Relative));
        }

        private void MenuLekari_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/DoctorOverviewPage.xaml", UriKind.Relative));
        }

        private void MenuInventar_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/InventoryOverviewPage.xaml", UriKind.Relative));
        }

        private void MenuLekovi_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/MedicineOverviewPage.xaml", UriKind.Relative));
        }

        private void MenuSale_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/RoomsOverviewPage.xaml", UriKind.Relative));
        }

        private void MenuDodavanje_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/DoctorAddingPage.xaml", UriKind.Relative));
        }
        //END REGION

        // Home Button
        private void homeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/ManagerMainPage.xaml", UriKind.Relative));
        }
        //END REGION
        //Back button
        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MedicineEdit(sMed));
        }
        //END REGION
    }
}
