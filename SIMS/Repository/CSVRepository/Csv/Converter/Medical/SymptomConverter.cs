// File:    SymptomConverter.cs
// Author:  Geri
// Created: 23. maj 2020 19:53:46
// Purpose: Definition of Class SymptomConverter

using System;
using Model.Patient;

namespace Repository.CSVRepository.Csv.Converter.Medical
{
   public class SymptomConverter : ICSVConverter<Model.Patient.Symptom>
   {
      private string delimiter;

        public Symptom ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Symptom entity)
        {
            throw new NotImplementedException();
        }
    }
}