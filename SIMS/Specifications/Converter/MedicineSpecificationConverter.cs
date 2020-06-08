// File:    MedicineSpecificationConverter.cs
// Author:  Geri
// Created: 24. maj 2020 20:23:07
// Purpose: Definition of Class MedicineSpecificationConverter

using SIMS.Model.PatientModel;
using SIMS.Util;
using System;

namespace SIMS.Specifications.Converter
{
    public class MedicineSpecificationConverter
    {
        private MedicineFilter _filter;

        public MedicineSpecificationConverter(MedicineFilter filter)
        {
            _filter = filter;
        }
        private ISpecification<Medicine> GetSpecificationByName(string name)
        {
            return new ExpressionSpecification<Medicine>(o => o.Name.Equals(name));
        }

        private ISpecification<Medicine> GetSpecificationByDisease(Disease disease)
        {
            return new ExpressionSpecification<Medicine>(o => o.UsedFor.Contains(disease));
        }

        private ISpecification<Medicine> GetSpecificationByType(MedicineType type)
        {
            return new ExpressionSpecification<Medicine>(o => o.MedicineType.Equals(type));
        }

        private ISpecification<Medicine> GetSpecificationByIngredient(Ingredient ingredient)
        {
            return new ExpressionSpecification<Medicine>(o => o.Ingredient.Equals(ingredient));
        }

        private ISpecification<Medicine> GetSpecificationByStrength(double strength)
        {
            return new ExpressionSpecification<Medicine>(o => o.Strength == strength);
        }

        public ISpecification<Medicine> GetSpecification(MedicineFilter filter)
        {
            bool andFilter = true;
            ISpecification<Medicine> specification = new ExpressionSpecification<Medicine>(o => andFilter);

            if(filter.Disease != null)
            {
                specification = specification.And(GetSpecificationByDisease(filter.Disease));
            }

            if(filter.Ingredient != null)
            {
                specification = specification.And(GetSpecificationByIngredient(filter.Ingredient));
            }

            if(!String.IsNullOrEmpty(filter.Name))
            {
                specification = specification.And(GetSpecificationByName(filter.Name));
            }

            if(filter.Strength != default)
            {
                specification = specification.And(GetSpecificationByStrength(filter.Strength));
            }

            specification = specification.And(GetSpecificationByType(filter.Type));

            return specification;
        }

    }
}