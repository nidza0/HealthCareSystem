// File:    MessageController.cs
// Author:  nikola
// Created: 22. maj 2020 17:31:54
// Purpose: Definition of Class MessageController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.MiscService;

namespace SIMS.Controller.MiscController
{
    public class MessageController : IController<Message, long>
    {
        public IEnumerable<Message> GetSent(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetRecieved(User user)
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

        public void Update(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        public MessageService messageService;

    }
}