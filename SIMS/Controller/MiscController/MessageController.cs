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

        public MessageService messageService;

        public IEnumerable<Message> GetSent(User user)
            => messageService.GetSent(user);

        public IEnumerable<Message> GetRecieved(User user)
            => messageService.GetRecieved(user);

        public IEnumerable<Message> GetAll()
            => messageService.GetAll();

        public Message GetByID(long id)
            => messageService.GetByID(id);

        public Message Create(Message entity)
            => messageService.Create(entity);

        public void Update(Message entity)
            => messageService.Update(entity);

        public void Delete(Message entity)
            => messageService.Delete(entity);

    }
}