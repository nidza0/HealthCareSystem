// File:    IAppointmentStrategy.cs
// Author:  vule
// Created: 26. maj 2020 16:37:17
// Purpose: Definition of Interface IAppointmentStrategy

using System;

namespace Service.MedicalService
{
   public interface IAppointmentStrategy
   {
      bool CheckType(Model.Patient.Appointment appointment);
      
      void checkDateTimeValid(Model.Patient.Appointment appointment);
      
      int Validate(Model.Patient.Appointment appointment);
   
   }
}