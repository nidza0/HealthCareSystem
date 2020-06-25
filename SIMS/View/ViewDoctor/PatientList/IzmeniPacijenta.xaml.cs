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
    /// Interaction logic for IzmeniPacijenta.xaml
    /// </summary>
    public partial class IzmeniPacijenta : Page
    {
        Patient patient;
        public IzmeniPacijenta(Patient selectedPatient)
        {
            patient = selectedPatient;
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

            updatePatientInfo();

            AppResources.getInstance().patientController.Update(patient);

            MessageBoxButton button = MessageBoxButton.OK;
            string caption = "Uspešno ste izmenili podatke";
            string messageBoxText = "Uspešno ste izmenili podatke pacijenta.";
            MessageBox.Show(messageBoxText, caption, button);
        }

        private void updatePatientInfo()
        {
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
