// File:    DiagnosisService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class DiagnosisService

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;

namespace SIMS.Service.MedicalService
{
    public class DiagnosisService : IService<Diagnosis, long>
    {
        public IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Diagnosis GetDiagnosisByMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diagnosis> GetActiveDiagnosisForPatient()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diagnosis> GetInactiveDiagnosisForPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diagnosis> GetAll()
        {
            throw new NotImplementedException();
        }

        public Diagnosis GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Diagnosis Create(Diagnosis entity)
        {
            throw new NotImplementedException();
        }

        public Diagnosis Update(Diagnosis entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Diagnosis entity)
        {
            throw new NotImplementedException();
        }

        public IDiagnosisRepository iDiagnosisRepository;

    }
}