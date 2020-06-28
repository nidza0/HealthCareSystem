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
        private string selectedFilterDrugName;
        private Doctor selectedFilterDoctor;
        private DateTime selectedStartDate = DateTime.Now;
        private DateTime selectedEndDate = DateTime.Now;

        private bool selectedWhenIGetUpCheckBox;
        private bool selectedInTheAfternoonCheckBox;
        private bool selectedInTheEveningCheckBox;
        private bool selectedBeforeBedCheckBox;


        private ObservableCollection<PatientSingleTherapy> allTherapies; //za naseg pacijenta, podrazumeva se

        private List<Therapy> therapyList;


        
        public TherapyOverview()
        {
            allTherapies = new ObservableCollection<PatientSingleTherapy>();
            fillWithDefaultValues();

            this.DataContext = this;
            InitializeComponent();


            doctorComboBox.ItemsSource = Doctors;

            
        }

        public void fillWithDefaultValues()
        {
            ClearTherapyList();
            foreach (PatientSingleTherapy therapy in GetPatientSingleTherapies(GetAllTherapies().ToList()))
            {
                //initial therpaies
                allTherapies.Add(therapy);
            }
        }

        public string SelectedFilterDrugName { get => selectedFilterDrugName; set => selectedFilterDrugName = value; }
        public Doctor SelectedFilterDoctor { get => selectedFilterDoctor; set => selectedFilterDoctor = value; }
        public DateTime SelectedStartDate { get => selectedStartDate; set => selectedStartDate = value; }
        public DateTime SelectedEndDate { get => selectedEndDate; set => selectedEndDate = value; }
        public bool SelectedWhenIGetUpCheckBox { get => selectedWhenIGetUpCheckBox; set => selectedWhenIGetUpCheckBox = value; }
        public bool SelectedInTheAfternoonCheckBox { get => selectedInTheAfternoonCheckBox; set => selectedInTheAfternoonCheckBox = value; }
        public bool SelectedInTheEveningCheckBox { get => selectedInTheEveningCheckBox; set => selectedInTheEveningCheckBox = value; }
        public bool SelectedBeforeBedCheckBox { get => selectedBeforeBedCheckBox; set => selectedBeforeBedCheckBox = value; }
        public ObservableCollection<PatientSingleTherapy> AllTherapies {
            get => allTherapies;
            
            set => allTherapies = value;
        }

        private void ClearTherapyList()
        {
            while (AllTherapies.Count > 0)
            {
                AllTherapies.RemoveAt(AllTherapies.Count - 1);
            }
        }



        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            List<TherapyTime> therapyTimes = new List<TherapyTime>();
            if (selectedWhenIGetUpCheckBox) therapyTimes.Add(TherapyTime.WhenIWakeUp);
            if (selectedInTheAfternoonCheckBox) therapyTimes.Add(TherapyTime.Afternoon);
            if (selectedInTheEveningCheckBox) therapyTimes.Add(TherapyTime.Evening);
            if (selectedBeforeBedCheckBox) therapyTimes.Add(TherapyTime.BeforeBed);
            TherapyFilter therapyFilter = new TherapyFilter(selectedFilterDrugName, selectedFilterDoctor, new TimeInterval(selectedStartDate, selectedEndDate), therapyTimes);

            List<Therapy> therapies = AppResources.getInstance().therapyService.GetFilteredTherapy(therapyFilter).ToList();

            ClearTherapyList();

            foreach(PatientSingleTherapy therapy in GetPatientSingleTherapies(therapies))
            {
                AllTherapies.Add(therapy);
            }

        }

        private IEnumerable<Therapy> GetAllTherapies()
        {
            //poziv kontrolera
            Patient patient = AppResources.getInstance().patientController.GetByID(AppResources.getInstance().loggedInUser.GetId());
            return AppResources.getInstance().patientController.GetActiveTherapyForPatient(patient);
        }



        private ObservableCollection<PatientSingleTherapy> GetPatientSingleTherapies(List<Therapy> therapies)
        {
            List<PatientSingleTherapy> retVal = new List<PatientSingleTherapy>();

            foreach(Therapy therapy in therapies)
            {
                Prescription therapyPrescription = therapy.Prescription;

                foreach (KeyValuePair<Medicine, TherapyDose> pair in therapyPrescription.Medicine)
                {
                    //za svaki lek
                    PatientSingleTherapy patientSingleTherapy = new PatientSingleTherapy(pair.Key, therapy.TimeInterval, pair.Value.Dosage, therapyPrescription.Doctor);
                    retVal.Add(patientSingleTherapy);
                }
            }


            return new ObservableCollection<PatientSingleTherapy>(retVal);
        }



        private ObservableCollection<Doctor> Doctors
        {
            get
            {
                //List<Doctor> doctors = GetPatientSingleTherapies().ToList().Select(therapy => therapy.Doctor).Distinct().ToList();
                List<Doctor> doctors = AppResources.getInstance().doctorController.GetActiveDoctors().ToList();
                ObservableCollection<Doctor> retVal = new ObservableCollection<Doctor>();

                foreach (Doctor doc in doctors)
                    retVal.Add(doc);

                return retVal;
            }
        }
    }
}
