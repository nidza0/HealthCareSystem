// File:    IDoctorFeedbackRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:07:20
// Purpose: Definition of Interface IDoctorFeedbackRepository

using System;
using System.Collections.Generic;
using Model.Doctor;

namespace Repository.Abstract.Misc
{
   public interface IDoctorFeedbackRepository : IRepository<Model.Doctor.DoctorFeedback,long>
   {
      IEnumerable<DoctorFeedback> GetByDoctor(Model.User.Doctor doctor);
      
      Model.Doctor.DoctorFeedback GetByPatientDoctor(Model.User.Patient patient, Model.User.Doctor doctor);
   
   }
}