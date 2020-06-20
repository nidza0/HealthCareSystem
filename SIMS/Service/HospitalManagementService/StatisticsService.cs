// File:    StatisticsService.cs
// Author:  Geri
// Created: 19. maj 2020 20:24:32
// Purpose: Definition of Class StatisticsService

using System;
using System.Collections.Generic;
using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;

namespace SIMS.Service.HospitalManagementService
{
    public class StatisticsService : IService<Stats, long>
    {
        public IEnumerable<StatsDoctor> GetDoctorStatistics()
        {
            throw new NotImplementedException();
        }

        public Doctor GetStatisticsByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public StatsInventory GetStatisticsByItem(Item item)
        {
            throw new NotImplementedException();
        }

        public StatsRoom GetStatisticsByRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatsRoom> GetRoomStatistics()
        {
            throw new NotImplementedException();
        }

        public StatsInventory GetInventoryStatistics()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stats> GetAll()
        {
            throw new NotImplementedException();
        }

        public Stats GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Stats Create(Stats entity)
        {
            throw new NotImplementedException();
        }

        public Stats Update(Stats entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Stats entity)
        {
            throw new NotImplementedException();
        }

        void IService<Stats, long>.Update(Stats entity)
        {
            throw new NotImplementedException();
        }

        public IStatisticsRepository iStatisticsRepository;

    }
}