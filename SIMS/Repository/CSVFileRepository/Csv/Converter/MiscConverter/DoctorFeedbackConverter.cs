// File:    DoctorFeedbackConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:03:13
// Purpose: Definition of Class DoctorFeedbackConverter

using System;
using SIMS.Model.DoctorModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class DoctorFeedbackConverter : ICSVConverter<DoctorFeedback>
    {
        private string delimiter;
        private string dateTimeFormat;

        public DoctorFeedback ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(DoctorFeedback entity)
        {
            throw new NotImplementedException();
        }
    }
}