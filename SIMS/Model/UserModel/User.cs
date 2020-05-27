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

        public UserID GetId()
        {
            return _userID;
        }

        public void SetId(UserID id)
        {
            _userID = id;
        }
    }
}