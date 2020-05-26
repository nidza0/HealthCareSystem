// File:    MessageConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:05:06
// Purpose: Definition of Class MessageConverter

using System;
using Model.User;

namespace Repository.CSVRepository.Csv.Converter.Misc
{
   public class MessageConverter : ICSVConverter<Model.User.Message>
   {
      private string delimiter;
      private string dateTimeFormat;

        public Message ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}