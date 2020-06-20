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

namespace SIMS.Service.UsersService
{
    public class PatientService : Util.IUserValidation, IService<Patient, UserID>, IUserService<Patient>
    {
        PatientRepository _patientRepository;

        string usernameRegex = "[a-zA-Z_0-9]+";
        string passwordRegex = "[a-zA-Z_0-9]+";
        string nameRegex = "([A-Z][a-z]+)+";
        string uidnRegex = "[0-9]{13}";
        string emailRegex = "[A-Za-z_.]+@([A-Za-z.])+\\.[a-z]+$";
        string phoneRegex = "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[- /0-9]*$";

        public PatientService(PatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        public IEnumerable<Patient> GetPatientByType(PatientType patientType)
            => _patientRepository.GetPatientByType(patientType);

        public IEnumerable<Patient> GetPatientByDoctor(Doctor doctor)
            => _patientRepository.GetPatientByDoctor(doctor);

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

        public IEnumerable<Patient> GetAll()
            => _patientRepository.GetAllEager();

        public Patient GetByID(UserID id)
            => _patientRepository.GetByID(id);

        public Patient Create(Patient entity)
            => _patientRepository.Create(entity);

        public void Delete(Patient entity)
            => _patientRepository.Delete(entity);

        public void Validate(Patient user)
        {
            
        }

        public void Login(User user)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient entity)
            => _patientRepository.Update(entity);

        public IPatientRepository iPatientRepository;

    }
}