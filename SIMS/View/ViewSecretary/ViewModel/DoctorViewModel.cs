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
            this.doctor = doctor;
            LoadDoctorsAppointments();
            ConvertDoctorTimetableToList();
        }

        private void ConvertDoctorTimetableToList()
        {
            TimeTable timetable = doctor.TimeTable;
            if(timetable != null)
            {
                Shifts.Add(timetable.getWorkingHours()[WorkingDaysEnum.MONDAY]);
                Shifts.Add(timetable.getWorkingHours()[WorkingDaysEnum.TUESDAY]);
                Shifts.Add(timetable.getWorkingHours()[WorkingDaysEnum.WEDNESDAY]);
                Shifts.Add(timetable.getWorkingHours()[WorkingDaysEnum.THURSDAY]);
                Shifts.Add(timetable.getWorkingHours()[WorkingDaysEnum.FRIDAY]);
                Shifts.Add(timetable.getWorkingHours()[WorkingDaysEnum.SATURDAY]);
                Shifts.Add(timetable.getWorkingHours()[WorkingDaysEnum.SUNDAY]);
            }
        }

        private void LoadEagerDoctor(Doctor doctor)
        {
            //TODO: Load Doctor With Timetable
        }

        private void LoadDoctorsAppointments()
        {
            //TODO: Load doctors appointments

            Appointments.Add(new Appointment(78,
                            new Doctor(new UserID("d678"),
                                null, null, DateTime.Now, "Stephen", "Strange", "Doctor", Sex.MALE, DateTime.Now, null, null, null, null, null, null, null, null, null, Model.DoctorModel.DocTypeEnum.SURGEON),
                            new Patient(new UserID("p3"),
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
                                        null),
                            new Room(2, "A456", false, 3, RoomType.EXAMINATION, null),
                            AppointmentType.checkup,
                            new TimeInterval(DateTime.Now.AddMinutes(5), DateTime.Now.AddMinutes(20))));

            Appointments.Add(new Appointment(78,
                            new Doctor(new UserID("d678"),
                                null, null, DateTime.Now, "Doctor", "House", "", Sex.MALE, DateTime.Now, null, null, null, null, null, null, null, null, null, Model.DoctorModel.DocTypeEnum.SURGEON),
                            new Patient(new UserID("p1"),
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
                                        null),
                            new Room(3, "B34", false, 3, RoomType.EXAMINATION, null),
                            AppointmentType.checkup,
                            new TimeInterval(DateTime.Now.AddMinutes(20), DateTime.Now.AddMinutes(35))));

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
