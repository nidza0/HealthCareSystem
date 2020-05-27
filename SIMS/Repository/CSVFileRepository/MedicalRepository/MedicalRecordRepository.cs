// File:    MedicalRecordRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:35
// Purpose: Definition of Class MedicalRecordRepository

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class MedicalRecordRepository : CSVRepository<MedicalRecord, long>, IMedicalRecordRepository, IEagerCSVRepository<MedicalRecord, long>
    {
        private void Bind(IEnumerable<MedicalRecord> medicalRecords)
        {
            throw new NotImplementedException();
        }

        private void BindMedicalRecordsWithDiagnosis(IEnumerable<MedicalRecord> medicalRecords, IEnumerable<Diagnosis> diagnosis)
        {
            throw new NotImplementedException();
        }

        private void BindMedicalRecordsWithAllergies(IEnumerable<MedicalRecord> medicalRecords, IEnumerable<Allergy> allergies)
        {
            throw new NotImplementedException();
        }

        private void BindMedicalRecordsWithPatients(IEnumerable<MedicalRecord> medicalRecords, IEnumerable<Patient> patients)
        {
            throw new NotImplementedException();
        }

        public Diagnosis AddDiagnosis(Patient patient, Diagnosis diagnosis)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetPatientMedicalRecord(Patient patient)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord AddAllergy(MedicalRecord medicalRecord, Allergy allergy)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MedicalRecord> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public DiagnosisRepository diagnosisRepository;
        public AllergyRepository allergyRepository;
        public PatientRepository patientRepository;

    }
}