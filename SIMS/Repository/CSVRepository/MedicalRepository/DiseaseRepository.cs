// File:    DiseaseRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:34
// Purpose: Definition of Class DiseaseRepository

using Model.Patient;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.MedicalRepository
{
   public class DiseaseRepository : CSVRepository<Disease, long>, Abstract.Medical.IDiseaseRepository, IEagerCSVRepository<Disease, long>
   {
      private void Bind(IEnumerable<Disease> diseases)
      {
         throw new NotImplementedException();
      }
      
      private void BindDiseaseWithMedicine(IEnumerable<Disease> diseases, IEnumerable<Medicine> medicine)
      {
         throw new NotImplementedException();
      }
      
      private void BindDiseaseWithSymptom(IEnumerable<Disease> diseases, IEnumerable<Symptom> symptom)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<Symptom> symptoms)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Disease> GetDiseasesByType(DiseaseType type)
        {
            throw new NotImplementedException();
        }

        public Disease GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Disease> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Repository.CSVRepository.HospitalManagementRepository.MedicineRepository medicineRepository;
      public SymptomRepository symptomRepository;

        public DiseaseRepository()
        {
        }
    }
}