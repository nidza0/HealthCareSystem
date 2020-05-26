// File:    ManagerRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:34
// Purpose: Definition of Class ManagerRepository

using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.UserRepository
{
    public class ManagerRepository : CSVRepository<Manager, UserID>, Abstract.User.IManagerRepository, IEagerCSVRepository<Manager, UserID>
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