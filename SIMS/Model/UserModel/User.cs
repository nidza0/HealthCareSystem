// File:    User.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class User

using System;

namespace SIMS.Model.UserModel
{
    public class User : Person
    {
        private string userName;
        private string password;
        private DateTime dateCreated;
        private bool deleted;

        public UserID userID;

    }
}