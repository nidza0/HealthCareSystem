// File:    Notification.cs
// Author:  Geri
// Created: 18. april 2020 20:15:06
// Purpose: Definition of Class Notification

using System;

namespace Model.User
{
   public class Notification : Content
   {
      public User recipient;
      
      /// <summary>
      /// Property for User
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public User Recipient
      {
         get
         {
            return recipient;
         }
         set
         {
            this.recipient = value;
         }
      }
   
   }
}