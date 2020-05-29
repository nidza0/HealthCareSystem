// File:    DoctorConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:24
// Purpose: Definition of Class DoctorConverter

using System;
using System.Globalization;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class DoctorConverter : ICSVConverter<Doctor>
    {
        private string _delimiter;
        private string _dateTimeFormat;

        public DoctorConverter(string delimiter, string dateTimeFormat)
        {
            _delimiter = delimiter;
            _dateTimeFormat = dateTimeFormat;
        }

        public Doctor ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            Doctor doc = new Doctor(id: new UserID(tokens[0]),
                                    userName: tokens[1],
                                    password: tokens[2],
                                    dateCreated: DateTime.ParseExact(tokens[3], _dateTimeFormat, CultureInfo.InvariantCulture),
                                    name: tokens[4],
                                    surname: tokens[5],
                                    middleName: tokens[6],
                                    sex: (Sex)Enum.Parse(typeof(Sex), tokens[7]),
                                    dateOfBirth: DateTime.ParseExact(tokens[8], _dateTimeFormat, CultureInfo.InvariantCulture),
                                    uidn: tokens[9],
                                    address: new Address(tokens[10], new Location(Convert.ToInt64(tokens[11]), tokens[12], tokens[13])),
                                    homePhone: tokens[14],
                                    cellPhone: tokens[15],
                                    email1: tokens[16],
                                    email2: tokens[17],
                                    timeTable: new TimeTable(long.Parse(tokens[18])),
                                    hospital: new Hospital(long.Parse(tokens[19])),
                                    office: new Room(long.Parse(tokens[20])),
                                    doctorType: (DocTypeEnum)Enum.Parse(typeof(DocTypeEnum), tokens[21]));

            return doc;
        }

        public string ConvertEntityToCSV(Doctor doctor)
            => string.Join(_delimiter,
                doctor.GetId().ToString(),
                doctor.UserName,
                doctor.Password,
                doctor.DateCreated.ToString(_dateTimeFormat),
                doctor.Name,
                doctor.Surname,
                doctor.MiddleName,
                doctor.Sex,
                doctor.DateOfBirth.ToString(_dateTimeFormat),
                doctor.Uidn,
                doctor.Address.Street,
                doctor.Address.Location.GetId(),
                doctor.Address.Location.Country,
                doctor.Address.Location.City,
                doctor.HomePhone,
                doctor.CellPhone,
                doctor.Email1,
                doctor.Email2,
                doctor.TimeTable.GetId(),
                doctor.Hospital.GetId(),
                doctor.Office.GetId(),
                doctor.DocTypeEnum);
    }
}