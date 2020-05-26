// File:    AppointmentConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:27
// Purpose: Definition of Class AppointmentConverter

using System;
using Model.Patient;

namespace Repository.CSVRepository.Csv.Converter.Medical
{
   public class AppointmentConverter : ICSVConverter<Model.Patient.Appointment>
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