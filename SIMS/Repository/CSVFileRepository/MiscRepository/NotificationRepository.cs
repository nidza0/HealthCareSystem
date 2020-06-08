// File:    NotificationRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:31:13
// Purpose: Definition of Class NotificationRepository

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

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class NotificationRepository : CSVRepository<Notification, long>, INotificationRepository, IEagerCSVRepository<Notification, long>
    {
        IUserRepository _userRepository;
        public NotificationRepository(string entityName, IUserRepository userRepository, ICSVStream<Notification> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Notification>())
        {
            _userRepository = userRepository;
        }

        public IEnumerable<Notification> GetAllEager()
        {
            IEnumerable<Notification> notifications = GetAll();
            IEnumerable<User> users = _userRepository.GetAll();
            return notifications;
        }

        public Notification GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(notification => notification.GetId() == id);

        public IEnumerable<Notification> GetNotificationByUser(User user)
            => GetAll().ToList().Where(notification => notification.Recipient.GetId().Equals(user.GetId()));

        private void BindNotificationWithUser(IEnumerable<User> recipients)
            => GetAll().ToList().ForEach(notification => notification.Recipient = getUserById(recipients, notification.Recipient.GetId()));

        private User getUserById(IEnumerable<User> users, UserID id)
            => users.ToList().SingleOrDefault(user => user.GetId().Equals(id));
    }
}