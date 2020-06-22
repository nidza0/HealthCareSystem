// File:    MessageService.cs
// Author:  Geri
// Created: 7. maj 2020 12:02:29
// Purpose: Definition of Class MessageService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.MiscRepository;

namespace SIMS.Service.MiscService
{
    public class MessageService : IService<Message, long>
    {
        MessageRepository _messageRepository;


        public MessageService(MessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }


        public IEnumerable<Message> GetSent(User user)
            => _messageRepository.GetSent(user);

        public IEnumerable<Message> GetRecieved(User user)
            => _messageRepository.GetReceived(user);

        public IEnumerable<Message> GetAll()
            => _messageRepository.GetAllEager();

        public Message GetByID(long id)
            => _messageRepository.GetByID(id);

        public Message Create(Message entity)
            => _messageRepository.Create(entity);

        public void Update(Message entity)
            => _messageRepository.Create(entity);

        public void Delete(Message entity)
            => _messageRepository.Delete(entity);


    }
}