// File:    AppointmentSpecificationConverter.cs
// Author:  Geri
// Created: 23. maj 2020 18:41:37
// Purpose: Definition of Class AppointmentSpecificationConverter

using System;

namespace Specifications.Converter
{
   public class AppointmentSpecificationConverter
   {
      private Specifications.ISpecification<Model.Patient.Appointment> GetSpecificationByDoctorType(Model.Doctor.DocTypeEnum type)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.Patient.Appointment> GetSpecificationByDoctor(Model.User.Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.Patient.Appointment> GetSpecificationByTimeInterval(Util.TimeInterval timeInterval)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.Patient.Appointment> GetSpecificationByType(Model.Patient.AppointmentType type)
      {
         throw new NotImplementedException();
      }
      
      private Specifications.ISpecification<Model.Patient.Appointment> GetSpecificationForUpcoming()
      {
         throw new NotImplementedException();
      }
      
      public Specifications.ISpecification<Model.Patient.Appointment> GetSpecification(Util.AppointmentFilter filter)
      {
         throw new NotImplementedException();
      }
   
   }
}