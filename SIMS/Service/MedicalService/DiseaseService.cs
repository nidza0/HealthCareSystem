// File:    DiseaseService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class DiseaseService

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;

namespace SIMS.Service.MedicalService
{
    public class DiseaseService : IService<Disease, long>
    {
        public IEnumerable<Disease> GetDiseasesBySymptoms(IEnumerable<Symptom> symptoms)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Disease> GetDiseasesByType(DiseaseType type)
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

        void IService<Disease, long>.Update(Disease entity)
        {
            throw new NotImplementedException();
        }

        public IDiseaseRepository iDiseaseRepository;

    }
}