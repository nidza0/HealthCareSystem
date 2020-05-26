// File:    HospitalRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:41
// Purpose: Definition of Class HospitalRepository

using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;
using Model.User;

namespace Repository.CSVRepository.HospitalManagementRepository
{
   public class HospitalRepository : CSVRepository<Model.User.Hospital,long>, Repository.Abstract.HospitalManagement.IHospitalRepository, IEagerCSVRepository<Model.User.Hospital,long>
   {
      private void BindHospitalWithRooms(Model.User.Hospital hospital, IEnumerable<Room> rooms)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<Hospital> GetHospitalByLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public Hospital GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hospital> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public RoomRepository roomRepository;
   
   }
}