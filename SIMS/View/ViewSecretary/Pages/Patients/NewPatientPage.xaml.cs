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

namespace SIMS.View.ViewSecretary.Pages.Patients
{
    /// <summary>
    /// Interaction logic for NewPatientPageSecretary.xaml
    /// </summary>
    public partial class NewPatientPage : Page
    {
        public NewPatientPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FrameManager.getInstance().CentralFrame.CanGoBack)
                FrameManager.getInstance().CentralFrame.GoBack();
        }
    }
}
