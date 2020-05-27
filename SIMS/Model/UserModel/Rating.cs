// File:    Rating.cs
// Author:  Geri
// Created: 18. april 2020 20:35:26
// Purpose: Definition of Class Rating

using System;

namespace SIMS.Model.UserModel
{
    public class Rating
    {
        private long _id;
        private string _question;
        private int _stars;

        public long Id { get { return _id; } set { } }

        public string Question { get { return _question; } set { } }

        public int Stars { get { return _stars} set { }}

        public Rating(long id, string question, int stars)
        {
            _id = id;
            _question = question;
            _stars = stars;
        }
    }
}