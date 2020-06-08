using SIMS.Model.ManagerModel;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        Dummies.DummyDoctors dummy = new Dummies.DummyDoctors();

        public static ObservableCollection<Doctor> doctors;
        public static ObservableCollection<InventoryItem> items;

        public Login()
        {
            InitializeComponent();

            doctors = new ObservableCollection<Doctor>();

            foreach (Doctor doc in Dummies.DummyDoctors.doctorsList)
                doctors.Add(doc);

            items = new ObservableCollection<InventoryItem>();

            foreach (InventoryItem item in Dummies.DummyDoctors.itemsList)
                items.Add(item);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Verifikacija
            NavigationService.Navigate(new Uri("../View/ViewManager/ManagerMainPage.xaml", UriKind.Relative));
        }
    }
}
