// File:    LocationController.cs
// Author:  nikola
// Created: 22. maj 2020 17:30:10
// Purpose: Definition of Class LocationController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.MiscService;

namespace SIMS.Controller.MiscController
{
    public class LocationController : IController<Location, long>
    {

        public LocationService locationService;

        public IEnumerable<Location> GetLocationByCountry(string country)
            => locationService.GetLocationByCountry(country);

        public IEnumerable<string> GetAllCountries()
            => locationService.GetAllCountries();

        public IEnumerable<Location> GetAll()
            => locationService.GetAll();

        public Location GetByID(long id)
            => locationService.GetByID(id);

        public Location Create(Location entity)
            => locationService.Create(entity);

        public void Update(Location entity)
            => locationService.Update(entity);

        public void Delete(Location entity)
            => locationService.Delete(entity);

    }
}