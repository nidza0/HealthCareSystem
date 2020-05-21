using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            NameLabel.Content = mng.Ime + " " + mng.Prezime;

            WebBrowser.Navigate("https://mobile.twitter.com/WHO");
            dynamic activeX = this.WebBrowser.GetType().InvokeMember("ActiveXInstance",BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,null, this.WebBrowser, new object[] { });
            activeX.Silent = true;
        }

        private void MenuLekari_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/LekariPage.xaml", UriKind.Relative));
        }

        
    }
}
