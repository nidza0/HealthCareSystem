using SIMS.View.ViewSecretary.ViewModel;
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

namespace SIMS.View.ViewSecretary.Pages.Doctors
{
    /// <summary>
    /// Interaction logic for DoctorsPage.xaml
    /// </summary>
    public partial class DoctorsPage : Page
    {
        DoctorsViewModel doctorsVM = new DoctorsViewModel();
        public DoctorsPage()
        {
            InitializeComponent();
            DataContext = doctorsVM;
        }

        private void dataGridDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridDoctors_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Add row number
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
