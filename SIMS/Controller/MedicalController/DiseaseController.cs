// File:    DiseaseController.cs
// Author:  nikola
// Created: 22. maj 2020 16:57:18
// Purpose: Definition of Class DiseaseController

using System;
using System.Collections.Generic;
using Model.Patient;

namespace Controller.MedicalController
{
   public class DiseaseController : IController<Model.Patient.Disease,long>
   {
      public IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<Symptom> symptoms)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Disease> GetDiseasesByType(Model.Patient.DiseaseType type)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<Disease> GetAll()
        {
            throw new NotImplementedException();
        }

        public Disease GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Disease Create(Disease entity)
        {
            throw new NotImplementedException();
        }

        public Disease Update(Disease entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Disease entity)
        {
            throw new NotImplementedException();
        }

        public Service.MedicalService.DiseaseService diseaseService;
   
   }
}