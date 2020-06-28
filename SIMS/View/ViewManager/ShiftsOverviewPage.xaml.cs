using SIMS.Model.UserModel;
using SIMS.Util;
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

        private AppResources appResources;


        public ShiftsOverviewPage()
        {
            InitializeComponent();
            appResources = AppResources.getInstance();
            PresentPanel.Visibility = Visibility.Visible;
            AbsentPanel.Visibility = Visibility.Hidden;



            PresentDataGrid.ItemsSource = findOnJob();
            AbsentDataGrid.ItemsSource = findOffJob();
        }

        private ObservableCollection<Doctor> findOnJob()
        {
            ObservableCollection<Doctor> docs = new ObservableCollection<Doctor>();

            foreach(Doctor doc in appResources.doctorController.GetAll())
            {
                if(isOnJob(doc) && appResources.userController.GetByID(doc.GetId()).Deleted == false)
                {
                    docs.Add(doc);
                    
                }
            }
            return docs;
        }

        private ObservableCollection<Doctor> findOffJob()
        {
            ObservableCollection<Doctor> docs = new ObservableCollection<Doctor>();

            foreach (Doctor doc in appResources.doctorController.GetAll())
            {
                if (!isOnJob(doc) && appResources.userController.GetByID(doc.GetId()).Deleted == false)
                {
                    docs.Add(doc);

                }
            }
            return docs;
        }

        private bool isOnJob(Doctor doc)
        {
            DateTime now = DateTime.Now;
            doc = appResources.doctorController.GetByID(doc.GetId());

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

            TimeInterval radnaNedelja = appResources.timeTableRepository.GetByID(doc.TimeTable.GetId()).WorkingHours[wde];

            if (radnaNedelja.StartTime.Hour < now.Hour && radnaNedelja.EndTime.Hour > now.Hour)
                return true;
            else if (radnaNedelja.StartTime.Hour == now.Hour && radnaNedelja.StartTime.Minute < now.Minute)
                return true;
            else if (radnaNedelja.EndTime.Hour == now.Hour && radnaNedelja.EndTime.Minute > now.Minute)
                return true;

            return false;
        }

        private void PresentDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if(!(e.PropertyName.Equals("Uidn")|| e.PropertyName.Equals("Name") || e.PropertyName.Equals("Surname") || e.PropertyName.Equals("DocTypeEnum") ))
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

        private void PresentDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (Doctor)PresentDataGrid.SelectedItem;
            if (row != null)
                NavigationService.Navigate(new DoctorDetailPage(row));
        }

        private void AbsentDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
