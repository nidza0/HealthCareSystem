// File:    IMessageRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:07:22
// Purpose: Definition of Interface IMessageRepository

using System;
using System.Collections.Generic;
using Model.User;

namespace Repository.Abstract.Misc
{
   public interface IMessageRepository : IRepository<Model.User.Message,long>
   {
      IEnumerable<Message> GetSent(Model.User.User user);
      
      IEnumerable<Message> GetRecieved(Model.User.User user);
   
   }
}