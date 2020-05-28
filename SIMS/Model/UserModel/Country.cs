// File:    Country.cs
// Author:  Geri
// Created: 19. april 2020 20:21:43
// Purpose: Definition of Class Country

using System;
using System.Collections.Generic;

namespace SIMS.Model.UserModel
{
    public class Country
    {
        private string _name;
        private string _code;

        public Country(string code, string name)
        {
            _code = code;
            _name = name;
        }

        public string Name { get => _name; }
        public string Code { get => _code; }
    }
}