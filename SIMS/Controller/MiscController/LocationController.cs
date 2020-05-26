// File:    LocationController.cs
// Author:  nikola
// Created: 22. maj 2020 17:30:10
// Purpose: Definition of Class LocationController

using System;
using System.Collections.Generic;
using Model.User;

namespace Controller.MiscController
{
   public class LocationController : IController<Model.User.Location,long>
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

        public Service.MiscService.LocationService locationService;
   
   }
}