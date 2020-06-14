using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.View.ViewDoctor.PatientList
{
    /// <summary>
    /// Interaction logic for KartonPacijenta.xaml
    /// </summary>
    public partial class KartonPacijenta : Page
    {
        Patient patient;
        Point startPoint;
        public KartonPacijenta(Patient selektovaniPacijent)
        {
            InitializeComponent();
            patient = selektovaniPacijent;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SpisakDijagnoza_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        /*
        private void SpisakDijagnoza_MouseMove(object sender, MouseEventArgs e)
        {

        }*/

        private void SpisakDijagnoza_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            /*
            Vector diff = e.GetPosition(null) - startPoint;
            if(Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance)
            {
                if(diff.X > 0)
                {
                    ActiveDate.SelectedDate.Value.AddDays(-1);
                } else if(diff.X < 0)
                {
                    ActiveDate.SelectedDate.Value.AddDays(-1);
                }
            }
            */
        }

        private void NewAppointmentBtn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void EditAppointmentBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteAppointmentBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void SpisakDijagnoza_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void SpisakDijagnoza_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }

        private void SpisakDijagnoza_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void ActiveDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ActiveDate_SelectedDateChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
