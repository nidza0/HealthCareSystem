// File:    RoomRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:38
// Purpose: Definition of Class RoomRepository

using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class RoomRepository : CSVRepository<Room, long>, IRoomRepository
    {
        private const string ENTITY_NAME = "Room";
        public RoomRepository(ICSVStream<Room> stream, ISequencer<long> sequencer) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Room>())
        {
        }

        public Room GetRoomByName(string name)
            => GetAll().SingleOrDefault(room => room.RoomNumber == name);

        public IEnumerable<Room> GetRoomsByFloor(int floor)
            => GetAll().Where(room => room.Floor == floor);

        public IEnumerable<Room> GetRoomsByType(RoomType type)
            => GetAll().Where(room => room.RoomType == type);
    }
}