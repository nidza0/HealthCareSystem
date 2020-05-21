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
    /// Interaction logic for LekarDetails.xaml
    /// </summary>
    public partial class LekarDetails : Page
    {
        public LekarDetails(Model.Doctor localDoc)
        {
            InitializeComponent();
            DoctorImage.Source = new BitmapImage(new Uri(localDoc.ImagePath, UriKind.Relative));
            NameLabel.Content = localDoc.Name + " " + localDoc.Surname;
            odeljenjeLabel.Content = localDoc.Depart;
            radnovremeLabel.Content = localDoc.StartWH + "-" + localDoc.EndWH;
            telefonLabel.Content = localDoc.Telephone;
            titulaLabel.Content = localDoc.Title;
            roomLabel.Content = localDoc.Room;
            datumLabel.Content = localDoc.Birth;
        }

        private void MenuLekari_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/view/LekariPage.xaml", UriKind.Relative));

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
