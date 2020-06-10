// File:    NotificationRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:31:13
// Purpose: Definition of Class NotificationRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class NotificationRepository : CSVRepository<Notification, long>, INotificationRepository, IEagerCSVRepository<Notification, long>
    {
        private const string ENTITY_NAME = "Notification";
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IManagerRepository _managerRepository;
        private readonly ISecretaryRepository _secretaryRepository;
        public NotificationRepository(ICSVStream<Notification> stream, ISequencer<long> sequencer, IPatientRepository patientRepository, IDoctorRepository doctorRepository, IManagerRepository managerRepository, ISecretaryRepository secretaryRepository) : base(ENTITY_NAME, stream, sequencer, new LongIdGeneratorStrategy<Notification>())
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _managerRepository = managerRepository;
            _secretaryRepository = secretaryRepository;
        }

        public new Notification Create(Notification notification)
        {
            notification.Date = DateTime.Now;
            return base.Create(notification);
        }

        public IEnumerable<Notification> GetAllEager()
        {
            var notifications = GetAll();
            BindNotificationsWithUser(notifications);
            return notifications;
        }

        private void BindNotificationsWithUser(IEnumerable<Notification> notifications)
        {
            var patients = _patientRepository.GetAll();
            var doctors = _doctorRepository.GetAll();
            var managers = _managerRepository.GetAll();
            var secretaries = _secretaryRepository.GetAll();

            foreach(Notification notification in notifications)
            {
                if(notification.Recipient != null)
                {
                    switch (notification.Recipient.GetUserType())
                    {
                        case UserType.PATIENT:
                            notification.Recipient = GetUserById(patients, notification.Recipient);
                                break;
                        case UserType.DOCTOR:
                            notification.Recipient = GetUserById(doctors, notification.Recipient);
                            break;
                        case UserType.MANAGER:
                            notification.Recipient = GetUserById(managers, notification.Recipient);
                            break;
                        case UserType.SECRETARY:
                            notification.Recipient = GetUserById(secretaries, notification.Recipient);
                            break;
                    }
                }
            }
        }

        public Notification GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(notification => notification.GetId() == id);

        public IEnumerable<Notification> GetNotificationByUser(User user)
            => GetAll().ToList().Where(notification => notification.Recipient == null ? false : notification.Recipient.GetId().Equals(user.GetId()));

        private User GetUserById(IEnumerable<User> users, User userId)
            => userId == null ? null : users.SingleOrDefault(user => user.GetId().Equals(userId.GetId()));
    }
}