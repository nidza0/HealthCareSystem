// File:    DoctorService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class DoctorService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.UsersRepository;

namespace SIMS.Service.UsersService
{
    public class DoctorService : Util.IUserValidation, IService<Doctor, UserID>, IUserService<Doctor>
    {
        DoctorRepository _doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public DoctorService()
        {

        }

        public IEnumerable<Doctor> GetActiveDoctors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetDoctorByType(DocTypeEnum doctorType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAvailableDoctorsByTime(Util.TimeInterval timeInterval)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetFilteredDoctors(Util.DoctorFilter filter)
            => _doctorRepository.GetFilteredDoctors(filter);

        public bool CheckUsername(string username)
            => Regex.IsMatch(username, "[a-zA-z_0-9]+");

        public bool CheckPassword(string password)
            => Regex.IsMatch(password, "[a-zA-z_0-9]+");

        public bool CheckName(string name)
            => Regex.IsMatch(name, "([A-Z][a-z]+)+");

        public bool CheckUidn(string uidn)
            => Regex.IsMatch(uidn, "[0-9]{13}");

        public bool CheckDateOfBirth(DateTime date)
            => DateTime.Compare(new DateTime(2000, 1, 1), date) > 0;

        public bool CheckEmail(string email)
            => Regex.IsMatch(email, "[A-Za-z_.]+@([A-Za-z.])+\\.[a-z]+$");

        public bool CheckPhoneNumber(string phoneNumber)
            => Regex.IsMatch(phoneNumber, "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[- /0-9]*$");

        public IEnumerable<Doctor> GetAll()
            => _doctorRepository.GetAllEager();

        public Doctor GetByID(UserID id)
            => _doctorRepository.GetByID(id);

        public Doctor Create(Doctor entity)
            => _doctorRepository.Create(entity);

        public void Delete(Doctor entity)
            => _doctorRepository.Delete(entity);

        //TODO: proveriti
        public void Validate(Doctor user)
            => _doctorRepository.Update(user);

        //TODO: proveriti
        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        void IService<Doctor, UserID>.Update(Doctor entity)
            => _doctorRepository.Update(entity);

        public IDoctorRepository iDoctorRepository;

    }
}