// File:    AppointmentConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:27
// Purpose: Definition of Class AppointmentConverter

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class AppointmentConverter : ICSVConverter<Appointment>
    {
        private string delimiter;
        private string dateTimeFormat;

        public Appointment ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Appointment entity)
        {
            throw new NotImplementedException();
        }
    }
}