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

        public IEnumerable<Allergy> GetPatientAllergies(Patient patient)
        {
            List<Allergy> patientAllergies = new List<Allergy>();
            MedicalRecord patientMedicalRecord = GetPatientMedicalRecord(patient);

            if (patientMedicalRecord == null) return patientAllergies;

            patientAllergies.AddRange(patientMedicalRecord.Allergy);

            return patientAllergies;
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

        public MedicalRecord Create(MedicalRecord entity){
            // TODO: Validate (if patient is null)

            Patient patient = entity.Patient;
            MedicalRecord patientMedicalRecord = GetPatientMedicalRecord(patient);

            if (patientMedicalRecord != null)
            {
                //Patient already has a medical record, therefore we don't want to create a new one.
                throw new MedicalRecordServiceException(String.Format("Patient {0} {1} already has a medical record with ID: {2}",patient.Name,patient.Surname, patientMedicalRecord.GetId()));
            }

            return _medicalRecordRepository.Create(entity);
        }


        public void Delete(MedicalRecord entity)
            => _medicalRecordRepository.Delete(entity);

        public void Update(MedicalRecord entity)
        {
            // TODO; Validate
            _medicalRecordRepository.Update(entity);
        }

        public void Validate(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}