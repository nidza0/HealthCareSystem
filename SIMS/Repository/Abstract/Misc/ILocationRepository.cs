// File:    ILocationRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:07:21
// Purpose: Definition of Interface ILocationRepository

using System;
using System.Collections.Generic;
using Model.User;

namespace Repository.Abstract.Misc
{
   public interface ILocationRepository : IRepository<Model.User.Location,long>
   {
      IEnumerable<Location> GetLocationByCountry(Model.User.Country country);
      
      IEnumerable<Country> GetAllCountries();
   
   }
}