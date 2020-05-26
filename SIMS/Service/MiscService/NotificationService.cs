// File:    NotificationService.cs
// Author:  Geri
// Created: 7. maj 2020 12:02:54
// Purpose: Definition of Class NotificationService

using System;
using System.Collections.Generic;
using Model.User;

namespace Service.MiscService
{
   public class NotificationService : IService<Model.User.Notification,long>
   {
      public IEnumerable<Notification> GetNotificationByUser(Model.User.User user)
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

        public Repository.Abstract.Misc.INotificationRepository iNotificationRepository;
   
   }
}