// File:    MessageRepository.cs
// Author:  Geri
// Created: 24. maj 2020 15:56:19
// Purpose: Definition of Class MessageRepository

using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.MiscRepository
{
   public class MessageRepository : CSVRepository<Message, long>, Abstract.Misc.IMessageRepository, IEagerCSVRepository<Message, long>
   {
      private void BindMessageWithPatient(Model.User.Message message)
      {
         throw new NotImplementedException();
      }
      
      private void BindMessageWithDoctor(Model.User.Message message)
      {
         throw new NotImplementedException();
      }
      
      private void BindMessageWithSecretary(Model.User.Message message)
      {
         throw new NotImplementedException();
      }
      
      private void BindMessageWithManager(Model.User.Message message)
      {
         throw new NotImplementedException();
      }
      
      public void BindMessagesWithUsers(IEnumerable<Message> messages)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<Message> GetSent(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetRecieved(User user)
        {
            throw new NotImplementedException();
        }

        public Message GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Repository.CSVRepository.UserRepository.DoctorRepository doctorRepository;
      public Repository.CSVRepository.UserRepository.PatientRepository patientRepository;
      public Repository.CSVRepository.UserRepository.SecretaryRepository secretaryRepository;
      public Repository.CSVRepository.UserRepository.ManagerRepository managerRepository;
   
   }
}