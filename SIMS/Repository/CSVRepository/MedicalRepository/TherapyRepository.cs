// File:    TherapyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 11:52:17
// Purpose: Definition of Class TherapyRepository

using Model.Patient;
using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;
using Util;

namespace Repository.CSVRepository.MedicalRepository
{
   public class TherapyRepository : CSVRepository<Therapy, long>, Abstract.Medical.ITherapyRepository, IEagerCSVRepository<Therapy, long>
   {
      private void BindTherapyWithMedicine(IEnumerable<Therapy> therapies, IEnumerable<Medicine> medicine)
      {
         throw new NotImplementedException();
      }

        public Prescription AddPrescription(Therapy therapy, Prescription perscription)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetTherapyByDate(TimeInterval dateRange)
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

        public IEnumerable<Therapy> GetFilteredTherapy(TherapyFilter filter)
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

        public IEnumerable<Therapy> GetActiveTherapyForDiagnosis(Diagnosis diagnosis)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetPastTherapiesForDiagnosis(Diagnosis diagnosis)
        {
            throw new NotImplementedException();
        }

        public Therapy GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Specifications.Converter.TherapySpecificationConverter therapySpecificationConverter;
   
   }
}