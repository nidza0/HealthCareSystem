// File:    MessageService.cs
// Author:  Geri
// Created: 7. maj 2020 12:02:29
// Purpose: Definition of Class MessageService

using System;
using System.Collections.Generic;
using Model.User;

namespace Service.MiscService
{
   public class MessageService : IService<Model.User.Message,long>
   {
      public IEnumerable<Message> GetSent(Model.User.User user)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Message> GetRecieved(Model.User.User user)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<Message> GetAll()
        {
            throw new NotImplementedException();
        }

        public Message GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Message Create(Message entity)
        {
            throw new NotImplementedException();
        }

        public Message Update(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        public Repository.Abstract.Misc.IMessageRepository iMessageRepository;
   
   }
}