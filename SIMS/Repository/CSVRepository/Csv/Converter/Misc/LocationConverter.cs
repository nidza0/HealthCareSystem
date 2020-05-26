// File:    LocationConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:04:31
// Purpose: Definition of Class LocationConverter

using System;
using Model.User;

namespace Repository.CSVRepository.Csv.Converter.Misc
{
   public class LocationConverter : ICSVConverter<Model.User.Location>
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