// File:    MedicineConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:53:09
// Purpose: Definition of Class MedicineConverter

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    public class MedicineConverter : ICSVConverter<Medicine>
    {
        private string delimiter;
        private string dateTimeFormat;

        public Medicine ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Medicine entity)
        {
            throw new NotImplementedException();
        }
    }
}