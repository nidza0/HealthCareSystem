// File:    UserID.cs
// Author:  Geri
// Created: 22. maj 2020 13:34:58
// Purpose: Definition of Class UserID

using SIMS.Exceptions;
using System;
using System.ComponentModel;

namespace SIMS.Model.UserModel
{
    public class UserID
    {
        private char _code;
        private int _number;
        private static string patientPrefix;
        private static string doctorPrefix;
        private static string secretaryPrefix;
        private static string managerPrefix;

        public UserID(string id)
        {
            if(id == null || id.Length < 2)
            {
                throw new InvalidUserIdException();
            }

            _code = id[0];
            try
            {
                _number = Convert.ToInt32(id.Substring(1));
            }
            catch(Exception e)
            {
                throw new InvalidUserIdException("Invalid User ID", e);
            }
        }
        public override string ToString()
        {
            return _code.ToString() + _number;
        }

        public UserID increment()
        {
            this._number++;
            return this;
        }
    }
}