// File:    DoctorSpecificationConverter.cs
// Author:  Geri
// Created: 24. maj 2020 20:28:14
// Purpose: Definition of Class DoctorSpecificationConverter

using System;

namespace Specifications.Converter
{
   public class DoctorSpecificationConverter
   {
      private Specifications.ISpecification<Model.User.Doctor> GetSpecificationByName(string name)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.User.Doctor> GetSpecificationBySurname(string surname)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.User.Doctor> GetSpecificationByType(Model.Doctor.DocTypeEnum type)
      {
         throw new NotImplementedException();
      }
      
      public Specifications.ISpecification<Model.User.Doctor> GetSpecification(Util.DoctorFilter filter)
      {
         throw new NotImplementedException();
      }
   
   }
}