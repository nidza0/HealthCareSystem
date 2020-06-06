// File:    PatientRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:33
// Purpose: Definition of Class PatientRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.UsersRepository
{
    public class PatientRepository : CSVRepository<Patient, UserID>, IPatientRepository, IEagerCSVRepository<Patient, UserID>
    {
        public PatientRepository(string entityName, ICSVStream<Patient> stream, ISequencer<UserID> sequencer) : base(entityName, stream, sequencer, new PatientIdGeneratorStrategy())
        {
        }

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