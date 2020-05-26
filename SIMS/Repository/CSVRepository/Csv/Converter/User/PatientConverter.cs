// File:    PatientConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:26
// Purpose: Definition of Class PatientConverter

using System;
using Model.User;

namespace Repository.CSVRepository.Csv.Converter.User
{
   public class PatientConverter : ICSVConverter<Model.User.Patient>
   {
      private string delimiter;
      private string dateTimeFormat;

        public Patient ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}