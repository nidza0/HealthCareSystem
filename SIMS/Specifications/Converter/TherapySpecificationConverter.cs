// File:    TherapySpecificationConverter.cs
// Author:  nikola
// Created: 24. maj 2020 11:54:18
// Purpose: Definition of Class TherapySpecificationConverter

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using System;

namespace SIMS.Specifications.Converter
{
    public class TherapySpecificationConverter
    {
        private Specifications.ISpecification<Therapy> GetSpecificationByDrugName(string drugName)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Therapy> GetSpecificationByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Therapy> GetSpecificationByTimeInterval(Util.TimeInterval timeInterval)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Therapy> GetSpecificationByTime(TherapyTime time)
        {
            throw new NotImplementedException();
        }

        public Specifications.ISpecification<Therapy> GetSpecification(Util.TherapyFilter filter)
        {
            throw new NotImplementedException();
        }

    }
}