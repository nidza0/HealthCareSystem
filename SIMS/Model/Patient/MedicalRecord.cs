// File:    MedicalRecord.cs
// Author:  Windows 10
// Created: 15. april 2020 21:34:36
// Purpose: Definition of Class MedicalRecord

using System;

namespace Model.Patient
{
   public class MedicalRecord
   {
      private long id;
      
      public bool AddPrescription(Prescription perscription)
      {
         throw new NotImplementedException();
      }
      
      public bool RemovePrescription(Prescription perscription)
      {
         throw new NotImplementedException();
      }
      
      public void AddDiagnosis()
      {
         throw new NotImplementedException();
      }
      
      public bool RemoveDiagnosis()
      {
         throw new NotImplementedException();
      }
      
      public void AddAllergy()
      {
         throw new NotImplementedException();
      }
      
      public void RemoveAllergy()
      {
         throw new NotImplementedException();
      }
      
      public System.Collections.ArrayList patientDiagnosis;
      
      /// <summary>
      /// Property for collection of Diagnosis
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList PatientDiagnosis
      {
         get
         {
            if (patientDiagnosis == null)
               patientDiagnosis = new System.Collections.ArrayList();
            return patientDiagnosis;
         }
         set
         {
            RemoveAllPatientDiagnosis();
            if (value != null)
            {
               foreach (Diagnosis oDiagnosis in value)
                  AddPatientDiagnosis(oDiagnosis);
            }
         }
      }
      
      /// <summary>
      /// Add a new Diagnosis in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddPatientDiagnosis(Diagnosis newDiagnosis)
      {
         if (newDiagnosis == null)
            return;
         if (this.patientDiagnosis == null)
            this.patientDiagnosis = new System.Collections.ArrayList();
         if (!this.patientDiagnosis.Contains(newDiagnosis))
            this.patientDiagnosis.Add(newDiagnosis);
      }
      
      /// <summary>
      /// Remove an existing Diagnosis from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemovePatientDiagnosis(Diagnosis oldDiagnosis)
      {
         if (oldDiagnosis == null)
            return;
         if (this.patientDiagnosis != null)
            if (this.patientDiagnosis.Contains(oldDiagnosis))
               this.patientDiagnosis.Remove(oldDiagnosis);
      }
      
      /// <summary>
      /// Remove all instances of Diagnosis from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllPatientDiagnosis()
      {
         if (patientDiagnosis != null)
            patientDiagnosis.Clear();
      }
      public System.Collections.ArrayList allergy;
      
      /// <summary>
      /// Property for collection of Allergy
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList Allergy
      {
         get
         {
            if (allergy == null)
               allergy = new System.Collections.ArrayList();
            return allergy;
         }
         set
         {
            RemoveAllAllergy();
            if (value != null)
            {
               foreach (Allergy oAllergy in value)
                  AddAllergy(oAllergy);
            }
         }
      }
      
      /// <summary>
      /// Add a new Allergy in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAllergy(Allergy newAllergy)
      {
         if (newAllergy == null)
            return;
         if (this.allergy == null)
            this.allergy = new System.Collections.ArrayList();
         if (!this.allergy.Contains(newAllergy))
            this.allergy.Add(newAllergy);
      }
      
      /// <summary>
      /// Remove an existing Allergy from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAllergy(Allergy oldAllergy)
      {
         if (oldAllergy == null)
            return;
         if (this.allergy != null)
            if (this.allergy.Contains(oldAllergy))
               this.allergy.Remove(oldAllergy);
      }
      
      /// <summary>
      /// Remove all instances of Allergy from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAllergy()
      {
         if (allergy != null)
            allergy.Clear();
      }
      public BloodType patientBloodType;
      
      /// <summary>
      /// Property for BloodType
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public BloodType PatientBloodType
      {
         get
         {
            return patientBloodType;
         }
         set
         {
            this.patientBloodType = value;
         }
      }
      public Model.User.Patient patient;
   
   }
}