// File:    MedicineSpecificationConverter.cs
// Author:  Geri
// Created: 24. maj 2020 20:23:07
// Purpose: Definition of Class MedicineSpecificationConverter

using SIMS.Model.PatientModel;
using System;

namespace SIMS.Specifications.Converter
{
    public class MedicineSpecificationConverter
    {
        private Specifications.ISpecification<Medicine> GetSpecificationByName(string name)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Medicine> GetSpecificationByDisease(Disease disease)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Medicine> GetSpecificationByType(MedicineType type)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Medicine> GetSpecificationByIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        private Specifications.ISpecification<Medicine> GetSpecificationByStrength(double strength)
        {
            throw new NotImplementedException();
        }

        public Specifications.ISpecification<Medicine> GetSpecification(Util.MedicineFilter filter)
        {
            throw new NotImplementedException();
        }

    }
}