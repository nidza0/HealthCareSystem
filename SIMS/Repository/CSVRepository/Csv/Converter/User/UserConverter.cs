// File:    UserConverter.cs
// Author:  nikola
// Created: 26. maj 2020 22:09:02
// Purpose: Definition of Class UserConverter

using System;
using Model.User;

namespace Repository.CSVRepository.Csv.Converter.User
{
   public class UserConverter : ICSVConverter<Model.User.User>
   {
      private string delimiter;
      private string dateTimeFormat;

        public Model.User.User ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Model.User.User entity)
        {
            throw new NotImplementedException();
        }
    }
}