// File:    RoomRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:38
// Purpose: Definition of Class RoomRepository

using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.HospitalManagementRepository
{
    public class RoomRepository : CSVRepository<Model.User.Room, long>, Repository.Abstract.HospitalManagement.IRoomRepository, IEagerCSVRepository<Model.User.Room, long>
    {
        public IEnumerable<Room> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Room GetEager(long id)
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

        public IEnumerable<Room> GetRoomsByType(RoomType type)
        {
            throw new NotImplementedException();
        }
    }
}