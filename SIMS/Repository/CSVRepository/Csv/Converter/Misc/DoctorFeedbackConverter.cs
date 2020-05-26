// File:    DoctorFeedbackConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:03:13
// Purpose: Definition of Class DoctorFeedbackConverter

using System;
using Model.Doctor;

namespace Repository.CSVRepository.Csv.Converter.Misc
{
   public class DoctorFeedbackConverter : ICSVConverter<Model.Doctor.DoctorFeedback>
   {
      private string delimiter;
      private string dateTimeFormat;

        public DoctorFeedback ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(DoctorFeedback entity)
        {
            throw new NotImplementedException();
        }
    }
}