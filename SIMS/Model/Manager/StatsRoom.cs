// File:    StatsRoom.cs
// Author:  vule
// Created: 18. april 2020 17:15:52
// Purpose: Definition of Class StatsRoom

using Model.User;
using System;

namespace Model.Manager
{
   public class StatsRoom : Stats
   {
      private Double usage;
      private Double timeOccupied;
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
               foreach (Model.User.Room oRoom in value)
                  AddRoom(oRoom);
            }
         }
      }
      
      /// <summary>
      /// Add a new Model.User.Room in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddRoom(Model.User.Room newRoom)
      {
         if (newRoom == null)
            return;
         if (this.room == null)
            this.room = new System.Collections.Generic.List<Room>();
         if (!this.room.Contains(newRoom))
            this.room.Add(newRoom);
      }
      
      /// <summary>
      /// Remove an existing Model.User.Room from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveRoom(Model.User.Room oldRoom)
      {
         if (oldRoom == null)
            return;
         if (this.room != null)
            if (this.room.Contains(oldRoom))
               this.room.Remove(oldRoom);
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