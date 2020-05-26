// File:    NotificationConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:05:43
// Purpose: Definition of Class NotificationConverter

using System;
using Model.User;

namespace Repository.CSVRepository.Csv.Converter.Misc
{
   public class NotificationConverter : ICSVConverter<Model.User.Notification>
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