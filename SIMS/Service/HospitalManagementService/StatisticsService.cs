// File:    StatisticsService.cs
// Author:  Geri
// Created: 19. maj 2020 20:24:32
// Purpose: Definition of Class StatisticsService

using System;
using System.Collections.Generic;
using Model.Manager;

namespace Service.HospitalManagementService
{
   public class StatisticsService : IService<Model.Manager.Stats,long>
   {
      public IEnumerable<StatsDoctor> GetDoctorStatistics()
      {
         throw new NotImplementedException();
      }
      
      public Model.User.Doctor GetStatisticsByDoctor(Model.User.Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public Model.Manager.StatsInventory GetStatisticsByItem(Model.Patient.Item item)
      {
         throw new NotImplementedException();
      }
      
      public Model.Manager.StatsRoom GetStatisticsByRoom(Model.User.Room room)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<StatsRoom> GetRoomStatistics()
      {
         throw new NotImplementedException();
      }
      
      public Model.Manager.StatsInventory GetInventoryStatistics()
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

        public Repository.Abstract.HospitalManagement.IStatisticsRepository iStatisticsRepository;
   
   }
}