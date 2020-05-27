// File:    DoctorConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:24
// Purpose: Definition of Class DoctorConverter

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class DoctorConverter : ICSVConverter<Doctor>
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