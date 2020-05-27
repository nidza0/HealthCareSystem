// File:    Article.cs
// Author:  Geri
// Created: 18. april 2020 19:55:51
// Purpose: Definition of Class Article

using System;

namespace SIMS.Model.UserModel
{
    public class Article : Content
    {
        private string _title;
        private string _shortDescription;

        public Employee _author;

        public string Title { get { return _title; } }
        public string ShortDescription { get { return _shortDescription; } }
        public Employee Author { get { return _author; } }
    }
}