// File:    NotificationConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:05:43
// Purpose: Definition of Class NotificationConverter

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class NotificationConverter : ICSVConverter<Notification>
    {
        private string delimiter;
        private string dateTimeFormat;

        public Notification ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Notification entity)
        {
            throw new NotImplementedException();
        }
    }
}