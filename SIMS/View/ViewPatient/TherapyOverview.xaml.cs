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

using System.Collections.ObjectModel;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for TherapyOverview.xaml
    /// </summary>
    public partial class TherapyOverview : Window
    {
        private string selectedFilterDrugName;
        private string selectedFilterDoctor;
        private DateTime selectedStartDate;
        private DateTime selectedEndDate;

        private bool selectedWhenIGetUpCheckBox;
        private bool selectedInTheAfternoonCheckBox;
        private bool selectedInTheEveningCheckBox;
        private bool selectedBeforeBedCheckBox;


        private ObservableCollection<Therapy> AllTherapies; //za naseg pacijenta, podrazumeva se


        
        public TherapyOverview()
        {
            
            InitializeComponent();
        }

        public string SelectedFilterDrugName { get => selectedFilterDrugName; set => selectedFilterDrugName = value; }
        public string SelectedFilterDoctor { get => selectedFilterDoctor; set => selectedFilterDoctor = value; }
        public DateTime SelectedStartDate { get => selectedStartDate; set => selectedStartDate = value; }
        public DateTime SelectedEndDate { get => selectedEndDate; set => selectedEndDate = value; }
        public bool SelectedWhenIGetUpCheckBox { get => selectedWhenIGetUpCheckBox; set => selectedWhenIGetUpCheckBox = value; }
        public bool SelectedInTheAfternoonCheckBox { get => selectedInTheAfternoonCheckBox; set => selectedInTheAfternoonCheckBox = value; }
        public bool SelectedInTheEveningCheckBox { get => selectedInTheEveningCheckBox; set => selectedInTheEveningCheckBox = value; }
        public bool SelectedBeforeBedCheckBox { get => selectedBeforeBedCheckBox; set => selectedBeforeBedCheckBox = value; }
        public ObservableCollection<Therapy> AllTherapies1 {
            get
            {
                List<Therapy> allTherapies = GetAllTherapies().ToList();

                ObservableCollection<Therapy> retVal = new ObservableCollection<Therapy>();

                foreach(Therapy therapy in allTherapies)
                {
                    retVal.Add(therapy);
                }

                return retVal;
            }
            set => AllTherapies = value;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private IEnumerable<Therapy> GetAllTherapies()
        {
            //poziv kontrolera

            //dummy data
            Medicine medicine1 = new Medicine("Brufen", 50, MedicineType.PILL, 5, 7);
            Medicine medicine2 = new Medicine("Kapi za nos", 10, MedicineType.DROPS, 5, 7);
            Medicine medicine3 = new Medicine("Perobrufen", 68, MedicineType.PILL, 5, 7);

            Dictionary<Medicine, TherapyDose> medicine = new Dictionary<Medicine, TherapyDose>();
            Dictionary<TherapyTime, double> dosage1 = new Dictionary<TherapyTime, double>();
            Dictionary<TherapyTime, double> dosage2 = new Dictionary<TherapyTime, double>();
            Dictionary<TherapyTime, double> dosage3 = new Dictionary<TherapyTime, double>();
            dosage1.Add(TherapyTime.Afternoon, 7);
            dosage1.Add(TherapyTime.BeforeBed, 3);
            dosage1.Add(TherapyTime.WhenIWakeUp, 2);

            dosage2.Add(TherapyTime.BeforeBed, 1);
            dosage2.Add(TherapyTime.AsNeeded, 6);

            dosage3.Add(TherapyTime.Afternoon, 22);

            medicine.Add(medicine1, new TherapyDose(dosage1));
            medicine.Add(medicine2, new TherapyDose(dosage2));
            medicine.Add(medicine3, new TherapyDose(dosage3));

            Prescription p1 = new Prescription(78, PrescriptionStatus.ACTIVE, new Doctor(new UserID("d78")), medicine);
            Prescription p2 = new Prescription(78, PrescriptionStatus.ACTIVE, new Doctor(new UserID("d78")), medicine);
            Prescription p3 = new Prescription(78, PrescriptionStatus.ACTIVE, new Doctor(new UserID("d78")), medicine);

            Therapy therapy1 = new Therapy(new TimeInterval(DateTime.Now, DateTime.Now.AddDays(18)), p1);
            Therapy therapy2 = new Therapy(new TimeInterval(DateTime.Now, DateTime.Now.AddDays(18)), p2);

            //retVal.Add(therapy1);
            //retVal.Add(therapy2);


            return null;
        }
    }
}
