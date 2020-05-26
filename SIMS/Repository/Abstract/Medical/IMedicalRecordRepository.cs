// File:    IMedicalRecordRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:04:43
// Purpose: Definition of Interface IMedicalRecordRepository

using System;

namespace Repository.Abstract.Medical
{
   public interface IMedicalRecordRepository : IRepository<Model.Patient.MedicalRecord,long>
   {
      Model.Patient.Diagnosis AddDiagnosis(Model.User.Patient patient, Model.Patient.Diagnosis diagnosis);
      
      Model.Patient.MedicalRecord GetPatientMedicalRecord(Model.User.Patient patient);
      
      Model.Patient.MedicalRecord AddAllergy(Model.Patient.MedicalRecord medicalRecord, Model.Patient.Allergy allergy);
   
   }
}