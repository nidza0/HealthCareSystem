// File:    SpecialistBookingLicence.cs
// Author:  Windows 10
// Created: 15. april 2020 21:47:38
// Purpose: Definition of Class SpecialistBookingLicence

using System;
using Model.User;

namespace Model.Patient
{
   public class SpecialistBookingLicence
   {
      private long id;
      private Model.Doctor.DocTypeEnum doctorAllowed;
      private int numberOfAppointments;
      private bool active;
      
      public Util.TimeInterval timeInterval;
      public System.Collections.Generic.List<Model.User.Doctor> handsOutLicence;
      
      /// <summary>
      /// Property for collection of Model.User.Doctor
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Model.User.Doctor> HandsOutLicence
      {
         get
         {
            if (handsOutLicence == null)
               handsOutLicence = new System.Collections.Generic.List<Model.User.Doctor>();
            return handsOutLicence;
         }
         set
         {
            RemoveAllHandsOutLicence();
            if (value != null)
            {
               foreach (Model.User.Doctor oDoctor in value)
                  AddHandsOutLicence(oDoctor);
            }
         }
      }
      
      /// <summary>
      /// Add a new Model.User.Doctor in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddHandsOutLicence(Model.User.Doctor newDoctor)
      {
         if (newDoctor == null)
            return;
         if (this.handsOutLicence == null)
            this.handsOutLicence = new System.Collections.Generic.List<Model.User.Doctor>();
         if (!this.handsOutLicence.Contains(newDoctor))
            this.handsOutLicence.Add(newDoctor);
      }
      
      /// <summary>
      /// Remove an existing Model.User.Doctor from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveHandsOutLicence(Model.User.Doctor oldDoctor)
      {
         if (oldDoctor == null)
            return;
         if (this.handsOutLicence != null)
            if (this.handsOutLicence.Contains(oldDoctor))
               this.handsOutLicence.Remove(oldDoctor);
      }
      
      /// <summary>
      /// Remove all instances of Model.User.Doctor from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllHandsOutLicence()
      {
         if (handsOutLicence != null)
            handsOutLicence.Clear();
      }
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
            if (this.patient == null || !this.patient.Equals(value))
            {
               if (this.patient != null)
               {
                  Model.User.Patient oldPatient = this.patient;
                  this.patient = null;
                  oldPatient.RemoveSpecialistBookingPermissions(this);
               }
               if (value != null)
               {
                  this.patient = value;
                  this.patient.AddSpecialistBookingPermissions(this);
               }
            }
         }
      }
   
   }
}