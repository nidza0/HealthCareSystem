// File:    TherapyService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class TherapyService

using System;
using System.Collections.Generic;
using Model.Patient;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;

namespace SIMS.Service.MedicalService
{
    public class TherapyService : IService<Therapy, long>
    {
        public Prescription AddPerscription(Therapy therapy, Prescription perscription)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetTherapyByDate(Util.TimeInterval dateRange)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetTherapyByMedicine(Medicine medicine)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetTherapyByPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetFilteredTherapy(Util.TherapyFilter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetTherapyByDiagnosis(Diagnosis diagnosis)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetActiveTherapyForPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetPastTherapyForPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void ConsumeTherapy(Therapy therapy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetActiveTherapyForDiagnosis(Diagnosis diagnosis)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetPastTherapiesForDiagnosis(Diagnosis diagnosis)
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

        public ITherapyRepository iTherapyRepository;

    }
}