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
    /// Interaction logic for DiagnosisList.xaml
    /// </summary>
    public partial class DiagnosisList : Page
    {
        private List<Model.PatientModel.Diagnosis> diagnosisList;
        private int sirina;
        public DiagnosisList()
        {
            //this.diagnosisList = AppResources.getInstance().diagnosisRepository.GetAllDiagnosisForPatient(patient);
            //this.Height = Height;
            //this.Width = Width;
            //sirina = Width;
            InitializeComponent();
            fillWithDiagnosis();
        }

        private void fillWithDiagnosis()
        {
            if(diagnosisList.Count > 1) { 
                foreach(Model.PatientModel.Diagnosis temp in this.diagnosisList)
                {
                    Diagnosis diagnosis = new Diagnosis(temp, sirina);
                    StackPanelDiagnosis.Children.Add(diagnosis);
                }
            }
        }
    }
}
