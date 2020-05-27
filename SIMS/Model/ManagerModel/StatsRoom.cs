// File:    StatsRoom.cs
// Author:  vule
// Created: 18. april 2020 17:15:52
// Purpose: Definition of Class StatsRoom

using SIMS.Model.UserModel;
using System;

namespace SIMS.Model.ManagerModel
{
    public class StatsRoom : Stats
    {
        private double usage;
        private double timeOccupied;
        private int avgAppointmentTime;

        public System.Collections.Generic.List<Room> room;

        /// <summary>
        /// Property for collection of Model.User.Room
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Room> Room
        {
            get
            {
                if (room == null)
                    room = new System.Collections.Generic.List<Room>();
                return room;
            }
            set
            {
                RemoveAllRoom();
                if (value != null)
                {
                    foreach (Room oRoom in value)
                        AddRoom(oRoom);
                }
            }
        }

        /// <summary>
        /// Add a new Model.User.Room in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddRoom(Room newRoom)
        {
            if (newRoom == null)
                return;
            if (room == null)
                room = new System.Collections.Generic.List<Room>();
            if (!room.Contains(newRoom))
                room.Add(newRoom);
        }

        /// <summary>
        /// Remove an existing Model.User.Room from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveRoom(Room oldRoom)
        {
            if (oldRoom == null)
                return;
            if (room != null)
                if (room.Contains(oldRoom))
                    room.Remove(oldRoom);
        }

        /// <summary>
        /// Remove all instances of Model.User.Room from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllRoom()
        {
            if (room != null)
                room.Clear();
        }

    }
}