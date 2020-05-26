// File:    AppointmentFilter.cs
// Author:  nikola
// Created: 21. maj 2020 12:39:03
// Purpose: Definition of Class AppointmentFilter

using System;

namespace Util
{
   public class AppointmentFilter
   {
      private Model.Doctor.DocTypeEnum doctorType;
      private Model.User.Doctor doctor;
      private TimeInterval timeInterval;
      private Model.Patient.AppointmentType type;
      private bool showUpcomingOnly;
   
   }
}