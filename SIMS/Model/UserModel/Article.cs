// File:    Article.cs
// Author:  Geri
// Created: 18. april 2020 19:55:51
// Purpose: Definition of Class Article

using System;

namespace SIMS.Model.UserModel
{
    public class Article : Content
    {
        private string title;
        private string shortDescription;

        public Employee author;

    }
}