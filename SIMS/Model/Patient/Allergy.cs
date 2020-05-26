/***********************************************************************
 * Module:  Allergy.cs
 * Author:  nikola
 * Purpose: Definition of the Class Allergy
 ***********************************************************************/

using System;

namespace Model.Patient
{
   public class Allergy
   {
      private string name;
      private long id;
      
      public Ingredient allergicToIngredient;
      public System.Collections.ArrayList symptoms;
      
      /// <summary>
      /// Property for collection of Symptom
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList Symptoms
      {
         get
         {
            if (symptoms == null)
               symptoms = new System.Collections.ArrayList();
            return symptoms;
         }
         set
         {
            RemoveAllSymptoms();
            if (value != null)
            {
               foreach (Symptom oSymptom in value)
                  AddSymptoms(oSymptom);
            }
         }
      }
      
      /// <summary>
      /// Add a new Symptom in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddSymptoms(Symptom newSymptom)
      {
         if (newSymptom == null)
            return;
         if (this.symptoms == null)
            this.symptoms = new System.Collections.ArrayList();
         if (!this.symptoms.Contains(newSymptom))
            this.symptoms.Add(newSymptom);
      }
      
      /// <summary>
      /// Remove an existing Symptom from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveSymptoms(Symptom oldSymptom)
      {
         if (oldSymptom == null)
            return;
         if (this.symptoms != null)
            if (this.symptoms.Contains(oldSymptom))
               this.symptoms.Remove(oldSymptom);
      }
      
      /// <summary>
      /// Remove all instances of Symptom from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllSymptoms()
      {
         if (symptoms != null)
            symptoms.Clear();
      }
   
   }
}