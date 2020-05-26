// File:    IPatientRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:06:33
// Purpose: Definition of Interface IPatientRepository

using System;
using System.Collections.Generic;
using Model.User;

namespace Repository.Abstract.User
{
   public interface IPatientRepository : IRepository<Model.User.Patient,Model.User.UserID>
   {
      IEnumerable<Patient> GetPatientByType(Model.User.PatientType patientType);
      
      IEnumerable<Patient> GetPatientByDoctor(Model.User.Doctor doctor);
   
   }
}