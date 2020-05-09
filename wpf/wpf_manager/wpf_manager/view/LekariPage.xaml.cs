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
        public static int selectedDoc = -1;

        public static ObservableCollection<Model.Doctor> Doctors
        {
            get;
            set;
        }



        public LekariPage()
        { 
            Model.Doctor Ted = new Model.Doctor("Ted", "Mosby", @"../images/doc11.jpg", "8:00","15:00","Kardiologija", "+381 60 6720230", "Doktor","13.11.1953.","101",1);
            Model.Doctor Marshall = new Model.Doctor("Ted", "Ericssen", "../images/doc12.jpg", "9:00", "14:00", "Kardiologija", "+381 60 6720231", "Doktor", "29.10.1953.", "102",2);
            Model.Doctor Barney = new Model.Doctor("Barney", "Stinson", "../images/doc13.jpg", "12:00", "13:00", "ORL", "+381 60 6720232", "Doktor", "28.2.1966.", "111",3);
            Model.Doctor Jon = new Model.Doctor("Jon", "Snow", @"../images/doc21.jpg", "7:00", "18:00", "Pulmolog", "+381 60 6720233", "Doktor", "11.7.1984.", "104",9);
            Model.Doctor Daenerys = new Model.Doctor("Daenerys", "Targaryen", @"../images/doc22.jpg", "8:00", "15:00", "Porodiliste", "+381 60 6720234", "Doktor", "8.9.1998.", "109",4);
            Model.Doctor Ned = new Model.Doctor("Ned", "Stark", @"../images/doc23.jpg", "6:00", "11:00", "Psihologija", "+381 60 6720235", "Doktor", "22.7.1986.", "107",5);
            Model.Doctor Leia = new Model.Doctor("Leia", "Skywalker", @"../images/doc31.jpg", "15:00", "22:00", "Pedijatrija", "+381 60 6720236", "Doktor", "28.10.1988.", "151",6);
            Model.Doctor Luke = new Model.Doctor("Luke", "Skywalker", @"../images/doc32.jpg", "8:00", "15:00", "Pedijatrija", "+381 60 6720237", "Doktor", "15.6.1960.", "108",7);
            Model.Doctor Han = new Model.Doctor("Han", "Solo", @"../images/doc33.jpg", "8:00", "15:00", "Portir", "+381 60 6720238", "Doktor", "11.11.1975.", "109",8);

            this.DataContext = this;

            Doctors = new ObservableCollection<Model.Doctor>();

            Doctors.Add(Ted);
            Doctors.Add(Marshall);
            Doctors.Add(Barney);
            Doctors.Add(Jon);
            Doctors.Add(Daenerys);
            Doctors.Add(Ned);
            Doctors.Add(Leia);
            Doctors.Add(Luke);
            Doctors.Add(Han);


            InitializeComponent();

        
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
    }
}
