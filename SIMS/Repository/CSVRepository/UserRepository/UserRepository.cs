// File:    UserRepository.cs
// Author:  vule
// Created: 26. maj 2020 17:35:00
// Purpose: Definition of Class UserRepository

using Model.User;
using Repository.CSVRepository.Csv;
using System;

namespace Repository.CSVRepository.UserRepository
{
    public class UserRepository : CSVRepository<User, UserID>, Abstract.User.IUserRepository
    {
        public User GetByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}