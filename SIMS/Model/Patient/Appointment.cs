// File:    Appointment.cs
// Author:  Windows 10
// Created: 15. april 2020 21:19:22
// Purpose: Definition of Class Appointment

using System;

namespace Model.Patient
{
   public class Appointment
   {
      private long id;
      private bool canceled = false;
      
      public AppointmentType appointmentType;
      public Util.TimeInterval timeInterval;
      public Model.User.Patient patient;
      
      /// <summary>
      /// Property for Model.User.Patient
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Model.User.Patient Patient
      {
         get
         {
            return patient;
         }
         set
         {
            this.patient = value;
         }
      }
      public Model.User.Room room;
      
      /// <summary>
      /// Property for Model.User.Room
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Model.User.Room Room
      {
         get
         {
            return room;
         }
         set
         {
            this.room = value;
         }
      }
      public Model.User.Doctor doctorInAppointment;
   
   }
}