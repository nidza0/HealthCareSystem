// File:    ManagerRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:34
// Purpose: Definition of Class ManagerRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.UsersRepository
{
    public class ManagerRepository : CSVRepository<Manager, UserID>, IManagerRepository, IEagerCSVRepository<Manager, UserID>
    {
        public ManagerRepository(string entityName, ICSVStream<Manager> stream, ISequencer<UserID> sequencer) : base(entityName, stream, sequencer, new ManagerIdGeneratorStrategy())
        {
        }

        public IEnumerable<Manager> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Manager GetEager(UserID id)
        {
            throw new NotImplementedException();
        }
    }
}