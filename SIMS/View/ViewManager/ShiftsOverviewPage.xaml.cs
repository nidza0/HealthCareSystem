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
    /// Interaction logic for ShiftsOverviewPage.xaml
    /// </summary>
    public partial class ShiftsOverviewPage : Page
    {
        public ShiftsOverviewPage()
        {
            InitializeComponent();

            PresentPanel.Visibility = Visibility.Visible;
            AbsentPanel.Visibility = Visibility.Hidden;

            PresentDataGrid.ItemsSource = findOnJob();
            AbsentDataGrid.ItemsSource = findOffJob();
        }

        private ObservableCollection<Doctor> findOnJob()
        {
            ObservableCollection<Doctor> docs = new ObservableCollection<Doctor>();

            foreach(Doctor doc in Login.doctors)
            {
                if(isOnJob(doc))
                {
                    docs.Add(doc);
                    
                }
            }
            return docs;
        }

        private ObservableCollection<Doctor> findOffJob()
        {
            ObservableCollection<Doctor> docs = new ObservableCollection<Doctor>();

            foreach (Doctor doc in Login.doctors)
            {
                if (!isOnJob(doc))
                {
                    docs.Add(doc);

                }
            }
            return docs;
        }

        private bool isOnJob(Doctor doc)
        {
            DateTime now = DateTime.Now;

            WorkingDaysEnum wde = WorkingDaysEnum.MONDAY;

            switch(now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    wde = WorkingDaysEnum.MONDAY;
                    break;
                case DayOfWeek.Tuesday:
                    wde = WorkingDaysEnum.TUESDAY;
                    break;
                case DayOfWeek.Wednesday:
                    wde = WorkingDaysEnum.WEDNESDAY;
                    break;
                case DayOfWeek.Thursday:
                    wde = WorkingDaysEnum.THURSDAY;
                    break;
                case DayOfWeek.Friday:
                    wde = WorkingDaysEnum.FRIDAY;
                    break;
                case DayOfWeek.Saturday:
                    wde = WorkingDaysEnum.SATURDAY;
                    break;
                case DayOfWeek.Sunday:
                    wde = WorkingDaysEnum.SUNDAY;
                    break;
            }

            TimeTable radnaNedelja = doc.TimeTable;
            Util.TimeInterval radnoVreme = radnaNedelja.WorkingHours[wde];

            if (radnoVreme.StartTime.Hour <= now.Hour && radnoVreme.EndTime.Hour >= now.Hour)
                return true;

            return false;
        }

        private void PresentDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void PresentDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (Doctor)PresentDataGrid.SelectedItem;
            if (row != null)
                NavigationService.Navigate(new DoctorDetailPage(row));
        }

        private void AbsentDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

        }

        private void AbsentDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (Doctor)AbsentDataGrid.SelectedItem;
            if (row != null)
                NavigationService.Navigate(new DoctorDetailPage(row));
        }

        private void presentButton_Click(object sender, RoutedEventArgs e)
        {
            PresentPanel.Visibility = Visibility.Visible;
            AbsentPanel.Visibility = Visibility.Hidden;
        }

        private void absentButton_Click(object sender, RoutedEventArgs e)
        {
            AbsentPanel.Visibility = Visibility.Visible;
            PresentPanel.Visibility = Visibility.Hidden;
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
