// File:    PatientController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:50
// Purpose: Definition of Class PatientController

using System;
using System.Collections.Generic;
using Model.User;
using Model.Patient;

namespace Controller.UserController
{
   public class PatientController : IController<Model.User.Patient,Model.User.UserID>
   {
      public IEnumerable<Patient> GetPatientByType(Model.User.PatientType patientType)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Patient> GetPatientByDoctor(Model.User.Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Diagnosis> GetActiveDiagnosisForPatient(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Diagnosis> GetInactiveDiagnosisForPatient(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Therapy> GetFilteredTherapy(Util.TherapyFilter therapyFilter)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Therapy> GetActiveTherapyForPatient(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Model.Patient.Diagnosis AddDiagnosis(Model.User.Patient patient, Model.Patient.Diagnosis diagnosis)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Allergy> GetPatientAllergies(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient GetByID(UserID id)
        {
            throw new NotImplementedException();
        }

        public Patient Create(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Patient Update(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Service.UserService.PatientService patientService;
      public Service.MedicalService.MedicalRecordService medicalRecordService;
      public Service.MedicalService.TherapyService therapyService;
      public Service.MedicalService.DiagnosisService diagnosisService;
   
   }
}