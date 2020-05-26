// File:    INotificationRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:08:15
// Purpose: Definition of Interface INotificationRepository

using System;
using System.Collections.Generic;
using Model.User;

namespace Repository.Abstract.Misc
{
   public interface INotificationRepository : IRepository<Model.User.Notification,long>
   {
      IEnumerable<Notification> GetNotificationByUser(Model.User.User user);
   
   }
}