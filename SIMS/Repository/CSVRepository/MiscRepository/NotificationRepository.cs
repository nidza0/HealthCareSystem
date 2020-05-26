// File:    NotificationRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:31:13
// Purpose: Definition of Class NotificationRepository

using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.MiscRepository
{
    public class NotificationRepository : CSVRepository<Notification, long>, Abstract.Misc.INotificationRepository, IEagerCSVRepository<Notification, long>
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