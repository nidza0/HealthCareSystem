// File:    AppointmentSpecificationConverter.cs
// Author:  Geri
// Created: 23. maj 2020 18:41:37
// Purpose: Definition of Class AppointmentSpecificationConverter

using SIMS.Model.DoctorModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Util;
using System;

namespace SIMS.Specifications.Converter
{
    public class AppointmentSpecificationConverter
    {
        private AppointmentFilter _filter;

        public AppointmentSpecificationConverter(AppointmentFilter filter)
        {
            _filter = filter;
        }
        private ISpecification<Appointment> GetSpecificationByDoctorType(DocTypeEnum type)
        {
            return new ExpressionSpecification<Appointment>(o => o.DoctorInAppointment.DocTypeEnum == type);
        }

        private ISpecification<Appointment> GetSpecificationByDoctor(Doctor doctor)
        {
            return new ExpressionSpecification<Appointment>(o => o.DoctorInAppointment.Equals(doctor));
        }

        private ISpecification<Appointment> GetSpecificationByTimeInterval(Util.TimeInterval timeInterval)
        {
            return new ExpressionSpecification<Appointment>(o => o.TimeInterval.Equals(timeInterval));
        }

        private ISpecification<Appointment> GetSpecificationByType(AppointmentType type)
        {
            return new ExpressionSpecification<Appointment>(o => o.AppointmentType.Equals(type));
        }

        public ISpecification<Appointment> GetSpecification(AppointmentFilter filter)
        {
            ISpecification<Appointment> specification = new ExpressionSpecification<Appointment>(o => true);
            
            specification = specification.And(GetSpecificationByType(filter.Type));

            if(filter.TimeInterval != null)
            {
                specification = specification.And(GetSpecificationByTimeInterval(filter.TimeInterval));
            }

            if(filter.Doctor != null)
            {
                specification = specification.And(GetSpecificationByDoctor(filter.Doctor));
            }

            specification = specification.And(GetSpecificationByDoctorType(filter.DoctorType));

            return specification;
        }

    }
}