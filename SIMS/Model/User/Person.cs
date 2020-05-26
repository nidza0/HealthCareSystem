// File:    Person.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class Person

using System;

namespace Model.User
{
   public class Person
   {
      private String uidn;
      private String name;
      private String surname;
      private String middleName;
      private DateTime dateOfBirth;
      private String homePhone;
      private String cellPhone;
      private String email1;
      private String email2;
      
      public Address address;
      public Sex sex;
   
   }
}