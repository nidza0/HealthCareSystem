// File:    ManagerRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:34
// Purpose: Definition of Class ManagerRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.UsersRepository
{
    public class ManagerRepository : CSVRepository<Manager, UserID>, IManagerRepository, IEagerCSVRepository<Manager, UserID>
    {
        private readonly ITimeTableRepository _timeTableRepository;
        private readonly IHospitalRepository _hospitalRepository;
        private readonly IUserRepository _userRepository;
        private const string ENTITY_NAME = "Manager";
        private const string NOT_UNIQUE_ERROR = "Manager username {0} is not unique!";

        public ManagerRepository(ICSVStream<Manager> stream, ISequencer<UserID> sequencer, ITimeTableRepository timeTableRepository, IHospitalRepository hospitalRepository, IUserRepository userRepository) : base(ENTITY_NAME, stream, sequencer, new ManagerIdGeneratorStrategy())
        {
            _timeTableRepository = timeTableRepository;
            _hospitalRepository = hospitalRepository;
            _userRepository = userRepository;
        }

        public new Manager Create(Manager manager)
        {
            if (IsUsernameUnique(manager.UserName))
            {
                manager.DateCreated = DateTime.Now;
                manager = base.Create(manager);
                _userRepository.AddUser(manager);
                return manager;
            }
            else
                throw new NotUniqueException(string.Format(NOT_UNIQUE_ERROR, manager.UserName));
        }

        private bool IsUsernameUnique(string userName)
            => _userRepository.GetByUsername(userName) == null;

        public IEnumerable<Manager> GetAllEager()
        {
            var managers = GetAll();
            Bind(managers);
            return managers;
        }

        public Manager GetEager(UserID id)
        {
            var manager = GetByID(id);
            
            var timetables = _timeTableRepository.GetAll();
            manager.TimeTable = timetables.SingleOrDefault(timetable => timetable.GetId() == manager.TimeTable.GetId());

            var hospitals = _hospitalRepository.GetAll();
            manager.Hospital = hospitals.SingleOrDefault(hospital => hospital.GetId() == manager.Hospital.GetId());
            
            return manager;
        }

        private void Bind(IEnumerable<Manager> managers)
        {
            var timetables = _timeTableRepository.GetAll();
            BindManagersWithTimetables(managers, timetables);

            var hospitals = _hospitalRepository.GetAll();
            BindManagerssWithHospitals(managers, hospitals);
        }

        private void BindManagersWithTimetables(IEnumerable<Manager> managers, IEnumerable<TimeTable> timetables)
            => managers.ToList().ForEach(manager => manager.TimeTable = timetables.SingleOrDefault(timetable => timetable.GetId() == manager.TimeTable.GetId()));

        private void BindManagerssWithHospitals(IEnumerable<Manager> managers, IEnumerable<Hospital> hospitals)
            => managers.ToList().ForEach(manager => manager.Hospital = hospitals.SingleOrDefault(hospital => hospital.GetId() == manager.Hospital.GetId()));
    }
}