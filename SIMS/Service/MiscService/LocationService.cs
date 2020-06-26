// File:    LocationService.cs
// Author:  Geri
// Created: 7. maj 2020 12:08:07
// Purpose: Definition of Class LocationService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.MiscRepository;

namespace SIMS.Service.MiscService
{
    public class LocationService : IService<Location, long>
    {

        private LocationRepository _locationRepository;

        public LocationService(LocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public IEnumerable<Location> GetLocationByCountry(string country)
            => _locationRepository.GetLocationByCountry(country);

        public IEnumerable<string> GetAllCountries()
            => _locationRepository.GetAllCountries();

        public IEnumerable<Location> GetAll()
            => _locationRepository.GetAll();

        public Location GetByID(long id)
            => _locationRepository.GetByID(id);

        public Location Create(Location entity)
        {
            // TODO: Validate
            return _locationRepository.Create(entity);
        }

        public void Update(Location entity)
        {
            // TODO: Validate
            _locationRepository.Update(entity);
        }

        public void Delete(Location entity)
            => _locationRepository.Delete(entity);

        public void Validate(Location entity)
        {
            throw new NotImplementedException();
        }
    }
}