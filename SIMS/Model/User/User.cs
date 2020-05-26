// File:    User.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class User

using System;

namespace Model.User
{
   public class User : Person
   {
      private String userName;
      private String password;
      private DateTime dateCreated;
      private bool deleted;
      
      public UserID userID;
   
   }
}