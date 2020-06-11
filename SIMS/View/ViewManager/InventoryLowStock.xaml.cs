﻿using SIMS.Model.ManagerModel;
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
    /// Interaction logic for InventoryLowStock.xaml
    /// </summary>
    public partial class InventoryLowStock : Page
    {
        public InventoryLowStock()
        {
            InitializeComponent();

            InventoryDataGrid.ItemsSource = initializeList();
        }


        private void InventoryDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private ObservableCollection<InventoryItem> initializeList()
        {
            ObservableCollection<InventoryItem> retVal = new ObservableCollection<InventoryItem>();

            foreach(InventoryItem item in Login.items)
            {
                if (item.InStock <= item.MinNumber * 1.2)
                    retVal.Add(item);
            }

            return retVal;
        }

        private void InventoryDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (InventoryItem)InventoryDataGrid.SelectedItem;
            if (row != null)
                NavigationService.Navigate(new InventoryDetailPage(row));
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
