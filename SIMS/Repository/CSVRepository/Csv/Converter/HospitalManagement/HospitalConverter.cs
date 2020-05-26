// File:    HospitalConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:52:53
// Purpose: Definition of Class HospitalConverter

using System;
using Model.User;

namespace Repository.CSVRepository.Csv.Converter.HospitalManagement
{
   public class HospitalConverter : ICSVConverter<Model.User.Hospital>
   {
      private string delimiter;

        public Hospital ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Hospital entity)
        {
            throw new NotImplementedException();
        }
    }
}