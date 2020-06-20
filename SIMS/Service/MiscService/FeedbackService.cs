// File:    FeedbackService.cs
// Author:  nikola
// Created: 6. maj 2020 18:46:57
// Purpose: Definition of Class FeedbackService

using System;
using System.Collections.Generic;
using System.Linq;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.MiscRepository;

namespace SIMS.Service.MiscService
{
    public class FeedbackService : IService<Feedback, long>
    {
        public IFeedbackRepository iFeedbackRepository;
        private FeedbackRepository _feedbackRepository;

        public FeedbackService(FeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public Feedback Create(Feedback entity)
            => _feedbackRepository.Create(entity);

        public void Delete(Feedback entity)
            => _feedbackRepository.Delete(entity);

        public IEnumerable<Feedback> GetAll()
            => _feedbackRepository.GetAllEager();

        public Feedback GetByID(long id)
            => GetAll().SingleOrDefault(feedback => feedback.GetId() == id);

        public void Update(Feedback entity)
            => _feedbackRepository.Update(entity);

        void IService<Feedback, long>.Update(Feedback entity)
        {
            throw new NotImplementedException();
        }
    }
}