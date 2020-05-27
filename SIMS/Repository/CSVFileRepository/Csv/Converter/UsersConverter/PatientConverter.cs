// File:    PatientConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:26
// Purpose: Definition of Class PatientConverter

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class PatientConverter : ICSVConverter<Patient>
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