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
using System.Windows.Shapes;

using SIMS.Model.PatientModel;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for DiagnosisPreview.xaml
    /// </summary>
    public partial class DiagnosisPreview : Window
    {

        private Diagnosis diagnosis;
        public DiagnosisPreview(Diagnosis diagnosis)
        {
            this.diagnosis = diagnosis;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Owner = Application.Current.MainWindow;
            this.DataContext = this;
            InitializeComponent();
        }

        public Diagnosis Diagnosis { get => diagnosis; set => diagnosis = value; }
        public Therapy Therapy {  get => Diagnosis.ActiveTherapy;}

        public Disease DiagnosedDisease { get => Diagnosis.DiagnosedDisease; }
        public String DiagnosedDiseaseName { get => DiagnosedDisease.Name; }
        public String Overview { get => DiagnosedDisease.Overview; }
        public Prescription Prescription { get => Diagnosis.ActiveTherapy.Prescription;  }
        public string Symptoms { get => string.Join(",", DiagnosedDisease.Symptoms.Select(symptom => symptom.Name)); }

        

    }
}
