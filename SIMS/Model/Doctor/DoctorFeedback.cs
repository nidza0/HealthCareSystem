// File:    DoctorFeedback.cs
// Author:  Geri
// Created: 18. april 2020 20:50:38
// Purpose: Definition of Class DoctorFeedback

using System;

namespace Model.Doctor
{
   public class DoctorFeedback : Model.User.Feedback
   {
      public Model.User.Doctor recepient;
   
   }
}