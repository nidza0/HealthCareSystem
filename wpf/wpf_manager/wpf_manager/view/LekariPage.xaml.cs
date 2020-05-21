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

namespace wpf_manager.view
{
    /// <summary>
    /// Interaction logic for LekariPage.xaml
    /// </summary>
    public partial class LekariPage : Page
    {
        private int colNum = 0;

        public static ObservableCollection<Model.Doctor> Doctors
        {
            get;
            set;
        }



        public LekariPage()
        { 

            InitializeComponent();

            ListDataGrid.ItemsSource = Model.DoctorsList.Doctors;
        
            ListPanel.Visibility = Visibility.Visible;

            
        }

        

        private void ListDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if (colNum == 3)
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);

            if (!(e.PropertyName.Equals("Id") || e.PropertyName.Equals("Name") || e.PropertyName.Equals("Surname") || e.PropertyName.Equals("WorkingHours") || e.PropertyName.Equals("Depart")))
                e.Cancel = true;

            if (e.PropertyName.Equals("Id"))
            {
                e.Column.DisplayIndex = 0;
                e.Column.Header = "ID";
            }
            if(e.PropertyName.Equals("Name"))
            {
                e.Column.Header = "Ime";
            }
            if(e.PropertyName.Equals("Surname"))
            {
                e.Column.Header = "Prezime";
            }
            if (e.PropertyName.Equals("Depart"))
            {
                e.Column.Header = "Odeljenje";
            }
            if(e.PropertyName.Equals("WorkingHours"))
            {
                e.Column.Header = "Radno vreme";
            }
                
                
        }


        private void ListDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = (Model.Doctor)ListDataGrid.SelectedItem;
            if(row != null)
                NavigationService.Navigate(new LekarDetails(row));
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/SearchPage.xaml", UriKind.Relative));
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("view/ManagerMain.xaml", UriKind.Relative));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}
