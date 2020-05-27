// File:    RoomRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:38
// Purpose: Definition of Class RoomRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class RoomRepository : CSVRepository<Room, long>, IRoomRepository, IEagerCSVRepository<Room, long>
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