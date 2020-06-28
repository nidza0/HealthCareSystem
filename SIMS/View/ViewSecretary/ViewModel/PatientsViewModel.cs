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
            patients = new ObservableCollection<Patient>(AppResources.getInstance().patientController.GetAll());
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
