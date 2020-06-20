// File:    TherapyService.cs
// Author:  Geri
// Created: 19. maj 2020 20:14:32
// Purpose: Definition of Class TherapyService

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.CSVFileRepository.MedicalRepository;
using SIMS.Util;

namespace SIMS.Service.MedicalService
{
    public class TherapyService : IService<Therapy, long>
    {
        private TherapyRepository _therapyRepository;

        public TherapyService(TherapyRepository therapyRepository)
        {
            _therapyRepository = therapyRepository;
        }
        

        public Prescription SetPerscription(Therapy therapy, Prescription prescription)
        {
            therapy.Prescription = prescription;
            _therapyRepository.Update(therapy);
            return prescription;
        }

        public IEnumerable<Therapy> GetTherapyByDate(TimeInterval dateRange)
            => _therapyRepository.GetTherapyByDate(dateRange);

        public IEnumerable<Therapy> GetTherapyByMedicine(Medicine medicine)
            => _therapyRepository.GetTherapyByMedicine(medicine);

        public IEnumerable<Therapy> GetTherapyByPatient(Patient patient)
            => _therapyRepository.GetTherapyByPatient(patient);

        public IEnumerable<Therapy> GetFilteredTherapy(TherapyFilter filter)
            => _therapyRepository.GetFilteredTherapy(filter);

        public IEnumerable<Therapy> GetTherapyByDiagnosis(Diagnosis diagnosis)
            => _therapyRepository.GetTherapyByDiagnosis(diagnosis);

        public IEnumerable<Therapy> GetActiveTherapyForPatient(Patient patient)
            => _therapyRepository.GetActiveTherapyForPatient(patient);

        public IEnumerable<Therapy> GetPastTherapyForPatient(Patient patient)
            => _therapyRepository.GetPastTherapyForPatient(patient);


        public void ConsumeTherapy(Therapy therapy)
        {
            //TODO: Do we even need this?
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetActiveTherapyForDiagnosis(Diagnosis diagnosis)
            => _therapyRepository.GetActiveTherapyForDiagnosis(diagnosis);

        public IEnumerable<Therapy> GetPastTherapiesForDiagnosis(Diagnosis diagnosis)
            => _therapyRepository.GetPastTherapiesForDiagnosis(diagnosis);

        public IEnumerable<Therapy> GetAll()
            => _therapyRepository.GetAllEager();

        public Therapy GetByID(long id)
            => _therapyRepository.GetEager(id);

        public Therapy Create(Therapy entity)
            => _therapyRepository.Create(entity);

        public void Delete(Therapy entity)
            => _therapyRepository.Delete(entity);

        public void Update(Therapy entity)
            => _therapyRepository.Update(entity);
    }
}