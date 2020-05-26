// File:    MessageController.cs
// Author:  nikola
// Created: 22. maj 2020 17:31:54
// Purpose: Definition of Class MessageController

using System;
using System.Collections.Generic;
using Model.User;

namespace Controller.MiscController
{
   public class MessageController : IController<Model.User.Message,long>
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

        public Service.MiscService.MessageService messageService;
   
   }
}