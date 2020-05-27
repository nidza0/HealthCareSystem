// File:    Content.cs
// Author:  Geri
// Created: 18. april 2020 19:55:51
// Purpose: Definition of Class Content

using System;

namespace SIMS.Model.UserModel
{
    public abstract class Content
    {
        private long _id;
        private string _text;
        private DateTime _dateCreated;

        public long Id { get {return _id;} }
        public string Text { get { return _text; } }
        public DateTime Date { get { return _dateCreated; } }
    }
}