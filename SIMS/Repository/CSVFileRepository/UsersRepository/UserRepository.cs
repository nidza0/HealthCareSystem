// File:    UserRepository.cs
// Author:  vule
// Created: 26. maj 2020 17:35:00
// Purpose: Definition of Class UserRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using System;

namespace SIMS.Repository.CSVFileRepository.UsersRepository
{
    public class UserRepository : CSVRepository<User, UserID>, IUserRepository
    {
        public User GetByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}