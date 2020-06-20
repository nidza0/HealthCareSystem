// File:    NotificationController.cs
// Author:  nikola
// Created: 22. maj 2020 17:30:10
// Purpose: Definition of Class NotificationController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.MiscService;

namespace SIMS.Controller.MiscController
{
    public class NotificationController : IController<Notification, long>
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

        public void Update(Notification entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Notification entity)
        {
            throw new NotImplementedException();
        }

        public NotificationService notificationService;

    }
}