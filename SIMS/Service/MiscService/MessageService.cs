// File:    MessageService.cs
// Author:  Geri
// Created: 7. maj 2020 12:02:29
// Purpose: Definition of Class MessageService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;

namespace SIMS.Service.MiscService
{
    public class MessageService : IService<Message, long>
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

        public Message Update(Message entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Message entity)
        {
            throw new NotImplementedException();
        }

        void IService<Message, long>.Update(Message entity)
        {
            throw new NotImplementedException();
        }

        public IMessageRepository iMessageRepository;

    }
}