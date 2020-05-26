// File:    IPersonValidation.cs
// Author:  Geri
// Created: 22. maj 2020 12:07:12
// Purpose: Definition of Interface IPersonValidation

using System;

namespace Util
{
   public interface IPersonValidation
   {
      bool CheckName(string name);
      
      bool CheckUidn(string uidn);
      
      bool CheckDateOfBirth(DateTime date);
      
      bool CheckEmail(string email);
      
      bool CheckPhoneNumber(string phoneNumber);
   
   }
}