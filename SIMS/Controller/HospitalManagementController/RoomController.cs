// File:    RoomController.cs
// Author:  Geri
// Created: 20. maj 2020 11:07:40
// Purpose: Definition of Class RoomController

using System;
using System.Collections.Generic;
using Model.User;
using Util;
using Service.HospitalManagementService;

namespace Controller.HospitalManagementController
{
   public class RoomController : IController<Room, long>
   {
      public IEnumerable<Room> GetRoomsByType(RoomType type)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Room> GetAvailableRoomsByDate(TimeInterval timeInterval)
      {
         throw new NotImplementedException();
      }
      
      public bool DivideRooms(Room initialRoom)
      {
         throw new NotImplementedException();
      }
      
      public Room MergeRooms(IEnumerable<Room> roomsToMerge, String newName)
      {
         throw new NotImplementedException();
      }
      
      public Model.User.Room GetRoomByName(string name)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Room> GetRoomsByFloor(int floor)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<Room> GetAll()
        {
            throw new NotImplementedException();
        }

        public Room GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Room Create(Room entity)
        {
            throw new NotImplementedException();
        }

        public Room Update(Room entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Room entity)
        {
            throw new NotImplementedException();
        }

        public RoomService roomService;
   
   }
}