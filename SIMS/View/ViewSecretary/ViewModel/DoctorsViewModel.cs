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
        public ObservableCollection<Doctor> Doctors { get => doctors; set => doctors = value; }

        public void LoadAllAvailableDoctors(TimeInterval time)
        {
            //TODO: Load all available doctors
            var appointments = SecretaryAppResources.GetInstance().appointmentRepository.GetAppointmentsByTime(time);
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

            doctors = new ObservableCollection<Doctor>(availableDoctors);

            //LoadDummyDoctors();
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
            //LoadDummyDoctors();
        }

        private void LoadDummyDoctors()
        {
            Doctors.Add(new Doctor(new UserID("d678"),
                                "drstrange", null, DateTime.Now, "Stephen", "Strange", "Doctor", Sex.MALE, DateTime.Now, "45678545545", null, "07854953254", "0678454518421", "dr.strange@marvel.com", "email2", GetDummyTimetable(), new Hospital(4), new Room(5), Model.DoctorModel.DocTypeEnum.SURGEON));

            Doctors.Add(new Doctor(new UserID("d678"),
                                "doc", null, DateTime.Now, "Doctor", "doktor", "", Sex.FEMALE, DateTime.Now, "78458754696", null, "1784521945", "0685471259", "dr.dr@zdravo.rs", null, GetDummyTimetable(), new Hospital(6), new Room(7), Model.DoctorModel.DocTypeEnum.OPHTAMOLOGIST));
        }

        private TimeTable GetDummyTimetable() {
            Dictionary<WorkingDaysEnum, TimeInterval> shift = new Dictionary<WorkingDaysEnum, TimeInterval>();

            shift.Add(WorkingDaysEnum.MONDAY, new TimeInterval(new DateTime(2020, 1, 1, 7, 0, 0), new DateTime(2020, 1, 1, 13, 0, 0)));
            shift.Add(WorkingDaysEnum.TUESDAY, new TimeInterval(new DateTime(2020, 1, 1, 14, 0, 0), new DateTime(2020, 1, 1, 20, 0, 0)));
            shift.Add(WorkingDaysEnum.WEDNESDAY, new TimeInterval(new DateTime(2020, 1, 1, 7, 0, 0), new DateTime(2020, 1, 1, 13, 0, 0)));
            shift.Add(WorkingDaysEnum.THURSDAY, new TimeInterval(new DateTime(2020, 1, 1, 14, 0, 0), new DateTime(2020, 1, 1, 20, 0, 0)));
            shift.Add(WorkingDaysEnum.FRIDAY, new TimeInterval(new DateTime(2020, 1, 1, 7, 0, 0), new DateTime(2020, 1, 1, 13, 0, 0)));
            shift.Add(WorkingDaysEnum.SATURDAY, null);
            shift.Add(WorkingDaysEnum.SUNDAY, null);

            return new TimeTable(48, shift);
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
