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
    /// Interaction logic for Diagnosis.xaml
    /// </summary>
    public partial class Diagnosis : UserControl
    {
        private Model.PatientModel.Diagnosis thisDiagnosis;
        public Diagnosis(Model.PatientModel.Diagnosis diagnosis, int width)
        {
            this.Width = width;
            thisDiagnosis = diagnosis;
            InitializeComponent();
            DijagnozaTB.Text = thisDiagnosis.DiagnosedDisease.Name;
            DatumTB.Text = thisDiagnosis.Date.ToString();
        }

        private void DetaljiBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
