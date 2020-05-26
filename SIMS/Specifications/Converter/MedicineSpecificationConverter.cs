// File:    MedicineSpecificationConverter.cs
// Author:  Geri
// Created: 24. maj 2020 20:23:07
// Purpose: Definition of Class MedicineSpecificationConverter

using System;

namespace Specifications.Converter
{
   public class MedicineSpecificationConverter
   {
      private Specifications.ISpecification<Model.Patient.Medicine> GetSpecificationByName(string name)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.Patient.Medicine> GetSpecificationByDisease(Model.Patient.Disease disease)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.Patient.Medicine> GetSpecificationByType(Model.Patient.MedicineType type)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.Patient.Medicine> GetSpecificationByIngredient(Model.Patient.Ingredient ingredient)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.Patient.Medicine> GetSpecificationByStrength(double strength)
      {
         throw new NotImplementedException();
      }
      
      public Specifications.ISpecification<Model.Patient.Medicine> GetSpecification(Util.MedicineFilter filter)
      {
         throw new NotImplementedException();
      }
   
   }
}