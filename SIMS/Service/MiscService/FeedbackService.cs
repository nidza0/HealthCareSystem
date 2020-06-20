// File:    FeedbackService.cs
// Author:  nikola
// Created: 6. maj 2020 18:46:57
// Purpose: Definition of Class FeedbackService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;

namespace SIMS.Service.MiscService
{
    public class FeedbackService : IService<Feedback, long>
    {
        public IFeedbackRepository iFeedbackRepository;

        public Feedback Create(Feedback entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Feedback entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public Feedback GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Feedback Update(Feedback entity)
        {
            throw new NotImplementedException();
        }

        void IService<Feedback, long>.Update(Feedback entity)
        {
            throw new NotImplementedException();
        }
    }
}