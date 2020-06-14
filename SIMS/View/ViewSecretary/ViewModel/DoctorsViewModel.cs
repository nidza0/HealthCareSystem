using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Util;
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
            //LoadDoctors();
            DoctorsCollection = CollectionViewSource.GetDefaultView(Doctors);
            DoctorsCollection.Filter = new Predicate<object>(Filter);
        }

        public ICollectionView DoctorsCollection { get => doctorsCollection; set => doctorsCollection = value; }
        public ObservableCollection<Doctor> Doctors { get => doctors; set { doctors = value; NotifyPropertyChanged("Doctors"); } }

        public void LoadAllAvailableDoctors(TimeInterval time)
        {
            //TODO: Load all available doctors
            var appointments = SecretaryAppResources.GetInstance().appointmentRepository.GetAppointmentsByTime(time).Where(ap => !ap.Canceled);
            var allDoctors = SecretaryAppResources.GetInstance().doctorRepository.GetAllEager();

            foreach(Appointment a in appointments)
            {
                if(a.DoctorInAppointment != null)
                {
                    allDoctors = allDoctors.Where(d => !d.GetId().Equals(a.DoctorInAppointment.GetId()));
                }
            }

            List<Doctor> availableDoctors = new List<Doctor>();

            foreach(Doctor doctor in allDoctors)
            {
                if(doctor.TimeTable != null)
                {
                    WorkingDaysEnum day = GetWorkingDay(time.StartTime.DayOfWeek);
                    if (doctor.TimeTable.getWorkingHours().ContainsKey(day))
                    {
                        if (doctor.TimeTable.getWorkingHours()[day].IsTimeBetween(time))
                        {
                            availableDoctors.Add(doctor);
                        }
                    }
                }
            }

            Doctors.Clear();
            availableDoctors.ToList().ForEach(Doctors.Add);
        }

        internal void LoadDoctorsAtWork()
        {
            var allDoctors = SecretaryAppResources.GetInstance().doctorRepository.GetAllEager();
            Doctors.Clear();
            foreach(Doctor doc in allDoctors)
            {
                WorkingDaysEnum day = GetWorkingDay(DateTime.Now.DayOfWeek);
                if(doc.TimeTable != null)
                {
                    if (doc.TimeTable.getWorkingHours().ContainsKey(day))
                    {
                        if (doc.TimeTable.getWorkingHours()[day].IsDateTimeBetween(DateTime.Now))
                        {
                            Doctors.Add(doc);
                        }
                    }
                }
            }
        }

        private WorkingDaysEnum GetWorkingDay(DayOfWeek d)
        {
            switch (d)
            {
                case DayOfWeek.Monday: return WorkingDaysEnum.MONDAY;
                case DayOfWeek.Tuesday: return WorkingDaysEnum.TUESDAY;
                case DayOfWeek.Wednesday: return WorkingDaysEnum.WEDNESDAY;
                case DayOfWeek.Thursday: return WorkingDaysEnum.THURSDAY;
                case DayOfWeek.Friday: return WorkingDaysEnum.FRIDAY;
                case DayOfWeek.Saturday: return WorkingDaysEnum.SATURDAY;
                case DayOfWeek.Sunday: return WorkingDaysEnum.SUNDAY;
                default: return WorkingDaysEnum.MONDAY;
            }

        }

        public void LoadAllDoctors()
        {
            //TODO: Load all doctors
            doctors = new ObservableCollection<Doctor>(SecretaryAppResources.GetInstance().doctorRepository.GetAllEager());
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

        internal bool IsDoctorAvailable(Doctor doc, TimeInterval t)
        {
            LoadAllAvailableDoctors(t);
            Console.WriteLine("Available doctors");
            doctors.ToList().ForEach(d => Console.WriteLine(d.GetId().ToString()));
            Console.WriteLine("Selected doctor: " + doc.GetId().ToString());
            return doctors.FirstOrDefault(d => d.GetId().Equals(doc.GetId())) != null;
        }
    }
}
