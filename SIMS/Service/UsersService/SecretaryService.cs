// File:    SecretaryService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class SecretaryService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;

namespace SIMS.Service.UsersService
{
    public class SecretaryService : Util.IUserValidation, IService<Secretary, UserID>, IUserService<Secretary>
    {
        public ISecretaryRepository iSecretaryRepository;

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

        public Secretary Create(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Secretary> GetAll()
        {
            throw new NotImplementedException();
        }

        public Secretary GetByID(UserID id)
        {
            throw new NotImplementedException();
        }

        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public Secretary Update(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Secretary user)
        {
            throw new NotImplementedException();
        }
    }
}