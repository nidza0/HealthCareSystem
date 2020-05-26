// File:    RoomConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:53:11
// Purpose: Definition of Class RoomConverter

using System;
using Model.User;

namespace Repository.CSVRepository.Csv.Converter.HospitalManagement
{
   public class RoomConverter : ICSVConverter<Model.User.Room>
   {
      private string delimiter;

        public Room ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Room entity)
        {
            throw new NotImplementedException();
        }
    }
}