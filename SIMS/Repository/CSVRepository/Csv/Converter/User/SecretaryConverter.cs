// File:    SecretaryConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:27
// Purpose: Definition of Class SecretaryConverter

using System;
using Model.User;

namespace Repository.CSVRepository.Csv.Converter.User
{
   public class SecretaryConverter : ICSVConverter<Model.User.Secretary>
   {
      private string delimiter;
      private string dateTimeFormat;

        public Secretary ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Secretary entity)
        {
            throw new NotImplementedException();
        }
    }
}