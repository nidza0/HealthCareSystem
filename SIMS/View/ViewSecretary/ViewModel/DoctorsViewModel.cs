using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SIMS.View.ViewSecretary.ViewModel
{
    class DoctorsViewModel
    {
        private ICollectionView doctorsCollection;
        private ObservableCollection<Doctor> doctors = new ObservableCollection<Doctor>();
        private string filterString;

        public DoctorsViewModel()
        {
            LoadDoctors();
            DoctorsCollection = CollectionViewSource.GetDefaultView(Doctors);
            DoctorsCollection.Filter = new Predicate<object>(Filter);
        }

        public ICollectionView DoctorsCollection { get => doctorsCollection; set => doctorsCollection = value; }
        public ObservableCollection<Doctor> Doctors { get => doctors; set => doctors = value; }

        private void LoadDoctors()
        {
            //TODO: Load all doctors

            LoadDummyDoctors();
        }

        private void LoadDummyDoctors()
        {
            Doctors.Add(new Doctor(new UserID("d678"),
                                null, null, DateTime.Now, "Stephen", "Strange", "Doctor", Sex.MALE, DateTime.Now, "45678545545", null, "07854953254", "0678454518421", "dr.strange@marvel.com", null, null, null, null, Model.DoctorModel.DocTypeEnum.SURGEON));

            Doctors.Add(new Doctor(new UserID("d678"),
                                null, null, DateTime.Now, "Doctor", "doktor", "", Sex.FEMALE, DateTime.Now, "78458754696", null, "1784521945", "0685471259", "dr.dr@zdravo.rs", null, null, null, null, Model.DoctorModel.DocTypeEnum.OPHTAMOLOGIST));
        }

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
            if (doctorsCollection != null)
            {
                doctorsCollection.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as Doctor;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterString))
                {
                    //TODO: filter logic
                    return data.FullName.ToLower().Contains(filterString.ToLower());
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
    }
}
