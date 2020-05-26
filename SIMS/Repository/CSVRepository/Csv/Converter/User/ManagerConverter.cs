// File:    ManagerConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:25
// Purpose: Definition of Class ManagerConverter

using System;
using Model.User;

namespace Repository.CSVRepository.Csv.Converter.User
{
   public class ManagerConverter : ICSVConverter<Model.User.Manager>
   {
      private string delimiter;
      private string dateTimeFormat;

        public Manager ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Manager entity)
        {
            throw new NotImplementedException();
        }
    }
}