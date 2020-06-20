// File:    DiseaseController.cs
// Author:  nikola
// Created: 22. maj 2020 16:57:18
// Purpose: Definition of Class DiseaseController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.PatientModel;
using SIMS.Service.MedicalService;

namespace SIMS.Controller.MedicalController
{
    public class DiseaseController : IController<Disease, long>
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

        public void Update(Disease entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Disease entity)
        {
            throw new NotImplementedException();
        }

        public DiseaseService diseaseService;

    }
}