// File:    StatisticsController.cs
// Author:  Geri
// Created: 20. maj 2020 11:07:40
// Purpose: Definition of Class StatisticsController

using System;
using System.Collections.Generic;
using Model.Manager;

namespace Controller.HospitalManagementController
{
   public class StatisticsController : IController<Model.Manager.Stats,long>
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

        public Service.HospitalManagementService.StatisticsService statisticsService;
   
   }
}