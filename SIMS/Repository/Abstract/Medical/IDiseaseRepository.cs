// File:    IDiseaseRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:03:39
// Purpose: Definition of Interface IDiseaseRepository

using System;
using System.Collections.Generic;
using Model.Patient;

namespace Repository.Abstract.Medical
{
   public interface IDiseaseRepository : IRepository<Model.Patient.Disease,long>
   {
      IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<Symptom> symptoms);
      
      IEnumerable<Disease> GetDiseasesByType(Model.Patient.DiseaseType type);
   
   }
}