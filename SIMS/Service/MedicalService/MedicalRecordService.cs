// File:    MedicalRecordService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class MedicalRecordService

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.MedicalRepository;
using SIMS.Exceptions;

namespace SIMS.Service.MedicalService
{
    public class MedicalRecordService : IService<MedicalRecord, long>
    {
        private  MedicalRecordRepository _medicalRecordRepository;

        public MedicalRecordService(MedicalRecordRepository medicalRecordRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
        }

        public Diagnosis AddDiagnosis(Patient patient, Diagnosis diagnosis)
        {
            MedicalRecord medicalRecord = GetPatientMedicalRecord(patient);
            
            if(medicalRecord == null)
            {
                throw new EntityNotFoundException("Medical record not found!");
            }

            medicalRecord.AddPatientDiagnosis(diagnosis);
            _medicalRecordRepository.Update(medicalRecord);

            return diagnosis;
        }

        public MedicalRecord GetPatientMedicalRecord(Patient patient)
            => _medicalRecordRepository.GetPatientMedicalRecord(patient);

        public MedicalRecord AddAllergy(MedicalRecord medicalRecord, Allergy allergy)
        {
            medicalRecord.AddAllergy(allergy);
            _medicalRecordRepository.Update(medicalRecord);
            return medicalRecord;
        }

        public IEnumerable<MedicalRecord> GetAll()
            => _medicalRecordRepository.GetAllEager();

        public MedicalRecord GetByID(long id)
            => _medicalRecordRepository.GetEager(id);

        public MedicalRecord Create(MedicalRecord entity)
            => _medicalRecordRepository.Create(entity);


        public void Delete(MedicalRecord entity)
            => _medicalRecordRepository.Delete(entity);

        public void Update(MedicalRecord entity)
            => _medicalRecordRepository.Update(entity);

    }
}