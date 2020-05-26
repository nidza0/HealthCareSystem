// File:    DiagnosisService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class DiagnosisService

using System;
using System.Collections.Generic;
using Model.Patient;

namespace Service.MedicalService
{
   public class DiagnosisService : IService<Model.Patient.Diagnosis,long>
   {
      public IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public Model.Patient.Diagnosis GetDiagnosisByMedicine(Model.Patient.Medicine medicine)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Diagnosis> GetActiveDiagnosisForPatient()
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Diagnosis> GetInactiveDiagnosisForPatient(Model.User.Patient patient)
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

        public Repository.Abstract.Medical.IDiagnosisRepository iDiagnosisRepository;
   
   }
}