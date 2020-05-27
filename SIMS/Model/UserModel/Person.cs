// File:    Person.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class Person

using System;

namespace SIMS.Model.UserModel
{
    public class Person
    {
        private string uidn;
        private string name;
        private string surname;
        private string middleName;
        private DateTime dateOfBirth;
        private string homePhone;
        private string cellPhone;
        private string email1;
        private string email2;

        public Address address;
        public Sex sex;

    }
}