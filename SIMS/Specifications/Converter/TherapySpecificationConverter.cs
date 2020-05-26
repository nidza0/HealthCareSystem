// File:    TherapySpecificationConverter.cs
// Author:  nikola
// Created: 24. maj 2020 11:54:18
// Purpose: Definition of Class TherapySpecificationConverter

using System;

namespace Specifications.Converter
{
   public class TherapySpecificationConverter
   {
      private Specifications.ISpecification<Model.Patient.Therapy> GetSpecificationByDrugName(string drugName)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.Patient.Therapy> GetSpecificationByDoctor(Model.User.Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.Patient.Therapy> GetSpecificationByTimeInterval(Util.TimeInterval timeInterval)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.Patient.Therapy> GetSpecificationByTime(Model.Patient.TherapyTime time)
      {
         throw new NotImplementedException();
      }
      
      public Specifications.ISpecification<Model.Patient.Therapy> GetSpecification(Util.TherapyFilter filter)
      {
         throw new NotImplementedException();
      }
   
   }
}