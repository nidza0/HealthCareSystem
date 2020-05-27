// File:    ManagerConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:25
// Purpose: Definition of Class ManagerConverter

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class ManagerConverter : ICSVConverter<Manager>
    {
        private string _delimiter;
        private string _dateTimeFormat;

        public ManagerConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _dateTimeFormat = datetimeFormat;
        }

        public Manager ConvertCSVToEntity(string managerCSVFormat)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Manager entity)
        {
            throw new NotImplementedException();
        }
    }
}