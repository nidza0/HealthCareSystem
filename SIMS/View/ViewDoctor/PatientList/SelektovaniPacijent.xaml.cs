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
        }



        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void StacionarnoLecenjeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Functions.UputZaStacionarno(patient));
        }

        private void SpecijalistickiBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Functions.UputZaSpecijalisticko(patient));
        }

        private void LaboratorijaBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Functions.UputZaLaboratoriju(patient));
        }

        private void EditPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PatientList.IzmeniPacijenta());
        }
    }
}
