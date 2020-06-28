using SIMS.Model.PatientModel;
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
    /// Interaction logic for NewDiagnosis.xaml
    /// </summary>
    public partial class NewDiagnosis : UserControl
    {
        private Patient patient;
        private string disease;
        private string therapy;
        private List<Model.PatientModel.Diagnosis> allDiags;
        private DataGrid dg;
        private StackPanel sp;
        public NewDiagnosis(List<Model.PatientModel.Diagnosis> allDiags, DataGrid dg, StackPanel sp)
        {
            this.sp = sp;
            this.dg = dg;
            this.allDiags = allDiags;
            InitializeComponent();
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            String[] symptoms = SymptomsTextBox.Text.Split(',');
            List<Symptom> symptomsList = new List<Symptom>();
            foreach(string temp in symptoms)
            {
                symptomsList.Add(new Symptom(temp.Trim().ToLower(), null));
            }
            AppResources ar = AppResources.getInstance();
            var tempList = new List<Symptom>();
            tempList.Add(new Symptom("S1", ""));

            Disease tempDisease = new Disease(DiseaseTextBox.Text, "", true, new DiseaseType(false, true, "genetic"), tempList, null);

            
            ar.patientController.AddDiagnosis(patient, new SIMS.Model.PatientModel.Diagnosis(tempDisease, null));
            //ar.diseaseRepository.Create(new Model.PatientModel.Disease(ar.diseaseRepository.GetMaxId(ar.diseaseRepository.GetAll()) + 1));
            //allDiags.Add();

            //AppResources.getInstance().patientController.AddDiagnosis(new Model.PatientModel.Diagnosis(ar.diseaseRepository.GetMaxId(ar.diseaseRepository.GetAll()) + 1,
            //    new Disease(DiseaseTextBox.Text.ToLower().Trim(), null, false, new DiseaseType(false, true, "Genetic"), symptomsList, null)));

            dg.Items.Refresh();
            sp.Children.Remove(this);
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            sp.Children.Remove(this);
        }
    }
}
