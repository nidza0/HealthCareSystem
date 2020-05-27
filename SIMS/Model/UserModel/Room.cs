/***********************************************************************
 * Module:  Room.cs
 * Author:  vule
 * Purpose: Definition of the Class Room
 ***********************************************************************/

using System;
using SIMS.Model.ManagerModel;

namespace SIMS.Model.UserModel
{
    public class Room
    {
        private long _id;
        private string _roomNumber;
        private bool _occupied;
        private int _floor;
        private RoomType _roomType;
        private InventoryItem _inventoryItem;

        public Room(long id, string roomNumber, bool occupied, int floor, RoomType roomType, InventoryItem inventoryItem)
        {
            _id = id;
            _roomNumber = roomNumber;
            _occupied = occupied;
            _floor = floor;
            _roomType = roomType;
            _inventoryItem = inventoryItem;
        }

        public long ID { get => _id; set => _id = value; }
        public string RoomNumber { get => _roomNumber; set => _roomNumber = value; }
        public bool Occupied { get => _occupied; set => _occupied = value; }
        public int Floor { get => _floor; set => _floor = value; }
        public RoomType RoomType { get => _roomType; set => _roomType = value; }
        public InventoryItem InventoryItem { get => _inventoryItem; set => _inventoryItem = value; }

        public bool Reserve()
        {
            throw new NotImplementedException();
        }

        public int Filter()
        {
            throw new NotImplementedException();
        }

        public bool AddAppointment()
        {
            throw new NotImplementedException();
        }

        public bool RemoveAppointment()
        {
            throw new NotImplementedException();
        }

        public bool EditAppointment()
        {
            throw new NotImplementedException();
        }

        

    }
}