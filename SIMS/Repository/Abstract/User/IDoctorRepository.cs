// File:    IDoctorRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:06:33
// Purpose: Definition of Interface IDoctorRepository

using System;
using System.Collections.Generic;
using Model.User;

namespace Repository.Abstract.User
{
   public interface IDoctorRepository : IRepository<Model.User.Doctor,Model.User.UserID>
   {
      IEnumerable<Doctor> GetDoctorByType(Model.Doctor.DocTypeEnum doctorType);
      
      IEnumerable<Doctor> GetFilteredDoctors(Util.DoctorFilter filter);
   
   }
}