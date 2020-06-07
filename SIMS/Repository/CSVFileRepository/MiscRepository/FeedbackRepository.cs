// File:    FeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 18:21:30
// Purpose: Definition of Class FeedbackRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class FeedbackRepository : CSVRepository<Feedback, long>, IFeedbackRepository, IEagerCSVRepository<Feedback, long>
    {

        private IUserRepository _userRepository;

        public FeedbackRepository(string entityName, IUserRepository userRepository, ICSVStream<Feedback> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Feedback>())
        {
            _userRepository = userRepository;
        }

        public IEnumerable<Feedback> GetAllEager()
        {
            IEnumerable<Feedback> feedback = GetAll();
            IEnumerable<User> users = _userRepository.GetAll();
            BindWithUser(feedback, users);

            return feedback;
        }

        public Feedback GetEager(long id)
            => GetAllEager().SingleOrDefault(feedback => feedback.GetId() == id);

        private void BindWithUser(IEnumerable<Feedback> feedback, IEnumerable<User> users)
            => feedback.ToList().ForEach(feedback => feedback.User = GetUserById(users, feedback.User.GetId()));

        private User GetUserById(IEnumerable<User> users, UserID id)
            => users.SingleOrDefault(user => user.GetId().Equals(id));
    }
}