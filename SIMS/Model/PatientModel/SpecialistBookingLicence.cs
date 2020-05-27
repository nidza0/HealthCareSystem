// File:    SpecialistBookingLicence.cs
// Author:  Windows 10
// Created: 15. april 2020 21:47:38
// Purpose: Definition of Class SpecialistBookingLicence

using SIMS.Model.DoctorModel;
using SIMS.Util;
using System;

namespace Model.Patient
{
    public class SpecialistBookingLicence
   {
      private long id;
      private DocTypeEnum doctorAllowed;
      private int numberOfAppointments;
      private bool active;
      
      public TimeInterval timeInterval;
      public System.Collections.Generic.List<SIMS.Model.UserModel.Doctor> handsOutLicence;
      
      /// <summary>
      /// Property for collection of Model.User.Doctor
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<SIMS.Model.UserModel.Doctor> HandsOutLicence
      {
         get
         {
            if (handsOutLicence == null)
               handsOutLicence = new System.Collections.Generic.List<SIMS.Model.UserModel.Doctor>();
            return handsOutLicence;
         }
         set
         {
            RemoveAllHandsOutLicence();
            if (value != null)
            {
               foreach (SIMS.Model.UserModel.Doctor oDoctor in value)
                  AddHandsOutLicence(oDoctor);
            }
         }
      }
      
      /// <summary>
      /// Add a new Model.User.Doctor in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddHandsOutLicence(SIMS.Model.UserModel.Doctor newDoctor)
      {
         if (newDoctor == null)
            return;
         if (this.handsOutLicence == null)
            this.handsOutLicence = new System.Collections.Generic.List<SIMS.Model.UserModel.Doctor>();
         if (!this.handsOutLicence.Contains(newDoctor))
            this.handsOutLicence.Add(newDoctor);
      }
      
      /// <summary>
      /// Remove an existing Model.User.Doctor from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveHandsOutLicence(SIMS.Model.UserModel.Doctor oldDoctor)
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
      public SIMS.Model.UserModel.Patient patient;
      
      /// <summary>
      /// Property for Model.User.Patient
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public SIMS.Model.UserModel.Patient Patient
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
                        SIMS.Model.UserModel.Patient oldPatient = this.patient;
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