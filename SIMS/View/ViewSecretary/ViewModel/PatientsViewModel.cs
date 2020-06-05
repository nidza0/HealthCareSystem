using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace SIMS.View.ViewSecretary.ViewModel
{
    class PatientsViewModel
    {
        private ICollectionView patientsCollection;
        private ObservableCollection<Patient> patients = new ObservableCollection<Patient>();
        private string filterString;

        public PatientsViewModel()
        {
            loadPatients();
            PatientsCollection = CollectionViewSource.GetDefaultView(Patients);
            PatientsCollection.Filter = new Predicate<object>(Filter);
        }

        private void loadPatients()
        {
            //TODO: PatientController > Get All Patients

            Patients.Add(new Patient(new UserID("p1"),
                                        "peraaa13",
                                        "",
                                        DateTime.Now,
                                        "Pera",
                                        "Peric",
                                        "P.",
                                        Sex.MALE,
                                        new DateTime(1987, 10, 12),
                                        "01234678",
                                        new Address("Bul. Mihajla Pupina 6", new Location(1, "Serbia", "Novi Sad")),
                                        "0217878787",
                                        "25848596532",
                                        "pera@peric.rs",
                                        "",
                                        new EmergencyContact("Milan", "Milanovic", "", "025478956325"),
                                        PatientType.GENERAL,
                                        null));

            Patients.Add(new Patient(new UserID("p3"),
                                        "milica92",
                                        "",
                                        DateTime.Now,
                                        "Milica",
                                        "Mikic",
                                        "M.",
                                        Sex.FEMALE,
                                        new DateTime(1992, 11, 7),
                                        "9876543221",
                                        new Address("Partizanska 5", new Location(1, "Serbia", "Novi Sad")),
                                        "0213698569",
                                        "06454545454",
                                        "milica@gmail.com",
                                        "",
                                        new EmergencyContact("Milana", "Milanovic", "", "0217474859"),
                                        PatientType.GENERAL,
                                        null));

            Patients.Add(new Patient(new UserID("p1"),
                                        "alien65",
                                        "",
                                        DateTime.Now,
                                        "X Æ A-Xii",
                                        "Musk",
                                        "X.",
                                        Sex.OTHER,
                                        new DateTime(2020, 5, 4),
                                        "8742154780000",
                                        new Address("Some fancy stree", new Location(2, "Los Angeles", "USA")),
                                        "545846543",
                                        "56202154821",
                                        "xaeaxii@elonmusk.com",
                                        "",
                                        new EmergencyContact("Elon", "Musk", "elon@musk.com", "75315454545"),
                                        PatientType.GENERAL,
                                        GetDummyDoctor()));
        }

        private Doctor GetDummyDoctor()
        {
            return new Doctor(new UserID("d678"),
                                null, null, DateTime.Now, "Stephen", "Strange", "Doctor", Sex.MALE, DateTime.Now, null, null, null, null, null, null, null, null, null, Model.DoctorModel.DocTypeEnum.SURGEON);
        }

        #region Filtering
        public ICollectionView PatientsCollection
        {
            get => patientsCollection;
            set
            {
                patientsCollection = value; NotifyPropertyChanged("PatientsCollection");
            }
        }
        public ObservableCollection<Patient> Patients { get => patients; set => patients = value; }

        public string FilterString
        {
            get { return filterString; }
            set
            {
                filterString = value;
                NotifyPropertyChanged("FilterString");
                FilterCollection();
            }
        }

        private void FilterCollection()
        {
            if (patientsCollection != null)
            {
                patientsCollection.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as Patient;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterString))
                {
                    //TODO: filter logic
                    return data.FullName.ToLower().Contains(filterString.ToLower()) || data.Uidn.Contains(filterString);
                }
                return true;
            }
            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

#endregion Filtering
    }
}
