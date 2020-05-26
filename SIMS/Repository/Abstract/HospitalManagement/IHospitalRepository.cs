// File:    IHospitalRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 13:57:57
// Purpose: Definition of Interface IHospitalRepository

using System;
using System.Collections.Generic;
using Model.User;

namespace Repository.Abstract.HospitalManagement
{
   public interface IHospitalRepository : IRepository<Model.User.Hospital,long>
   {
      IEnumerable<Hospital> GetHospitalByLocation(Model.User.Location location);
   
   }
}