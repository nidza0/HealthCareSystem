// File:    ManagerRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:34
// Purpose: Definition of Class ManagerRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.UsersRepository
{
    public class ManagerRepository : CSVRepository<Manager, UserID>, IManagerRepository, IEagerCSVRepository<Manager, UserID>
    {
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