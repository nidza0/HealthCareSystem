// File:    MessageRepository.cs
// Author:  Geri
// Created: 24. maj 2020 15:56:19
// Purpose: Definition of Class MessageRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class MessageRepository : CSVRepository<Message, long>, IMessageRepository, IEagerCSVRepository<Message, long>
    {
        private IPatientRepository _patientRepository;
        private IDoctorRepository _doctorRepository;
        private IManagerRepository _managerRepository;
        private ISecretaryRepository _secretaryRepository;

        public MessageRepository(string entityName, IPatientRepository patientRepository, IDoctorRepository doctorRepository, IManagerRepository managerRepository, ISecretaryRepository secretaryRepository, ICSVStream<Message> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Message>())
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _managerRepository = managerRepository;
            _secretaryRepository = secretaryRepository;
        }

        public new Message Create(Message message)
        {
            message.Date = DateTime.Now;
            return base.Create(message);
        }

        //Bindong with senders
        private void BindMessageWithPatient(IEnumerable<Patient> patients, IEnumerable<Message> messages)
            => messages.ToList().ForEach(message => message.Sender = getPatientById(patients, message.Sender.GetId()));

        private Patient getPatientById(IEnumerable<Patient> patients, UserID id)
            => patients.ToList().SingleOrDefault(patient => patient.GetId().Equals(id));

        private void BindMessageWithDoctor(IEnumerable<Doctor> doctors, IEnumerable<Message> messages)
            => messages.ToList().ForEach(message => message.Sender = GetDoctorById(doctors, message.Sender.GetId()));

        private Doctor GetDoctorById(IEnumerable<Doctor> doctors, UserID id)
            => doctors.ToList().SingleOrDefault(doctor => doctor.GetId().Equals(id));

        private void BindMessageWithSecretary(IEnumerable<Secretary> secretaries, IEnumerable<Message> messages)
            => messages.ToList().ForEach(message => message.Sender = GetSecretaryById(secretaries, message.Sender.GetId()));

        private Secretary GetSecretaryById(IEnumerable<Secretary> secretaries, UserID id)
            => secretaries.ToList().SingleOrDefault(secretary => secretary.GetId().Equals(id));

        private void BindMessageWithManager(IEnumerable<Manager> managers, IEnumerable<Message> messages)
            => messages.ToList().ForEach(message => message.Sender = GetManagerById(managers, message.Sender.GetId()));

        private Manager GetManagerById(IEnumerable<Manager> managers, UserID id)
            => managers.ToList().SingleOrDefault(manager => manager.GetId().Equals(id));


        //Bindong with recipients
        private void BindMessageWithPatientRecipients(IEnumerable<Patient> patients, IEnumerable<Message> messages)
            => messages.ToList().ForEach(message => message.Recipient = getPatientById(patients, message.Recipient.GetId()));


        private void BindMessageWithDoctorRecipients(IEnumerable<Doctor> doctors, IEnumerable<Message> messages)
            => messages.ToList().ForEach(message => message.Recipient = GetDoctorById(doctors, message.Recipient.GetId()));


        private void BindMessageWithSecretaryRecipients(IEnumerable<Secretary> secretaries, IEnumerable<Message> messages)
            => messages.ToList().ForEach(message => message.Recipient = GetSecretaryById(secretaries, message.Recipient.GetId()));


        private void BindMessageWithManagerRecipients(IEnumerable<Manager> managers, IEnumerable<Message> messages)
            => messages.ToList().ForEach(message => message.Recipient = GetManagerById(managers, message.Recipient.GetId()));




        public void BindMessagesWithUsers(IEnumerable<Message> messages)
        {
            IEnumerable<Patient> patients = _patientRepository.GetAll();
            IEnumerable<Doctor> doctors = _doctorRepository.GetAll();
            IEnumerable<Manager> managers = _managerRepository.GetAll();
            IEnumerable<Secretary> secretaries = _secretaryRepository.GetAll();

            //  Bind with senders
            IEnumerable<Message> doctorMessages = messages.Where(message => message.Sender.GetId().ToString().ToLower().StartsWith("d"));
            BindMessageWithDoctor(doctors, doctorMessages);

            IEnumerable<Message> patientMessages = messages.Where(message => message.Sender.GetId().ToString().ToLower().StartsWith("p"));
            BindMessageWithPatient(patients, patientMessages);

            IEnumerable<Message> managerMessages = messages.Where(message => message.Sender.GetId().ToString().ToLower().StartsWith("m"));
            BindMessageWithManager(managers, managerMessages);

            IEnumerable<Message> secretaryMessages = messages.Where(message => message.Sender.GetId().ToString().ToLower().StartsWith("s"));
            BindMessageWithSecretary(secretaries, secretaryMessages);

            //  Bind with recipients
            IEnumerable<Message> doctorRecipientMessages = messages.Where(message => message.Recipient.GetId().ToString().ToLower().StartsWith("d"));
            BindMessageWithDoctorRecipients(doctors, doctorMessages);

            IEnumerable<Message> patientRecipientMessages = messages.Where(message => message.Recipient.GetId().ToString().ToLower().StartsWith("p"));
            BindMessageWithPatientRecipients(patients, patientMessages);

            IEnumerable<Message> managerRecipientMessages = messages.Where(message => message.Recipient.GetId().ToString().ToLower().StartsWith("m"));
            BindMessageWithManagerRecipients(managers, managerMessages);

            IEnumerable<Message> secretaryRecipientMessages = messages.Where(message => message.Recipient.GetId().ToString().ToLower().StartsWith("s"));
            BindMessageWithSecretaryRecipients(secretaries, secretaryMessages);



        }

        public IEnumerable<Message> GetSent(User user)
            => GetAll().ToList().Where(message => message.Sender.GetId().Equals(user.GetId()));

        public IEnumerable<Message> GetRecieved(User user)
            => GetAll().ToList().Where(message => message.Recipient.GetId().Equals(user.GetId()));

        public Message GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(message => message.GetId() == id);

        public IEnumerable<Message> GetAllEager()
        {
            IEnumerable<Message> messages = GetAll();
            BindMessagesWithUsers(messages);
            return messages;
        }

        public DoctorRepository doctorRepository;
        public PatientRepository patientRepository;
        public SecretaryRepository secretaryRepository;
        public ManagerRepository managerRepository;

    }
}