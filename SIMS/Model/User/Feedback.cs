// File:    Feedback.cs
// Author:  Geri
// Created: 18. april 2020 20:34:11
// Purpose: Definition of Class Feedback

using System;

namespace Model.User
{
   public class Feedback
   {
      private String comment;
      private long id;
      
      public System.Collections.Generic.List<Rating> rating;
      
      /// <summary>
      /// Property for collection of Rating
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Rating> Rating
      {
         get
         {
            if (rating == null)
               rating = new System.Collections.Generic.List<Rating>();
            return rating;
         }
         set
         {
            RemoveAllRating();
            if (value != null)
            {
               foreach (Rating oRating in value)
                  AddRating(oRating);
            }
         }
      }
      
      /// <summary>
      /// Add a new Rating in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddRating(Rating newRating)
      {
         if (newRating == null)
            return;
         if (this.rating == null)
            this.rating = new System.Collections.Generic.List<Rating>();
         if (!this.rating.Contains(newRating))
            this.rating.Add(newRating);
      }
      
      /// <summary>
      /// Remove an existing Rating from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveRating(Rating oldRating)
      {
         if (oldRating == null)
            return;
         if (this.rating != null)
            if (this.rating.Contains(oldRating))
               this.rating.Remove(oldRating);
      }
      
      /// <summary>
      /// Remove all instances of Rating from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllRating()
      {
         if (rating != null)
            rating.Clear();
      }
      public User user;
   
   }
}