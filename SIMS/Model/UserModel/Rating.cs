// File:    Rating.cs
// Author:  Geri
// Created: 18. april 2020 20:35:26
// Purpose: Definition of Class Rating

using SIMS.Repository.Abstract;
using System;

namespace SIMS.Model.UserModel
{
    public class Rating : IIdentifiable<long>
    {
        private long _id;
        private string _question;
        private int _stars;

        public string Question { get { return _question; } set { _question = value; } }

        public int Stars { get { return _stars; } set { _stars = value; }}

        public Rating(string question, int stars)
        {
            _question = question;
            _stars = stars;
        }

        public Rating(long id, string question, int stars)
        {
            _id = id;
            _question = question;
            _stars = stars;
        }

        public long GetId()
        {
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }
    }
}