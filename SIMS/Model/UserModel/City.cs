// File:    City.cs
// Author:  Geri
// Created: 19. april 2020 20:21:44
// Purpose: Definition of Class City

using System;

namespace SIMS.Model.UserModel
{
    public class City
    {
        private string name;
        private string postalCode;

        public City(string name, string postalCode)
        {
            this.name = name;
            this.postalCode = postalCode;
        }
    }
}