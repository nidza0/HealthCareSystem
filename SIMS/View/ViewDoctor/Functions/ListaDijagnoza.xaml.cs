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

namespace SIMS.View.ViewDoctor.Functions
{
    /// <summary>
    /// Interaction logic for ListaDijagnoza.xaml
    /// </summary>
    public partial class ListaDijagnoza : Page
    {
        public ListaDijagnoza()
        {
            InitializeComponent();
            DijagnozeSpisak.Visibility = Visibility.Hidden;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            DijagnozeSpisak.Visibility = Visibility.Visible;
        }

        private void Navigate_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
