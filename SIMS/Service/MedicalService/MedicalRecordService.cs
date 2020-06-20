// File:    MedicalRecordService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class MedicalRecordService

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;

namespace SIMS.Service.MedicalService
{
    public class MedicalRecordService : IService<MedicalRecord, long>
    {
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

        public IEnumerable<MedicalRecord> GetAll()
        {
            throw new NotImplementedException();
        }

        public MedicalRecord GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord Create(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }

        public MedicalRecord Update(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }

        void IService<MedicalRecord, long>.Update(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }

        public IMedicalRecordRepository iMedicalRecordRepository;

    }
}