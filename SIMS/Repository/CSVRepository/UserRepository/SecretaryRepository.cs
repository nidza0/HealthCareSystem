// File:    SecretaryRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:34
// Purpose: Definition of Class SecretaryRepository

using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.UserRepository
{
    public class SecretaryRepository : CSVRepository<Secretary, UserID>, Abstract.User.ISecretaryRepository, IEagerCSVRepository<Secretary, UserID>
    {
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