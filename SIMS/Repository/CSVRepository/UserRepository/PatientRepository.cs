// File:    PatientRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:33
// Purpose: Definition of Class PatientRepository

using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.UserRepository
{
    public class PatientRepository : CSVRepository<Patient, UserID>, Abstract.User.IPatientRepository, IEagerCSVRepository<Patient, UserID>
    {
        public IEnumerable<Patient> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Patient GetEager(UserID id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatientByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatientByType(PatientType patientType)
        {
            throw new NotImplementedException();
        }
    }
}