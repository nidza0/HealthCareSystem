// File:    TherapyConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:28
// Purpose: Definition of Class TherapyConverter

using System;
using Model.Patient;

namespace Repository.CSVRepository.Csv.Converter.Medical
{
   public class TherapyConverter : ICSVConverter<Model.Patient.Therapy>
   {
      private string delimiter;
      private string dateTimeFormat;

        public Therapy ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Therapy entity)
        {
            throw new NotImplementedException();
        }
    }
}