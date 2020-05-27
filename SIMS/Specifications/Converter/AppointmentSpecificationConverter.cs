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
        private Specifications.ISpecification<Appointment> GetSpecificationByDoctorType(DocTypeEnum type)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Appointment> GetSpecificationByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Appointment> GetSpecificationByTimeInterval(Util.TimeInterval timeInterval)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Appointment> GetSpecificationByType(AppointmentType type)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Appointment> GetSpecificationForUpcoming()
        {
            throw new NotImplementedException();
        }

        public Specifications.ISpecification<Appointment> GetSpecification(AppointmentFilter filter)
        {
            throw new NotImplementedException();
        }

    }
}