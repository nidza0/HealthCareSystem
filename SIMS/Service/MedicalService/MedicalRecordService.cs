// File:    MedicalRecordService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class MedicalRecordService

using System;
using System.Collections.Generic;
using Model.Patient;

namespace Service.MedicalService
{
   public class MedicalRecordService : IService<MedicalRecord, long>
   {
      public Model.Patient.Diagnosis AddDiagnosis(Model.User.Patient patient, Model.Patient.Diagnosis diagnosis)
      {
         throw new NotImplementedException();
      }
      
      public Model.Patient.MedicalRecord GetPatientMedicalRecord(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Model.Patient.MedicalRecord AddAllergy(Model.Patient.MedicalRecord medicalRecord, Model.Patient.Allergy allergy)
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

        public Repository.Abstract.Medical.IMedicalRecordRepository iMedicalRecordRepository;
   
   }
}