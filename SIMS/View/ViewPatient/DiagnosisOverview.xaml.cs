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
using System.Collections.ObjectModel;

using SIMS.Model.PatientModel;
using SIMS.Util;
using SIMS.Model.UserModel;
using System.ComponentModel;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for DiagnosisOverview.xaml
    /// </summary>
    public partial class DiagnosisOverview : Window
    {
        private ObservableCollection<Diagnosis> diagnosisList = new ObservableCollection<Diagnosis>();

        public DiagnosisOverview()
        {
            InitializeComponent();

            //public Diagnosis(long id, Disease disease, Therapy activeTherapy, List<Therapy> previousTherapy = null)
            Symptom symptom1 = new Symptom(22, "Throat pain", "Pain in the front neck region");
            Symptom symptom2 = new Symptom(22, "Nausea", "Feeling sick");
            Symptom symptom3 = new Symptom(22, "Throat pain", "Pain in the front neck region");
            List<Symptom> lista = new List<Symptom>();
            lista.Add(symptom1);
            lista.Add(symptom2);
            lista.Add(symptom3);

            Disease disease = new Disease(22, "Hashimoto's disease", " Hashimoto's disease is a condition in which your immune system" +
                                        "attacks your thyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple. The thyroid gland is part of your" +
                                        "endocrine system, which produces hormones that sadadthyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple.", true, new DiseaseType(true, true, "nmp"), lista);

            Disease disease1 = new Disease(23, "Throat cancer", " Hashimoto's disease is a condition in which your immune system" +
                                        "attacks your thyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple. The thyroid gland is part of your" +
                                        "endocrine system, which produces hormones that sadadthyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple.", true, new DiseaseType(true, true, "nmp"), lista);
            Medicine medicine = new Medicine("Xanax", 20, MedicineType.PILL, 5, 2);
            Medicine medicine1 = new Medicine("Pera", 10, MedicineType.PILL, 5, 2);
            Dictionary<Medicine, TherapyDose> dict = new Dictionary<Medicine, TherapyDose>();
            Dictionary<TherapyTime, double> dict_ther = new Dictionary<TherapyTime, double>();
            dict_ther.Add(TherapyTime.BeforeBed, 20);
            dict_ther.Add(TherapyTime.AsNeeded, 1);
            TherapyDose therapyDose = new TherapyDose(dict_ther);
            dict.Add(medicine, therapyDose);
            dict.Add(medicine1, therapyDose);

            Doctor doctor = new Doctor(new UserID("D123"));
            Prescription prescription = new Prescription(2, PrescriptionStatus.ACTIVE,doctor, dict);

            Therapy therapy = new Therapy(2, new TimeInterval(DateTime.Now, DateTime.Now), prescription);
            List<Therapy> therapies = new List<Therapy>();
            therapies.Add(therapy);

            Diagnosis diagnosis = new Diagnosis(69, disease, therapies);
            Diagnosis diagnosis1 = new Diagnosis(69, disease1, therapies);

            diagnosisList.Add(diagnosis);
            diagnosisList.Add(diagnosis1);

            //diagnosisListBox.DataContext = diagnosisList;

            this.DataContext = this;
        }

        public ObservableCollection<Diagnosis> DiagnosisList { get => diagnosisList; set => diagnosisList = value; }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Diagnosis> test = new ObservableCollection<Diagnosis>();
            Symptom symptom1 = new Symptom(22, "Throat pain", "Pain in the front neck region");
            Symptom symptom2 = new Symptom(22, "Nausea", "Feeling sick");
            Symptom symptom3 = new Symptom(22, "Throat pain", "Pain in the front neck region");
            List<Symptom> lista = new List<Symptom>();
            lista.Add(symptom1);
            lista.Add(symptom2);
            lista.Add(symptom3);

            Disease disease = new Disease(22, "Hashimoto's disease", " Hashimoto's disease is a condition in which your immune system" +
                                        "attacks your thyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple. The thyroid gland is part of your" +
                                        "endocrine system, which produces hormones that sadadthyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple.", true, new DiseaseType(true, true, "nmp"), lista);

            Disease disease1 = new Disease(23, "Throat cancer", " Hashimoto's disease is a condition in which your immune system" +
                                        "attacks your thyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple. The thyroid gland is part of your" +
                                        "endocrine system, which produces hormones that sadadthyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple.", true, new DiseaseType(true, true, "nmp"), lista);
            Medicine medicine = new Medicine("Xanax", 20, MedicineType.PILL, 5, 2);
            Dictionary<Medicine, TherapyDose> dict = new Dictionary<Medicine, TherapyDose>();
            Dictionary<TherapyTime, double> dict_ther = new Dictionary<TherapyTime, double>();
            dict_ther.Add(TherapyTime.BeforeBed, 20);
            TherapyDose therapyDose = new TherapyDose(dict_ther);
            dict.Add(medicine, therapyDose);

            Doctor doctor = new Doctor(new UserID("D123"));
            Prescription prescription = new Prescription(2, PrescriptionStatus.ACTIVE, doctor, dict);

            Therapy therapy = new Therapy(2, new TimeInterval(DateTime.Now, DateTime.Now), prescription);
            List<Therapy> therapies = new List<Therapy>();
            therapies.Add(therapy);

            Diagnosis diagnosis = new Diagnosis(69, disease, therapies);

            test.Add(diagnosis);
            //test.Add(diagnosis);

            //this.diagnosisList = test;


            //this.DiagnosisList.Clear();

            //this.DiagnosisList.Add(diagnosis);

            //ICollectionView view = CollectionViewSource.GetDefaultView(DiagnosisList);
            //view.Refresh();
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Diagnosis selectedDiagnosis = (Diagnosis)diagnosisListBox.SelectedItem;
            DiagnosisPreview diagnosisPreview = new DiagnosisPreview(selectedDiagnosis);
            diagnosisPreview.ShowDialog();
        }
    }
}
