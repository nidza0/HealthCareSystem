// File:    DoctorRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:33
// Purpose: Definition of Class DoctorRepository

using Model.Doctor;
using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;
using Util;

namespace Repository.CSVRepository.UserRepository
{
   public class DoctorRepository : CSVRepository<Doctor, UserID>, Abstract.User.IDoctorRepository, IEagerCSVRepository<Doctor, Model.User.UserID>
   {
      public void Bind(IEnumerable<Doctor> doctors)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<Doctor> GetDoctorByType(DocTypeEnum doctorType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetFilteredDoctors(DoctorFilter filter)
        {
            throw new NotImplementedException();
        }

        public Doctor GetEager(UserID id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Specifications.Converter.DoctorSpecificationConverter doctorSpecificationConverter;
   
   }
}