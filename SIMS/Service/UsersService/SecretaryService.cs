// File:    SecretaryService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class SecretaryService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.UsersRepository;

namespace SIMS.Service.UsersService
{
    public class SecretaryService : Util.IUserValidation, IService<Secretary, UserID>, IUserService<Secretary>
    {
        SecretaryRepository _secretaryRepository;

        string usernameRegex = "[a-zA-Z_0-9]+";
        string passwordRegex = "[a-zA-Z_0-9]+";
        string nameRegex = "([A-Z][a-z]+)+";
        string uidnRegex = "[0-9]{13}";
        string emailRegex = "[A-Za-z_.]+@([A-Za-z.])+\\.[a-z]+$";
        string phoneRegex = "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[- /0-9]*$";

        public SecretaryService(SecretaryRepository secretaryRepository)
        {
            _secretaryRepository = secretaryRepository;
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

        public Secretary Create(Secretary entity)
            => _secretaryRepository.Create(entity);

        public void Delete(Secretary entity)
            => _secretaryRepository.Delete(entity);

        public IEnumerable<Secretary> GetAll()
            => _secretaryRepository.GetAllEager();

        public Secretary GetByID(UserID id)
            => _secretaryRepository.GetByID(id);

        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public void Validate(Secretary user)
        {
            
        }

        public void Update(Secretary entity)
            => _secretaryRepository.Update(entity);
    }
}