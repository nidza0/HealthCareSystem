// File:    HospitalRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:41
// Purpose: Definition of Class HospitalRepository

using System;
using System.Collections.Generic;
using System.Linq;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class HospitalRepository : CSVRepository<Hospital, long>, IHospitalRepository, IEagerCSVRepository<Hospital, long>
    {
        private IRoomRepository _roomRepository;
        public HospitalRepository(string entityName, ICSVStream<Hospital> stream, ISequencer<long> sequencer, IRoomRepository roomRepository) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Hospital>())
        {
            _roomRepository = roomRepository;
        }

        private void BindHospitalWithRooms(IEnumerable<Hospital> hospitals, IEnumerable<Room> rooms)
            => hospitals.ToList().ForEach(hospital =>
            {
                hospital.Room = GetRoomsByIds(hospital.Room, hospital.Room.Select(room => room.GetId()));
            });

        private List<Room> GetRoomsByIds(IEnumerable<Room> rooms, IEnumerable<long> ids)
            => rooms.ToList().Where(room => ids.Contains(room.GetId())).ToList();



        public IEnumerable<Hospital> GetHospitalByLocation(Location location)
            => GetAll().ToList().Where(hospital => hospital.Address.Location.Equals(location));

        public Hospital GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(hospital => hospital.GetId() == id);

        public IEnumerable<Hospital> GetAllEager()
        {
            IEnumerable<Hospital> hospitals = GetAll();
            IEnumerable<Room> rooms = _roomRepository.GetAll();

            BindHospitalWithRooms(hospitals, rooms);

            return hospitals;
        }

        public RoomRepository roomRepository;

    }
}