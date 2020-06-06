// File:    SecretaryRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:34
// Purpose: Definition of Class SecretaryRepository

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
    public class SecretaryRepository : CSVRepository<Secretary, UserID>, ISecretaryRepository, IEagerCSVRepository<Secretary, UserID>
    {
        public SecretaryRepository(string entityName, ICSVStream<Secretary> stream, ISequencer<UserID> sequencer) : base(entityName, stream, sequencer, new SecretaryIdGeneratorStrategy())
        {
        }

        public IEnumerable<Secretary> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Secretary GetEager(UserID id)
        {
            throw new NotImplementedException();
        }
    }
}