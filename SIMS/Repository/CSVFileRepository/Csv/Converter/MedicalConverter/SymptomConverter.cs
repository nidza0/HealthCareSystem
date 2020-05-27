// File:    SymptomConverter.cs
// Author:  Geri
// Created: 23. maj 2020 19:53:46
// Purpose: Definition of Class SymptomConverter

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class SymptomConverter : ICSVConverter<Symptom>
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