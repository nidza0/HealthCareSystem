// File:    IUserValidation.cs
// Author:  Geri
// Created: 22. maj 2020 12:37:45
// Purpose: Definition of Interface IUserValidation

using System;

namespace Util
{
   public interface IUserValidation : IPersonValidation
   {
      bool CheckUsername(string username);
      
      bool CheckPassword(string password);
   
   }
}