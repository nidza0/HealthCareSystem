// File:    DoctorConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:24
// Purpose: Definition of Class DoctorConverter

using System;
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

            Doctor doc = new Doctor(new UserID(tokens[0]), //id
                                    tokens[1], //username
                                    tokens[2], //password
                                    DateTime.Parse(tokens[3]), //dateCreated
                                    tokens[4], //name
                                    tokens[5], //surname
                                    tokens[6], //middleName
                                    (Sex)Enum.Parse(typeof(Sex), tokens[7]), //sex
                                    DateTime.Parse(tokens[8]), //dateOfBirth
                                    tokens[9], //uidn
                                    new Address(tokens[10], new Location(Convert.ToInt64(tokens[11]), tokens[12], tokens[13])), //address
                                    tokens[14], //homePhone
                                    tokens[15], //cellPhone
                                    tokens[16], //email1
                                    tokens[17], //email2
                                    new TimeTable(Convert.ToInt64(tokens[18])), //timetable
                                    new Hospital(Convert.ToInt64(tokens[19])),
                                    new Room(Convert.ToInt64(tokens[20])),
                                    (DocTypeEnum)Enum.Parse(typeof(DocTypeEnum), tokens[21])); //doctorType

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