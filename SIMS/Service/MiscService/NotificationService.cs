// File:    NotificationService.cs
// Author:  Geri
// Created: 7. maj 2020 12:02:54
// Purpose: Definition of Class NotificationService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;

namespace SIMS.Service.MiscService
{
    public class NotificationService : IService<Notification, long>
    {
        public IEnumerable<Notification> GetNotificationByUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Notification> GetAll()
        {
            throw new NotImplementedException();
        }

        public Notification GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Notification Create(Notification entity)
        {
            throw new NotImplementedException();
        }

        public Notification Update(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Notification entity)
        {
            throw new NotImplementedException();
        }

        void IService<Notification, long>.Update(Notification entity)
        {
            throw new NotImplementedException();
        }

        public INotificationRepository iNotificationRepository;

    }
}