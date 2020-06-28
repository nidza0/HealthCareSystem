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
    /// Interaction logic for DemoDoctorOverView.xaml
    /// </summary>
    public partial class DemoDoctorOverView : Page
    {
        private bool flag = false;

        public DemoDoctorOverView()
        {
            InitializeComponent();

            ObservableCollection<Doctor> docs = new ObservableCollection<Doctor>();

            Doctor doc = new Doctor(new UserID("D123"),"username", "passwd", DateTime.Now, "Petar", "Petrovic", "Petar", Sex.MALE, new DateTime(1980, 5, 15), "idn", new Address("Ulica", new Location("Vojvodina", "Novi Sad")), null, null, null, null, null, null, null, Model.DoctorModel.DoctorType.GASTROENEROLOGIST);

            docs.Add(doc);

            ListDataGrid.ItemsSource = docs;

            Function();
        }

        private async void Function()
        {
            await Task.Delay(2000);
            krajLabel.Content = "Kraj demo-a za dodavanje!\nSledi: Dodavanje leka";
            await Task.Delay(3500);
            if (!flag)
                NavigationService.Navigate(new DemoMedicineAdding());

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

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            NavigationService.Navigate(new ManagerMainPage());
        }
    }
}
