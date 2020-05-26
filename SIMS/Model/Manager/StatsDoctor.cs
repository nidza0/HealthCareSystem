// File:    StatsDoctor.cs
// Author:  vule
// Created: 18. april 2020 17:12:34
// Purpose: Definition of Class StatsDoctor

using System;

namespace Model.Manager
{
   public class StatsDoctor : Stats
   {
      private Double numberOfAppointments;
      private String avgAppointmentTime;
      
      public Model.User.Doctor doctor;
   
   }
}