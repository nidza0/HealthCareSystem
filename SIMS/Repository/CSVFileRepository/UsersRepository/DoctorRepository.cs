// File:    DoctorRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:27:33
// Purpose: Definition of Class DoctorRepository

using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Util;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.UsersRepository
{
    public class DoctorRepository : CSVRepository<Doctor, UserID>, IDoctorRepository, IEagerCSVRepository<Doctor, UserID>
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