using SIMS.Model.UserModel;
using SIMS.View.ViewSecretary.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for PatientsPageSecretary.xaml
    /// </summary
    public partial class PatientsPage : Page
    {
        PatientsViewModel patientsVM;
        ChartData chartData = new ChartData();

        public PatientsPage()
        {
            InitializeComponent();
            patientsVM = new PatientsViewModel();
            DataContext = patientsVM;
            checkPatients();

            chartData.LoadPatientChart();
            chartMale.DataContext = chartData;
            chartFemale.DataContext = chartData;
            chartOther.DataContext = chartData;
        }
       
        private void checkPatients()
        {
            if(patientsVM.Patients.Count == 0)
            {
                errNoPatients.Visibility = Visibility.Visible;
            }
            else
            {
                errNoPatients.Visibility = Visibility.Hidden;
            }
        }
        
        private void dataGridPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //TODO: open patient details page
            Patient selectedPatient = (Patient)dataGridPatients.SelectedItem;
            if(selectedPatient != null)
                FrameManager.getInstance().SideFrame.Navigate(new PatientDetailsPage(selectedPatient));
        }

        private void dataGridPatients_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // Add row number
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
