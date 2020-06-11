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
using SIMS.Util;
using SIMS.Model.UserModel;
using SIMS.View.ViewPatient.DAOclass;

using System.Collections.ObjectModel;
using SIMS.Model.DoctorModel;
using SIMS.View.ViewPatient.RepoSimulator;


namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for TherapyOverview.xaml
    /// </summary>
    public partial class TherapyOverview : Window
    {

        private TherapyRepo therapyRepo = TherapyRepo.Instance;
        private string selectedFilterDrugName;
        private string selectedFilterDoctor;
        private DateTime selectedStartDate = DateTime.Now;
        private DateTime selectedEndDate = DateTime.Now;

        private bool selectedWhenIGetUpCheckBox;
        private bool selectedInTheAfternoonCheckBox;
        private bool selectedInTheEveningCheckBox;
        private bool selectedBeforeBedCheckBox;


        private ObservableCollection<PatientSingleTherapy> allTherapies; //za naseg pacijenta, podrazumeva se


        
        public TherapyOverview()
        {
            this.DataContext = this;
            InitializeComponent();


            doctorComboBox.ItemsSource = Doctors;

            
        }

        public string SelectedFilterDrugName { get => selectedFilterDrugName; set => selectedFilterDrugName = value; }
        public string SelectedFilterDoctor { get => selectedFilterDoctor; set => selectedFilterDoctor = value; }
        public DateTime SelectedStartDate { get => selectedStartDate; set => selectedStartDate = value; }
        public DateTime SelectedEndDate { get => selectedEndDate; set => selectedEndDate = value; }
        public bool SelectedWhenIGetUpCheckBox { get => selectedWhenIGetUpCheckBox; set => selectedWhenIGetUpCheckBox = value; }
        public bool SelectedInTheAfternoonCheckBox { get => selectedInTheAfternoonCheckBox; set => selectedInTheAfternoonCheckBox = value; }
        public bool SelectedInTheEveningCheckBox { get => selectedInTheEveningCheckBox; set => selectedInTheEveningCheckBox = value; }
        public bool SelectedBeforeBedCheckBox { get => selectedBeforeBedCheckBox; set => selectedBeforeBedCheckBox = value; }
        public ObservableCollection<PatientSingleTherapy> AllTherapies {
            get
            {
                return GetObservablePatientSingleTherapies();
            }
            set => allTherapies = value;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private IEnumerable<Therapy> GetAllTherapies()
        {
            //poziv kontrolera

            return therapyRepo.TherapyList;
        }



        private List<PatientSingleTherapy> GetPatientSingleTherapies()
        {
            List<PatientSingleTherapy> retVal = new List<PatientSingleTherapy>();

            List<Therapy> allTherapies = GetAllTherapies().ToList();

            foreach(Therapy therapy in allTherapies)
            {
                Prescription therapyPrescription = therapy.Prescription;

                foreach(KeyValuePair<Medicine,TherapyDose> pair in therapyPrescription.Medicine)
                {
                    //za svaki lek
                    PatientSingleTherapy patientSingleTherapy = new PatientSingleTherapy(pair.Key, therapy.TimeInterval, pair.Value.Dosage,therapyPrescription.Doctor);
                    retVal.Add(patientSingleTherapy);
                }
            }





            return retVal;
        }


        private ObservableCollection<PatientSingleTherapy> GetObservablePatientSingleTherapies()
        {
            List<PatientSingleTherapy> patientSingleTherapies = GetPatientSingleTherapies();
            Console.WriteLine(patientSingleTherapies.Count);
            ObservableCollection<PatientSingleTherapy> retVal = new ObservableCollection<PatientSingleTherapy>();

            foreach(PatientSingleTherapy therapy in patientSingleTherapies)
            {
                retVal.Add(therapy);
            }


            return retVal;
        }

        private ObservableCollection<Doctor> Doctors
        {
            get
            {
                List<Doctor> doctors = GetPatientSingleTherapies().ToList().Select(therapy => therapy.Doctor).Distinct().ToList();

                ObservableCollection<Doctor> retVal = new ObservableCollection<Doctor>();

                foreach (Doctor doc in doctors)
                    retVal.Add(doc);

                return retVal;
            }
        }
    }
}
