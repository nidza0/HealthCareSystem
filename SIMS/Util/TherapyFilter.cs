// File:    TherapyFilter.cs
// Author:  nikola
// Created: 21. maj 2020 15:56:47
// Purpose: Definition of Class TherapyFilter

using System;
using System.Collections.Generic;
using Model.Patient;

namespace Util
{
   public class TherapyFilter
   {
      private String drugName;
      private Model.User.Doctor doctor;
      private TimeInterval timeInterval;
      private IEnumerable<TherapyTime> time;
   
   }
}