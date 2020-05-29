// File:    SecretaryConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:27
// Purpose: Definition of Class SecretaryConverter

using System;
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

            Secretary secretary = new Secretary(new UserID(tokens[0]),
                                            tokens[1], //username
                                            tokens[2], //password
                                            DateTime.Parse(tokens[3]), //dateCreated
                                            tokens[4], //name
                                            tokens[5], //surname
                                            tokens[6], //middlename
                                            (Sex)Enum.Parse(typeof(Sex), tokens[7]),
                                            DateTime.Parse(tokens[8]), //dateOfBirth
                                            tokens[9], //uidn
                                            new Address(tokens[10], new Location(Int64.Parse(tokens[11]), tokens[12], tokens[13])),
                                            tokens[14], //homePhone
                                            tokens[15], //cellPhone
                                            tokens[16], //email1
                                            tokens[17], //email2
                                            new TimeTable(Int64.Parse(tokens[18])),
                                            new Hospital(Int64.Parse(tokens[19])));

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