// File:    DiseaseConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:27
// Purpose: Definition of Class DiseaseConverter

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class DiseaseConverter : ICSVConverter<Disease>
    {
        private string delimiter;
        private string dateTimeFormat;
        private string listDelimiter;

        public Disease ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Disease entity)
        {
            throw new NotImplementedException();
        }
    }
}