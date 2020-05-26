/***********************************************************************
 * Module:  Medicine.cs
 * Author:  nikola
 * Purpose: Definition of the Class Medicine
 ***********************************************************************/

using System;

namespace Model.Patient
{
   public class Medicine : Item
   {
      private Double strength;
      private bool isValid;
      
      public void Validate()
      {
         throw new NotImplementedException();
      }
      
      public void Invalidate()
      {
         throw new NotImplementedException();
      }
      
      public void AddIngredient()
      {
         throw new NotImplementedException();
      }
      
      public void RemoveIngredient()
      {
         throw new NotImplementedException();
      }
      
      public MedicineType medicineType;
      
      /// <summary>
      /// Property for MedicineType
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public MedicineType MedicineType
      {
         get
         {
            return medicineType;
         }
         set
         {
            this.medicineType = value;
         }
      }
      public System.Collections.ArrayList ingredient;
      
      /// <summary>
      /// Property for collection of Ingredient
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList Ingredient
      {
         get
         {
            if (ingredient == null)
               ingredient = new System.Collections.ArrayList();
            return ingredient;
         }
         set
         {
            RemoveAllIngredient();
            if (value != null)
            {
               foreach (Ingredient oIngredient in value)
                  AddIngredient(oIngredient);
            }
         }
      }
      
      /// <summary>
      /// Add a new Ingredient in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddIngredient(Ingredient newIngredient)
      {
         if (newIngredient == null)
            return;
         if (this.ingredient == null)
            this.ingredient = new System.Collections.ArrayList();
         if (!this.ingredient.Contains(newIngredient))
            this.ingredient.Add(newIngredient);
      }
      
      /// <summary>
      /// Remove an existing Ingredient from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveIngredient(Ingredient oldIngredient)
      {
         if (oldIngredient == null)
            return;
         if (this.ingredient != null)
            if (this.ingredient.Contains(oldIngredient))
               this.ingredient.Remove(oldIngredient);
      }
      
      /// <summary>
      /// Remove all instances of Ingredient from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllIngredient()
      {
         if (ingredient != null)
            ingredient.Clear();
      }
      public System.Collections.ArrayList usedFor;
      
      /// <summary>
      /// Property for collection of Disease
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.ArrayList UsedFor
      {
         get
         {
            if (usedFor == null)
               usedFor = new System.Collections.ArrayList();
            return usedFor;
         }
         set
         {
            RemoveAllUsedFor();
            if (value != null)
            {
               foreach (Disease oDisease in value)
                  AddUsedFor(oDisease);
            }
         }
      }
      
      /// <summary>
      /// Add a new Disease in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddUsedFor(Disease newDisease)
      {
         if (newDisease == null)
            return;
         if (this.usedFor == null)
            this.usedFor = new System.Collections.ArrayList();
         if (!this.usedFor.Contains(newDisease))
         {
            this.usedFor.Add(newDisease);
            newDisease.AddAdministratedFor(this);      
         }
      }
      
      /// <summary>
      /// Remove an existing Disease from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveUsedFor(Disease oldDisease)
      {
         if (oldDisease == null)
            return;
         if (this.usedFor != null)
            if (this.usedFor.Contains(oldDisease))
            {
               this.usedFor.Remove(oldDisease);
               oldDisease.RemoveAdministratedFor(this);
            }
      }
      
      /// <summary>
      /// Remove all instances of Disease from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllUsedFor()
      {
         if (usedFor != null)
         {
            System.Collections.ArrayList tmpUsedFor = new System.Collections.ArrayList();
            foreach (Disease oldDisease in usedFor)
               tmpUsedFor.Add(oldDisease);
            usedFor.Clear();
            foreach (Disease oldDisease in tmpUsedFor)
               oldDisease.RemoveAdministratedFor(this);
            tmpUsedFor.Clear();
         }
      }
   
   }
}