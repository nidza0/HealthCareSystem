// File:    HospitalConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:52:53
// Purpose: Definition of Class HospitalConverter

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    public class HospitalConverter : ICSVConverter<Hospital>
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