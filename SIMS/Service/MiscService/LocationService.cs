// File:    LocationService.cs
// Author:  Geri
// Created: 7. maj 2020 12:08:07
// Purpose: Definition of Class LocationService

using System;
using System.Collections.Generic;
using Model.User;

namespace Service.MiscService
{
   public class LocationService : IService<Model.User.Location,long>
   {
      public IEnumerable<Location> GetLocationByCountry(Model.User.Country country)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Country> GetAllCountries()
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

        public Repository.Abstract.Misc.ILocationRepository iLocationRepository;
   
   }
}