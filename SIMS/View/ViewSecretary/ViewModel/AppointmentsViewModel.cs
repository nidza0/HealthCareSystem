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

        private TimeInterval GetDayTimeInterval(DateTime date)
        {
            return new TimeInterval(new DateTime(date.Year, date.Month, date.Day, 0, 0, 0), new DateTime(date.Year, date.Month, date.Day, 0, 0, 0).AddDays(1));
        }

        public void LoadCancelledAppointments()
        {
            var cancelledAppointments = SecretaryAppResources.GetInstance().appointmentRepository.GetCanceledAppointments();
            Appointments.Clear();
            cancelledAppointments.ToList().ForEach(Appointments.Add);
        }

        public void LoadAppointments(DateTime date)
        {
            TimeInterval time = GetDayTimeInterval(date);
            Appointments.Clear();
            var appointments = new ObservableCollection<Appointment>(SecretaryAppResources.GetInstance().appointmentRepository.GetAppointmentsByTime(time)).Where(ap => !ap.Canceled).OrderBy(ap => ap.TimeInterval.StartTime);
            appointments.ToList().ForEach(Appointments.Add);
        }

        private void LoadRooms()
        {
            //TODO Load all rooms
            var allRomms = SecretaryAppResources.GetInstance().roomRepository.GetAll();
            rooms.Clear();
            allRomms.ToList().ForEach(rooms.Add);
        }

        public void LoadAppointmentsByRoomWithFreeTime(DateTime date, Room room)
        {
            TimeInterval time = GetDayTimeInterval(date);
            var roomAppointments = SecretaryAppResources.GetInstance().appointmentRepository.GetAppointmentsByTime(time).Where(ap => !ap.Canceled && ap.Room.GetId() == room.GetId()).OrderBy(ap => ap.TimeInterval.StartTime).ToList();
            appointments.Clear();
            int minutesDuration = 15;
            DateTime start1 = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0);
            DateTime start2 = new DateTime(date.Year, date.Month, date.Day, 7, 0, 0).AddMinutes(minutesDuration);
            DateTime end = new DateTime(date.Year, date.Month, date.Day, 19, 0, 0);

            for(int i = 0; i<roomAppointments.Count(); i++)
            {
                
                while(!roomAppointments[i].TimeInterval.IsOverlappingWith(new TimeInterval(start1, start2)))
                {
                    appointments.Add(new Appointment(null, null, room, AppointmentType.free, new TimeInterval(start1, start2)));
                    start1 = start2;
                    start2 = start1.AddMinutes(minutesDuration);
                }
                appointments.Add(roomAppointments[i]);
                start1 = roomAppointments[i].TimeInterval.EndTime;
                start2 = start1.AddMinutes(minutesDuration);

                if(i == roomAppointments.Count() - 1)//last one
                {
                    while(start2 <= end)
                    {
                        appointments.Add(new Appointment(null, null, room, AppointmentType.free, new TimeInterval(start1, start2)));
                        start1 = start2;
                        start2 = start1.AddMinutes(minutesDuration);
                    }
                }
            }

            if(roomAppointments.Count() == 0)
            {
                while (start2 <= end)
                {
                    appointments.Add(new Appointment(null, null, room, AppointmentType.free, new TimeInterval(start1, start2)));
                    start1 = start2;
                    start2 = start1.AddMinutes(minutesDuration);
                }
            }
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
                    return (data.Patient == null ? false : data.Patient.FullName.ToLower().Contains(filterString.ToLower())) || (data.DoctorInAppointment == null ? false : data.DoctorInAppointment.FullName.ToLower().Contains(filterString.ToLower())) || (data.Room == null ? false : data.Room.RoomNumber.ToLower().Contains(filterString.ToLower()));
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
