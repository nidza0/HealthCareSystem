// File:    DoctorSpecificationConverter.cs
// Author:  Geri
// Created: 24. maj 2020 20:28:14
// Purpose: Definition of Class DoctorSpecificationConverter

using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using System;

namespace SIMS.Specifications.Converter
{
    public class DoctorSpecificationConverter
    {
        private Specifications.ISpecification<Doctor> GetSpecificationByName(string name)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Doctor> GetSpecificationBySurname(string surname)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Doctor> GetSpecificationByType(DocTypeEnum type)
        {
            throw new NotImplementedException();
        }

        public Specifications.ISpecification<Doctor> GetSpecification(Util.DoctorFilter filter)
        {
            throw new NotImplementedException();
        }

    }
}