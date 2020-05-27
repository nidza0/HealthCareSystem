// File:    FeedbackConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:04:00
// Purpose: Definition of Class FeedbackConverter

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class FeedbackConverter : ICSVConverter<Feedback>
    {
        private string delimiter;
        private string dateTimeFormat;

        public Feedback ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Feedback entity)
        {
            throw new NotImplementedException();
        }
    }
}