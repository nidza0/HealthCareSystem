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
        private long id;
        private string roomNumber;
        private bool occupied;
        private int floor;

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

        public RoomType roomType;
        public InventoryItem inventoryItem;

    }
}