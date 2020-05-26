// File:    DoctorFeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:52:51
// Purpose: Definition of Class DoctorFeedbackRepository

using Model.Doctor;
using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.MiscRepository
{
   public class DoctorFeedbackRepository : CSVRepository<DoctorFeedback, long>, Abstract.Misc.IDoctorFeedbackRepository, IEagerCSVRepository<DoctorFeedback, long>
   {
      public void BindWithDoctor(IEnumerable<DoctorFeedback> doctorFeedbacks)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<DoctorFeedback> GetByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public DoctorFeedback GetByPatientDoctor(Patient patient, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public DoctorFeedback GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorFeedback> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Repository.CSVRepository.UserRepository.DoctorRepository doctorRepository;
   
   }
}