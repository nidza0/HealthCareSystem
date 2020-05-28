// File:    Location.cs
// Author:  Geri
// Created: 19. april 2020 20:30:46
// Purpose: Definition of Class Location

using SIMS.Repository.Abstract;
using System;

namespace SIMS.Model.UserModel
{
    public class Location : IIdentifiable<long>
    {
        private long _id;

        private Country _country;
        private City _city;

        public Location(Country country, City city)
        {
            _country = country;
            _city = city;
        }

        public Location(long id, Country country, City city)
        {
            _id = id;
            _country = country;
            _city = city;
        }

        public Location(long id)
        {
            _id = id;
        }

        public Country Country
        {
            get { return _country;  }
            set { _country = value;  }
        }
        
        public City City
        {
            get { return _city; }
            set { _city = value; }
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