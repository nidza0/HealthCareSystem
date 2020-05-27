// File:    NotificationRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:31:13
// Purpose: Definition of Class NotificationRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class NotificationRepository : CSVRepository<Notification, long>, INotificationRepository, IEagerCSVRepository<Notification, long>
    {
        public IEnumerable<Notification> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Notification GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notification> GetNotificationByUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}