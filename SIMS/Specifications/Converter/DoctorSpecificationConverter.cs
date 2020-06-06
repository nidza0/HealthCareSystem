// File:    DoctorSpecificationConverter.cs
// Author:  Geri
// Created: 24. maj 2020 20:28:14
// Purpose: Definition of Class DoctorSpecificationConverter

using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Util;
using System;

namespace SIMS.Specifications.Converter
{
    public class DoctorSpecificationConverter
    {
        private DoctorFilter _filter;

        public DoctorSpecificationConverter(DoctorFilter filter)
        {
            _filter = filter;
        }

        private ISpecification<Doctor> GetSpecificationByName(string name)
        {
            return new ExpressionSpecification<Doctor>(o => o.Name.Equals(name));
        }

        private ISpecification<Doctor> GetSpecificationBySurname(string surname)
        {
            return new ExpressionSpecification<Doctor>(o => o.Surname.Equals(surname));
        }

        private ISpecification<Doctor> GetSpecificationByType(DocTypeEnum type)
        {
            return new ExpressionSpecification<Doctor>(o => o.DocTypeEnum.Equals(type));
        }

        public ISpecification<Doctor> GetSpecification(DoctorFilter filter)
        {
            bool andSpecification = true;
            ISpecification<Doctor> specification = new ExpressionSpecification<Doctor>(o => andSpecification);

            if (!String.IsNullOrEmpty(filter.Name))
            {
                specification = specification.And(GetSpecificationByName(filter.Name));
            }

            if (!String.IsNullOrEmpty(filter.Surname))
            {
                specification = specification.And(GetSpecificationBySurname(filter.Surname));
            }

            return specification;
        }

    }
}