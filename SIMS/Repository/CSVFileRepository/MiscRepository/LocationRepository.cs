// File:    LocationRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:33:21
// Purpose: Definition of Class LocationRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class LocationRepository : CSVRepository<Location, long>, ILocationRepository
    {
        public LocationRepository(string entityName, ICSVStream<Location> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Location>())
        {
        }

        public IEnumerable<string> GetAllCountries()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> GetLocationByCountry(string country)
            => GetAll().ToList().Where(location => location.Country == country);

    }
}