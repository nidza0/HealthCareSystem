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

        public RoomsViewModel()
        {
            RoomsCollection = CollectionViewSource.GetDefaultView(Rooms);
            RoomsCollection.Filter = new Predicate<object>(Filter);
        }

        public void LoadAllAvailableRooms(TimeInterval time)
        {
            //TODO: Load all available rooms by time

            LoadDummyRooms();
        }

        public void LoadRooms()
        {
            //TODO: Load all rooms

            LoadDummyRooms();
        }

        private void LoadDummyRooms()
        {
            Rooms.Add(new Room(47, "A456", false, 7, RoomType.EXAMINATION, null));
            Rooms.Add(new Room(47, "A4", false, 8, RoomType.EXAMINATION, null));
            Rooms.Add(new Room(47, "F89", false, 3, RoomType.AFTERCARE, null));
            Rooms.Add(new Room(47, "E45", false, 2, RoomType.EXAMINATION, null));
            Rooms.Add(new Room(47, "C3", false, 2, RoomType.OPERATION, null));
            Rooms.Add(new Room(47, "B567", false, 1, RoomType.OPERATION, null));
        }

        #region Filtering
        public ICollectionView RoomsCollection
        {
            get => roomsCollection;
            set
            {
                roomsCollection = value; NotifyPropertyChanged("PatientsCollection");
            }
        }
        public ObservableCollection<Room> Rooms { get => rooms; set => rooms = value; }

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
