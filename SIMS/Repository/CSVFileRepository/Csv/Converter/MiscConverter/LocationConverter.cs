// File:    LocationConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:04:31
// Purpose: Definition of Class LocationConverter

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class LocationConverter : ICSVConverter<Location>
    {
        private string delimiter;

        public Location ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Location entity)
        {
            throw new NotImplementedException();
        }
    }
}