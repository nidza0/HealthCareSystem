// File:    SecretaryConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:27
// Purpose: Definition of Class SecretaryConverter

using System;
using System.Globalization;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class SecretaryConverter : ICSVConverter<Secretary>
    {
        private string _delimiter;
        private string _dateTimeFormat;

        public SecretaryConverter(string delimiter, string dateTimeFormat)
        {
            _delimiter = delimiter;
            _dateTimeFormat = dateTimeFormat;
        }

        public Secretary ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            Secretary secretary = new Secretary(id: new UserID(tokens[0]),
                                            userName: tokens[1],
                                            password: tokens[2],
                                            dateCreated: DateTime.ParseExact(tokens[3], _dateTimeFormat, CultureInfo.InvariantCulture),
                                            name: tokens[4],
                                            surname: tokens[5],
                                            middleName: tokens[6],
                                            sex: (Sex)Enum.Parse(typeof(Sex), tokens[7]),
                                            dateOfBirth: DateTime.ParseExact(tokens[8], _dateTimeFormat, CultureInfo.InvariantCulture),
                                            uidn: tokens[9],
                                            address: new Address(tokens[10], new Location(long.Parse(tokens[11]), tokens[12], tokens[13])),
                                            homePhone: tokens[14],
                                            cellPhone: tokens[15],
                                            email1: tokens[16],
                                            email2: tokens[17],
                                            timeTable: new TimeTable(long.Parse(tokens[18])),
                                            hospital: new Hospital(long.Parse(tokens[19])));

            return secretary;
        }

        public string ConvertEntityToCSV(Secretary secretary)
            => string.Join(_delimiter,
                    secretary.GetId(),
                    secretary.UserName,
                    secretary.Password,
                    secretary.DateCreated.ToString(_dateTimeFormat),
                    secretary.Name,
                    secretary.Surname,
                    secretary.MiddleName,
                    secretary.Sex,
                    secretary.DateOfBirth.ToString(_dateTimeFormat),
                    secretary.Uidn,
                    secretary.Address.Street,
                    secretary.Address.Location.GetId(),
                    secretary.Address.Location.Country,
                    secretary.Address.Location.City,
                    secretary.HomePhone,
                    secretary.CellPhone,
                    secretary.Email1,
                    secretary.Email2,
                    secretary.TimeTable.GetId(),
                    secretary.Hospital.GetId());
    }
}