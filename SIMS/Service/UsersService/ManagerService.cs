// File:    ManagerService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class ManagerService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;

namespace SIMS.Service.UsersService
{
    public class ManagerService : Util.IUserValidation, IService<Manager, UserID>, IUserService<Manager>
    {
        public IManagerRepository iManagerRepository;

        public bool CheckDateOfBirth(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool CheckEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool CheckName(string name)
        {
            throw new NotImplementedException();
        }

        public bool CheckPassword(string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public bool CheckUidn(string uidn)
        {
            throw new NotImplementedException();
        }

        public bool CheckUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Manager Create(Manager entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Manager entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manager> GetAll()
        {
            throw new NotImplementedException();
        }

        public Manager GetByID(UserID id)
        {
            throw new NotImplementedException();
        }

        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public Manager Update(Manager entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Manager user)
        {
            throw new NotImplementedException();
        }

        void IService<Manager, UserID>.Update(Manager entity)
        {
            throw new NotImplementedException();
        }
    }
}