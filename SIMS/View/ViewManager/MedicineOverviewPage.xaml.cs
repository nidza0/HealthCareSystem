using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MedicineOverviewPage.xaml
    /// </summary>
    public partial class MedicineOverviewPage : Page
    {
        public MedicineOverviewPage()
        {
            InitializeComponent();

            ValidatedMedicinePanel.Visibility = Visibility.Visible;
            NonValidatedMedicinePanel.Visibility = Visibility.Hidden;

            ValidateMedicineDataGrid.ItemsSource = initValidated();
            NonValidatedMedicineDataGrid.ItemsSource = initNonValidated();
        }

        private void ValidateMedicineDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void NonValidatedMedicineDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private ObservableCollection<Medicine> initValidated()
        {
            ObservableCollection<Medicine> retval = new ObservableCollection<Medicine>();

            foreach(Medicine med in Login.medicines)
            {
                if (med.IsValid == true)
                    retval.Add(med);
            }

            return retval;
        }

        private ObservableCollection<Medicine> initNonValidated()
        {
            ObservableCollection<Medicine> retval = new ObservableCollection<Medicine>();

            foreach (Medicine med in Login.medicines)
            {
                if (med.IsValid == false)
                    retval.Add(med);
            }

            return retval;
        }

        //Menu buttons
        private void MenuSmene_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/ShiftsOverviewPage.xaml", UriKind.Relative));
        }

        private void MenuLekari_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("../View/ViewManager/DoctorsOverviewPage.xaml", UriKind.Relative));
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

        private void validated_Click(object sender, RoutedEventArgs e)
        {
            ValidatedMedicinePanel.Visibility = Visibility.Visible;
            NonValidatedMedicinePanel.Visibility = Visibility.Hidden;
        }

        private void forValidation_Click(object sender, RoutedEventArgs e)
        {
            ValidatedMedicinePanel.Visibility = Visibility.Hidden;
            NonValidatedMedicinePanel.Visibility = Visibility.Visible;
        }


        private void NonValidatedMedicineDataGrid_MouseDoubleClick(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var row = (Medicine)NonValidatedMedicineDataGrid.SelectedItem;
            if (row != null)
                NavigationService.Navigate(new MedicineDetailPage(row));
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MedicineAddingPage());
        }

        private void lowStock_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MedicineLowStock());
        }

        private void ValidateMedicineDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (Medicine)ValidateMedicineDataGrid.SelectedItem;
            if (row != null)
                NavigationService.Navigate(new MedicineDetailPage(row));
        }

        private void NonValidatedMedicineDataGrid_MouseDoubleClick_1(object sender, MouseButtonEventArgs e)
        {
            var row = (Medicine)NonValidatedMedicineDataGrid.SelectedItem;
            if (row != null)
                NavigationService.Navigate(new MedicineDetailPage(row));
        }




        //END REGION
    }
}
