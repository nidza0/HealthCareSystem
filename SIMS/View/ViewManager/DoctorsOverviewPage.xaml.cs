using SIMS.Controller.UsersController;
using SIMS.Model.UserModel;
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
    /// Interaction logic for DoctorsOverviewPage.xaml
    /// </summary>
    public partial class DoctorsOverviewPage : Page
    {

        private AppResources app;
        public DoctorsOverviewPage()
        {
            InitializeComponent();

            app = AppResources.getInstance();

            ListDataGrid.ItemsSource = initDocts();
        }


        private ObservableCollection<Doctor> initDocts()
        {
            ObservableCollection<Doctor> retVal = new ObservableCollection<Doctor>();
            foreach(Doctor doc in app.doctorController.GetAll())
            {
                if (app.userController.GetByID(doc.GetId()).Deleted == false)
                    retVal.Add(doc);
            }

            return retVal;
        }
        private void ListDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (!(e.PropertyName.Equals("Uidn") || e.PropertyName.Equals("Name") || e.PropertyName.Equals("Surname") || e.PropertyName.Equals("DocTypeEnum")))
            {
                e.Cancel = true;
            }

            if (e.Column.Header.ToString() == "Uidn")
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

            if (e.Column.Header.ToString() == "Surname")
            {
                e.Column.DisplayIndex = 2;
                e.Column.Header = "Prezime";
            }

            if (e.Column.Header.ToString() == "DocTypeEnum")
            {
                e.Column.Header = "Tip doktora";
            }

        }

        private void ListDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (Model.UserModel.Doctor)ListDataGrid.SelectedItem;
            if (row != null)
                NavigationService.Navigate(new DoctorDetailPage(row));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {

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
        //END REGION

        //Search button
        private void SearchButton_Click_1(object sender, RoutedEventArgs e)
        {

        }
        //END REGION
    }
}
