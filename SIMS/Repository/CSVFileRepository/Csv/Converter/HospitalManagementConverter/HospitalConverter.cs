// File:    HospitalConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:52:53
// Purpose: Definition of Class HospitalConverter

using System;
using SIMS.Model.UserModel;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter
{
    public class HospitalConverter : ICSVConverter<Hospital>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";"; //Delimiter used for separating room IDs.

        public HospitalConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public Hospital ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Hospital entity)
            => string.Join(_delimiter,
                entity.ID,
                entity.Name,
                entity.Telephone,
                entity.Website,
                getAddressCSVstring(entity.Address),
                getRoomIDSCSVstring(entity.Room));

        private string getAddressCSVstring(Address address)
           => string.Join(_listDelimiter, address.Street, address.Location.ID);

        private string getRoomIDSCSVstring(IEnumerable<Room> roomList)
            => string.Join(_listDelimiter, roomList.Select(room => room.ID));

        private string getEmployeeIDSCSVstring(IEnumerable<Employee> employeeList)
            => string.Join(_listDelimiter, employeeList.Select(employee => employee.GetId()));
    }
}