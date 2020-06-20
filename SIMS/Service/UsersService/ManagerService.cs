// File:    ManagerService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class ManagerService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.UsersRepository;

namespace SIMS.Service.UsersService
{
    public class ManagerService : Util.IUserValidation, IService<Manager, UserID>, IUserService<Manager>
    {
        ManagerRepository _managerRepository;

        string usernameRegex = "[a-zA-Z_0-9]+";
        string passwordRegex = "[a-zA-Z_0-9]+";
        string nameRegex = "([A-Z][a-z]+)+";
        string uidnRegex = "[0-9]{13}";
        string emailRegex = "[A-Za-z_.]+@([A-Za-z.])+\\.[a-z]+$";
        string phoneRegex = "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[- /0-9]*$";

        public ManagerService(ManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public bool CheckDateOfBirth(DateTime date)
            => DateTime.Compare(new DateTime(2000, 1, 1), date) > 0;

        public bool CheckEmail(string email)
            => Regex.IsMatch(email, emailRegex);

        public bool CheckName(string name)
            => Regex.IsMatch(name, nameRegex);

        public bool CheckPassword(string password)
            => Regex.IsMatch(password, passwordRegex);

        public bool CheckPhoneNumber(string phoneNumber)
            => Regex.IsMatch(phoneNumber, phoneRegex);

        public bool CheckUidn(string uidn)
            => Regex.IsMatch(uidn, uidnRegex);

        public bool CheckUsername(string username)
            => Regex.IsMatch(username, usernameRegex);

        public Manager Create(Manager entity)
            => _managerRepository.Create(entity);

        public void Delete(Manager entity)
            => _managerRepository.Delete(entity);

        public IEnumerable<Manager> GetAll()
            => _managerRepository.GetAll();

        public Manager GetByID(UserID id)
            => _managerRepository.GetByID(id);

        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public void Validate(Manager user)
        {
            throw new NotImplementedException();
        }

        void IService<Manager, UserID>.Update(Manager entity)
        => _managerRepository.Update(entity);
    }
}