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

namespace wpf_manager.view
{
    /// <summary>
    /// Interaction logic for ManagerMain.xaml
    /// </summary>
    public partial class ManagerMain : Page
    {
        Manager mng = new Manager();
        public ManagerMain()
        {
            InitializeComponent();
            imeLabela.Content = mng.Ime +" "+ mng.Prezime;
            rVremeLabela.Content = mng.PocetakRV + " - " + mng.KrajRV;
            adresaLabela.Content = mng.Adresa;
            brojLabela.Content = mng.Telefon;

           
        }

        private void MenuLekari_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/LekariPage.xaml", UriKind.Relative));
        }
    }
}
