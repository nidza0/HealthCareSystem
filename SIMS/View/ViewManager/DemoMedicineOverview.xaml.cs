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
    /// Interaction logic for DemoMedicineOverview.xaml
    /// </summary>
    public partial class DemoMedicineOverview : Page
    {
        private bool flag = false;
        public DemoMedicineOverview()
        {
            InitializeComponent();

            ValidatedMedicinePanel.Visibility = Visibility.Visible;
            NonValidatedMedicinePanel.Visibility = Visibility.Hidden;

            Medicine med = new Medicine("Panadol", 125, MedicineType.PILL, 15, 10);

            ObservableCollection<Medicine> meds = new ObservableCollection<Medicine>();

            meds.Add(med);

            NonValidatedMedicineDataGrid.ItemsSource = meds;

            Function();
        }

        private async void Function()
        {
            await Task.Delay(1500);
            clickLabel.Content = "*Click*";
            
            await Task.Delay(2000);
            ValidatedMedicinePanel.Visibility = Visibility.Hidden;
            NonValidatedMedicinePanel.Visibility = Visibility.Visible;
            await Task.Delay(2000);
            krajLabel.Content = "Kraj demo-a za dodavanje lekova!\nSledi: Dodavanje doktora";

            await Task.Delay(4000);
            if (!flag)
                NavigationService.Navigate(new DemoDoctorsAdding1());


        }

        private void NonValidatedMedicineDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            NavigationService.Navigate(new ManagerMainPage());
        }
    }
}
