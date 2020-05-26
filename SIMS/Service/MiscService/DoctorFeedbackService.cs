// File:    DoctorFeedbackService.cs
// Author:  vule
// Created: 21. maj 2020 15:04:26
// Purpose: Definition of Class DoctorFeedbackService

using System;
using System.Collections.Generic;
using Model.Doctor;

namespace Service.MiscService
{
   public class DoctorFeedbackService : IService<Model.Doctor.DoctorFeedback,long>
   {
      public IEnumerable<DoctorFeedback> GetByDoctor(Model.User.Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public double GetAverageRatingByDoctor(Model.User.Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public void Validate(Model.Doctor.DoctorFeedback doctorFeedback)
      {
         throw new NotImplementedException();
      }
      
      public Model.Doctor.DoctorFeedback GetByPatientDoctor(Model.User.Patient patient, Model.User.Doctor doctor)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<DoctorFeedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public DoctorFeedback GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public DoctorFeedback Create(DoctorFeedback entity)
        {
            throw new NotImplementedException();
        }

        public DoctorFeedback Update(DoctorFeedback entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DoctorFeedback entity)
        {
            throw new NotImplementedException();
        }

        public Repository.Abstract.Misc.IDoctorFeedbackRepository iDoctorFeedbackRepository;
   
   }
}