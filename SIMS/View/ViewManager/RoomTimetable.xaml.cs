using SIMS.Model.PatientModel;
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
    /// Interaction logic for RoomTimetable.xaml
    /// </summary>
    public partial class RoomTimetable : Page
    {
        public RoomTimetable(Room room)
        {
            InitializeComponent();

            RoomsDataGrid.ItemsSource = initList(room);
        }

        private ObservableCollection<Appointment> initList(Room room)
        {
            ObservableCollection<Appointment> retVal = new ObservableCollection<Appointment>();

            foreach(Appointment app in Login.appointments)
            {
                if(room.Equals(app.Room) && isInFuture(app))
                {
                    retVal.Add(app);
                }
            }

            return retVal;
        }

        private bool isInFuture(Appointment app)
        {
            DateTime now = DateTime.Now;

            if ((app.TimeInterval.StartTime > now || (app.TimeInterval.EndTime < now && app.TimeInterval.StartTime < now)) && !app.Canceled)
                return true;

            return false;
        }

        private void RoomsDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void RoomsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
    }
}
