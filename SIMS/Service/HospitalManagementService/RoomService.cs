// File:    RoomService.cs
// Author:  Geri
// Created: 19. maj 2020 20:24:02
// Purpose: Definition of Class RoomService

using System;
using System.Collections.Generic;
using Model.User;

namespace Service.HospitalManagementService
{
   public class RoomService : IService<Model.User.Room,long>
   {
      public IEnumerable<Room> GetRoomsByType(RoomType type)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Room> GetAvailableRoomsByDate(Util.TimeInterval timeInterval)
      {
         throw new NotImplementedException();
      }
      
      public bool DivideRooms(Model.User.Room initialRoom)
      {
         throw new NotImplementedException();
      }
      
      public Model.User.Room MergeRooms(IEnumerable<Room> roomsToMerge, String newName)
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

        public Repository.Abstract.HospitalManagement.IRoomRepository iRoomRepository;
   
   }
}