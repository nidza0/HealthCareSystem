// File:    FeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 18:21:30
// Purpose: Definition of Class FeedbackRepository

using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.MiscRepository
{
    public class FeedbackRepository : CSVRepository<Feedback, long>, Abstract.Misc.IFeedbackRepository, IEagerCSVRepository<Feedback, long>
    {
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