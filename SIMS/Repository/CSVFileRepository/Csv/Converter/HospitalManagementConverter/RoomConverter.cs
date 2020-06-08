// File:    RoomConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:53:11
// Purpose: Definition of Class RoomConverter

using System;
using System.Collections.Generic;
using System.Linq;
using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    public class RoomConverter : ICSVConverter<Room>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";

        public RoomConverter(string delimiter, string listDelimiter)
        {
            _delimiter = delimiter;
            _listDelimiter = listDelimiter;
        }

        public Room ConvertCSVToEntity(string roomCSVFormat)
        {
            string[] tokens = roomCSVFormat.Split(_delimiter.ToCharArray());
            return new Room(long.Parse(tokens[0]),
                            tokens[1],
                            bool.Parse(tokens[2]),
                            int.Parse(tokens[3]),
                            (RoomType) Enum.Parse(typeof(RoomType),tokens[4]),
                            (tokens[5] == "") ? new List<InventoryItem>() : GetInventoryItemsCSVlist(tokens[5].Split(_listDelimiter.ToCharArray()))
                            );
        }

        public string ConvertEntityToCSV(Room room)
            => string.Join(_delimiter,
                           room.GetId(),
                           room.RoomNumber,
                           room.Occupied,
                           room.Floor,
                           room.RoomType,
                           GetInventoryItemsCSVstring(room.InventoryItem));


        private string GetInventoryItemsCSVstring(List<InventoryItem> inventoryItem)
           => string.Join(_listDelimiter, inventoryItem.Select(room => room.GetId()));

        private List<InventoryItem> GetInventoryItemsCSVlist(string[] ids)
            => ids.ToList().ConvertAll(x => new InventoryItem(long.Parse(x)));

    }
}