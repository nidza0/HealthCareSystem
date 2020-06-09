// File:    LocationService.cs
// Author:  Geri
// Created: 7. maj 2020 12:08:07
// Purpose: Definition of Class LocationService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;

namespace SIMS.Service.MiscService
{
    public class LocationService : IService<Location, long>
    {
        public IEnumerable<Location> GetLocationByCountry(string country)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetAllCountries()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetAll()
        {
            throw new NotImplementedException();
        }

        public Location GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Location Create(Location entity)
        {
            throw new NotImplementedException();
        }

        public Location Update(Location entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Location entity)
        {
            throw new NotImplementedException();
        }

        public ILocationRepository iLocationRepository;

    }
}