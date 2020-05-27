// File:    DiagnosisRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:34
// Purpose: Definition of Class DiagnosisRepository

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class DiagnosisRepository : CSVRepository<Diagnosis, long>, IDiagnosisRepository, IEagerCSVRepository<Diagnosis, long>
    {
        private void Bind(IEnumerable<Diagnosis> diagnosis)
        {
            throw new NotImplementedException();
        }

        private void BindDiagnosisWithTherapies(IEnumerable<Diagnosis> diagnosis, IEnumerable<Therapy> therapies)
        {
            throw new NotImplementedException();
        }

        private void BindDiagnosisWithDisease(IEnumerable<Diagnosis> diagnosis, IEnumerable<Disease> diseases)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diagnosis> GetDiagnosisByMedicine(Medicine medicine)
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

        public Diagnosis GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diagnosis> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public TherapyRepository therapyRepository;
        public DiseaseRepository diseaseRepository;

    }
}