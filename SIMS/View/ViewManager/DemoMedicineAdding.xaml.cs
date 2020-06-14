using System;
using System.Collections.Generic;
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
    /// Interaction logic for DemoMedicineAdding.xaml
    /// </summary>
    public partial class DemoMedicineAdding : Page
    {
        private bool flag = false;
        public DemoMedicineAdding()
        {
            InitializeComponent();

            Function();
        }

        private async void Function()
        {
            await Task.Delay(1500);
            nameInput.Text= "Panadol";
            await Task.Delay(2000);
            inStockInput.Text = "15";
            await Task.Delay(2000);
            minInput.Text = "5";
            await Task.Delay(2000);
            tipCombo.SelectedIndex = 1;
            await Task.Delay(2000);
            weightInput.Text = "125";
            await Task.Delay(2000);

            if(!flag)
                NavigationService.Navigate(new DemoMedicineOverview());

        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            flag = true;
            NavigationService.Navigate(new ManagerMainPage());
        }
    }
}
