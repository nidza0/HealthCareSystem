// File:    MedicalRecordConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:28
// Purpose: Definition of Class MedicalRecordConverter

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class MedicalRecordConverter : ICSVConverter<MedicalRecord>
    {
        private string delimiter;
        private string dateTimeFormat;

        public MedicalRecord ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(MedicalRecord entity)
        {
            throw new NotImplementedException();
        }
    }
}