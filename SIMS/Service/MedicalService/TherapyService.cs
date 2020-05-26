// File:    TherapyService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class TherapyService

using System;
using System.Collections.Generic;
using Model.Patient;

namespace Service.MedicalService
{
   public class TherapyService : IService<Model.Patient.Therapy,long>
   {
      public Prescription AddPerscription(Model.Patient.Therapy therapy, Prescription perscription)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Therapy> GetTherapyByDate(Util.TimeInterval dateRange)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Therapy> GetTherapyByMedicine(Model.Patient.Medicine medicine)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Therapy> GetTherapyByPatient(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Therapy> GetFilteredTherapy(Util.TherapyFilter filter)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Therapy> GetTherapyByDiagnosis(Model.Patient.Diagnosis diagnosis)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Therapy> GetActiveTherapyForPatient(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Therapy> GetPastTherapyForPatient(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public void ConsumeTherapy(Model.Patient.Therapy therapy)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Therapy> GetActiveTherapyForDiagnosis(Model.Patient.Diagnosis diagnosis)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Therapy> GetPastTherapiesForDiagnosis(Model.Patient.Diagnosis diagnosis)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<Therapy> GetAll()
        {
            throw new NotImplementedException();
        }

        public Therapy GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Therapy Create(Therapy entity)
        {
            throw new NotImplementedException();
        }

        public Therapy Update(Therapy entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Therapy entity)
        {
            throw new NotImplementedException();
        }

        public Repository.Abstract.Medical.ITherapyRepository iTherapyRepository;
   
   }
}