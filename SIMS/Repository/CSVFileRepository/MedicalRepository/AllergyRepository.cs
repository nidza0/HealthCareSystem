// File:    AllergyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 13:02:09
// Purpose: Definition of Class AllergyRepository

using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class AllergyRepository : CSVRepository<Allergy, long>, IAllergyRepository
    {
        public AllergyRepository(string entityName, ICSVStream<Allergy> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Allergy>())
        {
        }
    }
}