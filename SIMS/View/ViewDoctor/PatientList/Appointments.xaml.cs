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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.View.ViewDoctor.PatientList
{
    /// <summary>
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Page
    {
        Patient patient;
        public Appointments(Patient selektovaniPacijent)
        {
            patient = selektovaniPacijent;
            Title.Text = "Kontrole - " + selektovaniPacijent.Name + " " + selektovaniPacijent.Surname;
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ActiveDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            NewAppointment app = new NewAppointment(patient);
            app.Visibility = Visibility.Visible;
        }

        private void EditAppointment_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CancelAppointment_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
