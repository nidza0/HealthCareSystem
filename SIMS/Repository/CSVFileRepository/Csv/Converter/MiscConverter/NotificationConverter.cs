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
        private readonly string _delimiter = ",";
        private readonly string _dateTimeFormat = "dd/mmm/yyyy HH:mm";

        public NotificationConverter(string delimiter, string dateTimeFormat = "dd/mm/yyyy HH:mm")
        {
            _delimiter = delimiter;
            _dateTimeFormat = dateTimeFormat;
        }

        public Notification ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());
            long tempId = long.Parse(tokens[0]);
            return new Notification(tempId, 
                tokens[1], 
                new User(new UserID(tokens[2])), 
                DateTime.Parse(tokens[3]));
        }

        public string ConvertEntityToCSV(Notification entity)
            => string.Join(_delimiter,
                entity.GetId(),
                entity.Text,
                entity.Recipient.GetId(),
                entity.Date.ToString(_dateTimeFormat)
                );
    }
}