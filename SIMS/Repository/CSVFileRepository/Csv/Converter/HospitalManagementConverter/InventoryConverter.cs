// File:    InventoryConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:53:08
// Purpose: Definition of Class InventoryConverter

using System;
using SIMS.Model.ManagerModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    public class InventoryConverter : ICSVConverter<Inventory>
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