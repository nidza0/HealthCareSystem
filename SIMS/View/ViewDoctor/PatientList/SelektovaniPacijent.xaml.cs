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
    /// Interaction logic for SelektovaniPacijent.xaml
    /// </summary>
    public partial class SelektovaniPacijent : Page
    {
        private Patient patient;
        public SelektovaniPacijent(Patient selektovaniPacijent)
        {
            patient = selektovaniPacijent;
            InitializeComponent();
            ImePrezime.Text = selektovaniPacijent.Name + " " + selektovaniPacijent.Surname;
        }



        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void StacionarnoLecenjeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Functions.UputZaStacionarno(this.patient));
        }

        private void SpecijalistickiBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Functions.UputZaSpecijalisticko(this.patient));
        }

        private void LaboratorijaBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Functions.UputZaLaboratoriju(this.patient));
        }

        private void EditPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatientList.IzmeniPacijenta(this.patient));
        }

        private void KartonBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new KartonPacijenta(this.patient));
        }

        private void AppointmentBtn_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(patient.Name);
            NavigationService.Navigate(new Appointments(this.patient));
        }
    }
}
