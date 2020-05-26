// File:    IStatisticsRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 13:58:07
// Purpose: Definition of Interface IStatisticsRepository

using System;
using System.Collections.Generic;
using Model.Manager;

namespace Repository.Abstract.HospitalManagement
{
   public interface IStatisticsRepository : IRepository<Model.Manager.Stats,long>
   {
      IEnumerable<StatsDoctor> GetDoctorStatistics();
      
      Model.User.Doctor GetStatisticsByDoctor(Model.User.Doctor doctor);
      
      Model.Manager.StatsInventory GetStatisticsByItem(Model.Patient.Item item);
      
      Model.Manager.StatsRoom GetStatisticsByRoom(Model.User.Room room);
      
      IEnumerable<StatsRoom> GetRoomStatistics();
      
      Model.Manager.StatsInventory GetInventoryStatistics();
   
   }
}