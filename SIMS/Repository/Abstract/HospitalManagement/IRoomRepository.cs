// File:    IRoomRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 13:58:05
// Purpose: Definition of Interface IRoomRepository

using System;
using System.Collections.Generic;
using Model.User;

namespace Repository.Abstract.HospitalManagement
{
   public interface IRoomRepository : IRepository<Model.User.Room,long>
   {
      IEnumerable<Room> GetRoomsByType(RoomType type);
      
      Model.User.Room GetRoomByName(string name);
      
      IEnumerable<Room> GetRoomsByFloor(int floor);
   
   }
}