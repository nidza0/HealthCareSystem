// File:    DiagnosisConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:27
// Purpose: Definition of Class DiagnosisConverter

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class DiagnosisConverter : ICSVConverter<Diagnosis>
    {
        private string delimiter;
        private string dateTimeFormat;

        public Diagnosis ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Diagnosis entity)
        {
            throw new NotImplementedException();
        }
    }
}