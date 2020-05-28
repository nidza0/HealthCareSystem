// File:    User.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class User

using SIMS.Repository.Abstract;
using System;

namespace SIMS.Model.UserModel
{
    public class User : Person, IIdentifiable<UserID>
    {
        private string _userName;
        private string _password;
        private DateTime _dateCreated;
        private bool _deleted;

        private UserID _userID;

        public User(UserID id) : base() { _userID = id; }

        public User(string userName, string password, DateTime dateCreated, string name, string surname, string middleName, Sex sex, DateTime dateOfBirth, string uidn, Address address, string homePhone, string cellPhone, string email1, string email2) : base(name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _userName = userName;
            _password = password;
            _dateCreated = dateCreated;
        }

        public UserID GetId()
        {
            return _userID;
        }

        public void SetId(UserID id)
        {
            _userID = id;
        }

        public string UserName { get => _userName; }
        public string Password { get => _password; }
        public DateTime DateCreated { get => _dateCreated; }
        public bool Deleted { get => _deleted; }
    }
}