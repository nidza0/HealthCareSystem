// File:    FeedbackService.cs
// Author:  nikola
// Created: 6. maj 2020 18:46:57
// Purpose: Definition of Class FeedbackService

using System;
using System.Collections.Generic;
using Model.User;

namespace Service.MiscService
{
   public class FeedbackService : IService<Model.User.Feedback,long>
   {
      public Repository.Abstract.Misc.IFeedbackRepository iFeedbackRepository;

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
    }
}