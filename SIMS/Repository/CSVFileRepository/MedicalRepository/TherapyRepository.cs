// File:    TherapyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 11:52:17
// Purpose: Definition of Class TherapyRepository
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using SIMS.Util;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class TherapyRepository : CSVRepository<Therapy, long>, ITherapyRepository, IEagerCSVRepository<Therapy, long>
    {
        public TherapyRepository(string entityName, ICSVStream<Therapy> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Therapy>())
        {
        }

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