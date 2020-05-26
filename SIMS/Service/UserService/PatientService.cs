// File:    PatientService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class PatientService

using System;
using System.Collections.Generic;
using Model.User;

namespace Service.UserService
{
   public class PatientService : Util.IUserValidation, IService<Patient, UserID>, IUserService<Patient>
   {
      public IEnumerable<Patient> GetPatientByType(Model.User.PatientType patientType)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Patient> GetPatientByDoctor(Model.User.Doctor doctor)
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

        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient GetByID(UserID id)
        {
            throw new NotImplementedException();
        }

        public Patient Create(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Patient Update(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Patient user)
        {
            throw new NotImplementedException();
        }

        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public Repository.Abstract.User.IPatientRepository iPatientRepository;
   
   }
}