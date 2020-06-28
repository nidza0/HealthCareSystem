// File:    Person.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class Person

using System;

namespace SIMS.Model.UserModel
{
    public class Person
    {
        private string _uidn;
        private string _name;
        private string _surname;
        private string _middleName;
        private DateTime _dateOfBirth;
        private string _homePhone;
        private string _cellPhone;
        private string _email1;
        private string _email2;

        private Address _address;
        private Sex _sex;

        public Person() { }
        public Person(  string name, 
                        string surname, 
                        string middleName, 
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2)
        {
            _name = name;
            _surname = surname;
            _middleName = middleName;
            _sex = sex;
            _dateOfBirth = dateOfBirth;
            _uidn = uidn;
            _address = address;
            _homePhone = homePhone;
            _cellPhone = cellPhone;
            _email1 = email1;
            _email2 = email2;
        }

        public string Uidn { get => _uidn; }
        public string Name { get => _name; }
        public string Surname { get => _surname; }
        public string MiddleName { get => _middleName; }
        public DateTime DateOfBirth { get => _dateOfBirth; }
        public string HomePhone { get => _homePhone; }
        public string CellPhone { get => _cellPhone; set => _cellPhone = value; }
        public string Email1 { get => _email1; }
        public string Email2 { get => _email2; }
        public Address Address { get => _address; set => _address = value; }
        public Sex Sex { get => _sex; }
        public string FullName
        {
            get
            {
                if (_middleName.Equals(""))
                    return _name + " " + _surname;
                else
                    return _name + " " + _middleName + " " + _surname;
            }
        }

    }
}