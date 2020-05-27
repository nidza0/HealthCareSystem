// File:    StatsRoom.cs
// Author:  vule
// Created: 18. april 2020 17:15:52
// Purpose: Definition of Class StatsRoom

using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;

namespace SIMS.Model.ManagerModel
{
    public class StatsRoom : Stats
    {
        private double _usage;
        private double _timeOccupied;
        private int _avgAppointmentTime;

        public List<Room> room;

        public double Usage { get { return _usage; } set { } }

        public double TimeOccupied { get { return _timeOccupied; } set { } }


        /// <summary>
        /// Property for collection of Model.User.Room
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Room> Room
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

        public StatsRoom(double usage, double timeOccupied, int avgAppointmentTime, List<Room> room): base()
        {
            _usage = usage;
            _timeOccupied = timeOccupied;
            _avgAppointmentTime = avgAppointmentTime;
            this.room = room;
        }

        public StatsRoom(long id): base(id)
        {

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