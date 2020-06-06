// File:    FeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 18:21:30
// Purpose: Definition of Class FeedbackRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class FeedbackRepository : CSVRepository<Feedback, long>, IFeedbackRepository, IEagerCSVRepository<Feedback, long>
    {
        public FeedbackRepository(string entityName, ICSVStream<Feedback> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Feedback>())
        {
        }

        public IEnumerable<Feedback> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Feedback GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}