// File:    MessageRepository.cs
// Author:  Geri
// Created: 24. maj 2020 15:56:19
// Purpose: Definition of Class MessageRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class MessageRepository : CSVRepository<Message, long>, IMessageRepository, IEagerCSVRepository<Message, long>
    {
        public MessageRepository(string entityName, ICSVStream<Message> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Message>())
        {
        }

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