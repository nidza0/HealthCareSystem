// File:    ManagerConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:25
// Purpose: Definition of Class ManagerConverter

using System;
using System.Globalization;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class ManagerConverter : ICSVConverter<Manager>
    {
        private string _delimiter;
        private string _dateTimeFormat;

        public ManagerConverter(string delimiter, string datetimeFormat)
        {
            _delimiter = delimiter;
            _dateTimeFormat = datetimeFormat;
        }

        public Manager ConvertCSVToEntity(string managerCSVFormat)
        {
            string[] tokens = managerCSVFormat.Split(_delimiter.ToCharArray());

            Manager manager = new Manager(id: new UserID(tokens[0]),
                                            userName: tokens[1],
                                            password: tokens[2],
                                            dateCreated: DateTime.ParseExact(tokens[3], _dateTimeFormat, CultureInfo.InvariantCulture),
                                            name: tokens[4],
                                            surname: tokens[5],
                                            middleName: tokens[6],
                                            sex: (Sex) Enum.Parse(typeof(Sex), tokens[7]),
                                            dateOfBirth: DateTime.ParseExact(tokens[8], _dateTimeFormat, CultureInfo.InvariantCulture),
                                            uidn: tokens[9], 
                                            address: new Address(tokens[10], new Location(long.Parse(tokens[11]), tokens[12], tokens[13])),
                                            homePhone: tokens[14],
                                            cellPhone: tokens[15], 
                                            email1: tokens[16],
                                            email2: tokens[17],
                                            timeTable: new TimeTable(long.Parse(tokens[18])),
                                            hospital: new Hospital(long.Parse(tokens[19])));

            return manager;
        }

        public string ConvertEntityToCSV(Manager manager)
            => string.Join(_delimiter,
                manager.GetId(),
                manager.UserName,
                manager.Password,
                manager.DateCreated.ToString(_dateTimeFormat),
                manager.Name,
                manager.Surname,
                manager.MiddleName,
                manager.Sex,
                manager.DateOfBirth.ToString(_dateTimeFormat),
                manager.Uidn,
                manager.Address.Street,
                manager.Address.Location.GetId(),
                manager.Address.Location.Country,
                manager.Address.Location.City,
                manager.HomePhone,
                manager.CellPhone,
                manager.Email1,
                manager.Email2,
                manager.TimeTable.GetId(),
                manager.Hospital.GetId());
    }
}