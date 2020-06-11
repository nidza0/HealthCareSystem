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

        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public DateTime DateCreated { get => _dateCreated; set => _dateCreated = value; }
        public bool Deleted { get => _deleted; set => _deleted = value; }
        public UserID UserID { get => _userID; set => _userID = value; }

        public User(UserID id) : base() { _userID = id; }

        public User(string userName,
                    string password, 
                    DateTime dateCreated, 
                    string name, 
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
            : base(name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _userName = userName;
            _password = password;
            _dateCreated = dateCreated;
        }

        public User(UserID id, 
                    string userName, 
                    string password, 
                    DateTime dateCreated, 
                    string name, 
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
            : base(name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _userID = id;
            _userName = userName;
            _password = password;
            _dateCreated = dateCreated;
        }

        public User(string userName,
                    string password,
                    string name,
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
            : base(name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _userName = userName;
            _password = password;
        }

        public User(UserID id,
                    string username,
                    string password,
                    DateTime dateCreated,
                    bool deleted)
            : base()
        {
            _userID = id;
            _userName = username;
            _password = password;
            _dateCreated = dateCreated;
            _deleted = deleted;
        }

        public UserID GetId()
        {
            return _userID;
        }

        public void SetId(UserID id)
        {
            _userID = id;
        }



        public override bool Equals(object obj)
        {
            User otherUser = obj as User;
            if (otherUser == null) return false;
            return _userID.Equals(otherUser.GetId());
        }
    }
}