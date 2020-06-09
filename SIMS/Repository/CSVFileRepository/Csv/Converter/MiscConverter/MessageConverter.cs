// File:    MessageConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:05:06
// Purpose: Definition of Class MessageConverter

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class MessageConverter : ICSVConverter<Message>
    {
        private readonly string _delimiter = ",";
        private readonly string _dateTimeFormat = "dd/mm/yyyy HH:mm";

        public MessageConverter()
        {
        }

        public Message ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());
            long tempId = long.Parse(tokens[0]);
            
            return new Message(tempId, 
                tokens[1], 
                new User(new UserID(tokens[2])), 
                new User(new UserID(tokens[3])), 
                DateTime.Parse(tokens[4]), 
                bool.Parse(tokens[5]));
        }

        public string ConvertEntityToCSV(Message entity)
            => string.Join(_delimiter,
                entity.GetId(),
                entity.Text,
                entity.Recipient.GetId(),
                entity.Sender.GetId(),
                entity.Date.ToString(_dateTimeFormat),
                entity.Opened
                );
    }
}