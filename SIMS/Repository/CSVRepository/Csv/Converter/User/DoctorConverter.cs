// File:    DoctorConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:24
// Purpose: Definition of Class DoctorConverter

using System;
using Model.User;

namespace Repository.CSVRepository.Csv.Converter.User
{
   public class DoctorConverter : ICSVConverter<Model.User.Doctor>
   {
      private string delimiter;
      private string dateTimeFormat;

        public Doctor ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Doctor entity)
        {
            throw new NotImplementedException();
        }
    }
}