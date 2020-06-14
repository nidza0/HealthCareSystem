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
    /// Interaction logic for MedicineLowStock.xaml
    /// </summary>
    public partial class MedicineLowStock : Page
    {
        public MedicineLowStock()
        {
            InitializeComponent();
        
            InventoryDataGrid.ItemsSource = initializeList();
        }


    private void InventoryDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
            if (!(e.PropertyName.Equals("Name") || e.PropertyName.Equals("InStock") || e.PropertyName.Equals("MinNumber") || e.PropertyName.Equals("Strenght") || e.PropertyName.Equals("MedicineType") || e.PropertyName.Equals("Id")))
            {
                e.Cancel = true;
            }

            if (e.Column.Header.ToString() == "Id")
            {
                e.Column.Width = 50;
                e.Column.DisplayIndex = 0;
                e.Column.Header = "ID";
            }

            if (e.Column.Header.ToString() == "Name")
            {
                e.Column.DisplayIndex = 1;
                e.Column.Header = "Ime";
            }

            if (e.Column.Header.ToString() == "InStock")
            {
                e.Column.DisplayIndex = 2;
                e.Column.Header = "Na stanju";
            }

            if (e.Column.Header.ToString() == "MinNumber")
            {
                e.Column.Header = "Min. broj";
                e.Column.DisplayIndex = 3;
            }

            if (e.Column.Header.ToString() == "MedicineType")
            {
                e.Column.Header = "Tip leka";
            }
        }

    private ObservableCollection<Medicine> initializeList()
    {
        ObservableCollection<Medicine> retVal = new ObservableCollection<Medicine>();

        foreach (Medicine med in Login.medicines)
        {
            if (med.InStock <= med.MinNumber * 1.2 && med.IsValid == true)
                retVal.Add(med);
        }

        return retVal;
    }

    private void InventoryDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        var row = (Medicine)InventoryDataGrid.SelectedItem;
        if (row != null)
            NavigationService.Navigate(new MedicineDetailPage(row));
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
}
}
