// File:    DoctorService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class DoctorService

using System;
using System.Collections.Generic;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;

namespace SIMS.Service.UsersService
{
    public class DoctorService : Util.IUserValidation, IService<Doctor, UserID>, IUserService<Doctor>
    {
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
        {
            throw new NotImplementedException();
        }

        public bool CheckUsername(string username)
        {
            throw new NotImplementedException();
        }

        public bool CheckPassword(string password)
        {
            throw new NotImplementedException();
        }

        public bool CheckName(string name)
        {
            throw new NotImplementedException();
        }

        public bool CheckUidn(string uidn)
        {
            throw new NotImplementedException();
        }

        public bool CheckDateOfBirth(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool CheckEmail(string email)
        {
            throw new NotImplementedException();
        }

        public bool CheckPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Doctor GetByID(UserID id)
        {
            throw new NotImplementedException();
        }

        public Doctor Create(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public Doctor Update(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Doctor user)
        {
            throw new NotImplementedException();
        }

        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public IDoctorRepository iDoctorRepository;

    }
}