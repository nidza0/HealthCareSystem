// File:    PatientService.cs
// Author:  Geri
// Created: 19. maj 2020 19:13:59
// Purpose: Definition of Class PatientService

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Exceptions;
using SIMS.Util;

namespace SIMS.Service.UsersService
{
    public class PatientService : IService<Patient, UserID>, IUserService<Patient>
    {
        PatientRepository _patientRepository;
        UserValidation _userValidation;

        public PatientService(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
            _userValidation = new UserValidation();
        }


        public IEnumerable<Patient> GetPatientByType(PatientType patientType)
            => _patientRepository.GetPatientByType(patientType);

        public IEnumerable<Patient> GetPatientByDoctor(Doctor doctor)
            => _patientRepository.GetPatientByDoctor(doctor);

        public IEnumerable<Patient> GetAll()
            => _patientRepository.GetAllEager();

        public Patient GetByID(UserID id)
            => _patientRepository.GetByID(id);

        public Patient Create(Patient entity)
        {
            Validate(entity);
            return _patientRepository.Create(entity);
        }

        public void Delete(Patient entity)
            => _patientRepository.Delete(entity);

        public void Validate(Patient user)
            => _userValidation.Validate(user);

        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient entity)
        {
            Validate(entity);
            _patientRepository.Update(entity);
        }

        public IPatientRepository iPatientRepository;

    }
}