// File:    ManagerConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:25
// Purpose: Definition of Class ManagerConverter

using System;
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

            Manager manager = new Manager(  new UserID(tokens[0]),
                                            tokens[1], //username
                                            tokens[2], //password
                                            DateTime.Parse(tokens[3]), //dateCreated
                                            tokens[4], //name
                                            tokens[5], //surname
                                            tokens[6], //middlename
                                            (Sex) Enum.Parse(typeof(Sex), tokens[7]),
                                            DateTime.Parse(tokens[8]), //dateOfBirth
                                            tokens[9], //uidn
                                            new Address(tokens[10], new Location(Int64.Parse(tokens[11]), tokens[12], tokens[13])),
                                            tokens[14], //homePhone
                                            tokens[15], //cellPhone
                                            tokens[16], //email1
                                            tokens[17], //email2
                                            new TimeTable(Int64.Parse(tokens[18])),
                                            new Hospital(Int64.Parse(tokens[19])));

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