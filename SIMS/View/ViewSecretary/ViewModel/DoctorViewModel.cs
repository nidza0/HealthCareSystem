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

namespace SIMS.View.ViewSecretary.ViewModel
{
    class DoctorViewModel
    {
        private Doctor doctor;
        private List<TimeInterval> shifts = new List<TimeInterval>();
        private ICollectionView appointmentsCollection;
        private ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>();
        private string filterString;
        public Doctor Doctor { get => doctor; set => doctor = value; }
        public DoctorViewModel(Doctor doctor)
        {
            LoadEagerDoctor(doctor);
            LoadDoctorsAppointments();
            ConvertDoctorTimetableToList();
        }

        private void ConvertDoctorTimetableToList()
        {
            TimeTable timetable = doctor.TimeTable;

            if (timetable != null)
            {
                Dictionary<WorkingDaysEnum, TimeInterval> sh = timetable.getWorkingHours();
                shifts.Add(sh.ContainsKey(WorkingDaysEnum.MONDAY) ? sh[WorkingDaysEnum.MONDAY] : null);
                shifts.Add(sh.ContainsKey(WorkingDaysEnum.TUESDAY) ? sh[WorkingDaysEnum.TUESDAY] : null);
                shifts.Add(sh.ContainsKey(WorkingDaysEnum.WEDNESDAY) ? sh[WorkingDaysEnum.WEDNESDAY] : null);
                shifts.Add(sh.ContainsKey(WorkingDaysEnum.THURSDAY) ? sh[WorkingDaysEnum.THURSDAY] : null);
                shifts.Add(sh.ContainsKey(WorkingDaysEnum.FRIDAY) ? sh[WorkingDaysEnum.FRIDAY] : null);
                shifts.Add(sh.ContainsKey(WorkingDaysEnum.SATURDAY) ? sh[WorkingDaysEnum.SATURDAY] : null);
                shifts.Add(sh.ContainsKey(WorkingDaysEnum.SUNDAY) ? sh[WorkingDaysEnum.SUNDAY] : null);
            }
        }

        private void LoadEagerDoctor(Doctor d)
        {
            doctor = AppResources.getInstance().doctorController.GetByID(d.GetId());
        }

        private void LoadDoctorsAppointments()
        {
            //TODO: Load doctors appointments
            appointments = new ObservableCollection<Appointment>(AppResources.getInstance().appointmentController.GetUpcomingAppointmentsForDoctor(doctor));
        }

        public List<TimeInterval> Shifts { get => shifts; set => shifts = value; }

        #region Filtering
        public ICollectionView AppointmentsCollection
        {
            get => appointmentsCollection;
            set
            {
                appointmentsCollection = value; NotifyPropertyChanged("AppointmentsCollection");
            }
        }
        public ObservableCollection<Appointment> Appointments { get => appointments; set => appointments = value; }

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
            if (appointmentsCollection != null)
            {
                appointmentsCollection.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as Appointment;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterString))
                {
                    //TODO: filter logic
                    return data.Patient.FullName.ToLower().Contains(filterString.ToLower()) || data.Room.RoomNumber.ToLower().Contains(filterString.ToLower());
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
