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

namespace SIMS.View.ViewSecretary.Pages
{
    /// <summary>
    /// Interaction logic for NewAppointmentPageSecretary.xaml
    /// </summary>
    public partial class NewAppointmentPageSecretary : Page
    {
        public NewAppointmentPageSecretary()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Frame sideFrame = (Frame)Application.Current.MainWindow.FindName("SideFrame");
            if (sideFrame.CanGoBack)
            {
                sideFrame.GoBack();
            }
            else
            {
                sideFrame.Content = null;
            }
        }
    }
}
