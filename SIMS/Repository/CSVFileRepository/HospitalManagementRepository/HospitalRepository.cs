// File:    HospitalRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:41
// Purpose: Definition of Class HospitalRepository

using System;
using System.Collections.Generic;
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
        public HospitalRepository(string entityName, ICSVStream<Hospital> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Hospital>())
        {
        }

        private void BindHospitalWithRooms(Hospital hospital, IEnumerable<Room> rooms)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hospital> GetHospitalByLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public Hospital GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hospital> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public RoomRepository roomRepository;

    }
}