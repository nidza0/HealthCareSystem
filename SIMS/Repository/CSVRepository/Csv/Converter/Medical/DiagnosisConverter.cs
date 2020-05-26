// File:    DiagnosisConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:27
// Purpose: Definition of Class DiagnosisConverter

using System;
using Model.Patient;

namespace Repository.CSVRepository.Csv.Converter.Medical
{
   public class DiagnosisConverter : ICSVConverter<Model.Patient.Diagnosis>
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