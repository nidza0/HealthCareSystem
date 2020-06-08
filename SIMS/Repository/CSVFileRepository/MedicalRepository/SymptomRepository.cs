// File:    SymptomRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:35
// Purpose: Definition of Class SymptomRepository

using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class SymptomRepository : CSVRepository<Symptom, long>, ISymptomRepository
    {
        public SymptomRepository(string entityName, ICSVStream<Symptom> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Symptom>())
        {

        }
    }
}