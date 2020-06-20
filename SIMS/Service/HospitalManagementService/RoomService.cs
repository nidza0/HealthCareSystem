// File:    RoomService.cs
// Author:  Geri
// Created: 19. maj 2020 20:24:02
// Purpose: Definition of Class RoomService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;

namespace SIMS.Service.HospitalManagementService
{
    public class RoomService : IService<Room, long>
    {
        public IEnumerable<Room> GetRoomsByType(RoomType type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetAvailableRoomsByDate(Util.TimeInterval timeInterval)
        {
            throw new NotImplementedException();
        }

        public bool DivideRooms(Room initialRoom)
        {
            throw new NotImplementedException();
        }

        public Room MergeRooms(IEnumerable<Room> roomsToMerge, string newName)
        {
            throw new NotImplementedException();
        }

        public Room GetRoomByName(string name)
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

        void IService<Room, long>.Update(Room entity)
        {
            throw new NotImplementedException();
        }

        public IRoomRepository iRoomRepository;

    }
}