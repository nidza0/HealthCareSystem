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
    class AppointmentsViewModel
    {
        private ICollectionView appointmentsCollection;
        private ObservableCollection<Appointment> appointments = new ObservableCollection<Appointment>();
        private string filterString;
        private ObservableCollection<Room> rooms = new ObservableCollection<Room>();

        public ICollectionView AppointmentsCollection { get => appointmentsCollection; set => appointmentsCollection = value; }
        public ObservableCollection<Appointment> Appointments { get => appointments; set => appointments = value; }
        public ObservableCollection<Room> Rooms { get => rooms; set => rooms = value; }

        public AppointmentsViewModel()
        {
            LoadRooms();
            AppointmentsCollection = CollectionViewSource.GetDefaultView(Appointments);
            AppointmentsCollection.Filter = new Predicate<object>(Filter);
        }

        

        public void LoadAppointments(DateTime date)
        {
            TimeInterval time = new TimeInterval(new DateTime(date.Year, date.Month, date.Day, 0, 0, 0), new DateTime(date.Year, date.Month, date.Day, 0, 0, 0).AddDays(1));
            Appointments = new ObservableCollection<Appointment>(SecretaryAppResources.GetInstance().appointmentRepository.GetAppointmentsByTime(time));

            //LoadDummyAppointments();
        }

        private void LoadDummyAppointments()
        {
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
                            new Room(2, "A456", false, 3, RoomType.EXAMINATION),
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
                            new Room(3, "B34", false, 3, RoomType.EXAMINATION),
                            AppointmentType.checkup,
                            new TimeInterval(DateTime.Now.AddMinutes(20), DateTime.Now.AddMinutes(35))));
        }

        private void LoadRooms()
        {
            //TODO Load all rooms
            Rooms.Add(new Room(401, "A4", false, 4, RoomType.EXAMINATION));
            Rooms.Add(new Room(503, "C5", false, 5, RoomType.EXAMINATION));
            Rooms.Add(new Room(302, "B3", false, 3, RoomType.EXAMINATION));

            Rooms.Insert(0, new Room(0, "", false, 0, RoomType.EXAMINATION));
        }

        #region Filtering
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
                    return data.Patient.FullName.ToLower().Contains(filterString.ToLower()) || data.DoctorInAppointment.FullName.ToLower().Contains(filterString.ToLower()) || data.Room.RoomNumber.ToLower().Equals(filterString.ToLower());
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
