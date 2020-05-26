// File:    InventoryConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:53:08
// Purpose: Definition of Class InventoryConverter

using System;
using Model.Manager;

namespace Repository.CSVRepository.Csv.Converter.HospitalManagement
{
   public class InventoryConverter : ICSVConverter<Model.Manager.Inventory>
   {
      private string delimiter;
      private string dateTimeFormat;

 

        public string ConvertEntityToCSV(Inventory entity)
        {
            throw new NotImplementedException();
        }

        Inventory ICSVConverter<Inventory>.ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }
    }
}