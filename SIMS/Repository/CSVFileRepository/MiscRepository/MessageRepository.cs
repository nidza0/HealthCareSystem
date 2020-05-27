// File:    MessageRepository.cs
// Author:  Geri
// Created: 24. maj 2020 15:56:19
// Purpose: Definition of Class MessageRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class MessageRepository : CSVRepository<Message, long>, IMessageRepository, IEagerCSVRepository<Message, long>
    {
        private void BindMessageWithPatient(Message message)
        {
            throw new NotImplementedException();
        }

        private void BindMessageWithDoctor(Message message)
        {
            throw new NotImplementedException();
        }

        private void BindMessageWithSecretary(Message message)
        {
            throw new NotImplementedException();
        }

        private void BindMessageWithManager(Message message)
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

        public DoctorRepository doctorRepository;
        public PatientRepository patientRepository;
        public SecretaryRepository secretaryRepository;
        public ManagerRepository managerRepository;

    }
}