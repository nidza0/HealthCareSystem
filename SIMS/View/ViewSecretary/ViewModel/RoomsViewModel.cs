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
    class RoomsViewModel
    {
        private ICollectionView roomsCollection;
        private ObservableCollection<Room> rooms = new ObservableCollection<Room>();
        private string filterString;
        private Room selectedRoom;

        public RoomsViewModel()
        {
            RoomsCollection = CollectionViewSource.GetDefaultView(Rooms);
            RoomsCollection.Filter = new Predicate<object>(Filter);
        }

        public void LoadAllAvailableRooms(TimeInterval time)
        {
            //TODO: Load all available rooms by time
            var appointments = SecretaryAppResources.GetInstance().appointmentRepository.GetAppointmentsByTime(time).Where(ap => !ap.Canceled);
            var allRooms = SecretaryAppResources.GetInstance().roomRepository.GetAll().ToList();

            foreach(Appointment a in appointments)
            {
                if(a.Room != null)
                {
                    allRooms.Remove(allRooms.First(r => r.GetId() == a.Room.GetId()));
                }
            }

            rooms.Clear();
            allRooms.ToList().ForEach(rooms.Add);
        }

        public void LoadRooms()
        {
            //TODO: Load all rooms
            var allRomms = SecretaryAppResources.GetInstance().roomRepository.GetAll();
            rooms.Clear();
            allRomms.ToList().ForEach(rooms.Add);
        }
        public ObservableCollection<Room> Rooms { get => rooms; set => rooms = value;  }

        #region Filtering
        public ICollectionView RoomsCollection
        {
            get => roomsCollection;
            set
            {
                roomsCollection = value; NotifyPropertyChanged("PatientsCollection");
            }
        }
        public Room SelectedRoom { get => selectedRoom; set { selectedRoom = value; NotifyPropertyChanged("SelectedRoom"); } }

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
            if (roomsCollection != null)
            {
                roomsCollection.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as Room;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterString))
                {
                    //TODO: filter logic
                    return data.RoomNumber.ToLower().Contains(filterString.ToLower()) || data.RoomType.ToString().ToLower().Contains(filterString.ToLower());
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
