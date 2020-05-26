// File:    DiseaseConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:27
// Purpose: Definition of Class DiseaseConverter

using System;
using Model.Patient;

namespace Repository.CSVRepository.Csv.Converter.Medical
{
   public class DiseaseConverter : ICSVConverter<Model.Patient.Disease>
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