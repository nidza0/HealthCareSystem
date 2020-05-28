// File:    PatientConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:26
// Purpose: Definition of Class PatientConverter

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class PatientConverter : ICSVConverter<Patient>
    {
        private string _delimiter;
        private string _dateTimeFormat;

        public PatientConverter(string delimiter, string dateTimeFormat)
        {
            _delimiter = delimiter;
            _dateTimeFormat = dateTimeFormat;
        }

        public Patient ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            Patient patient = new Patient(  new UserID(tokens[0]),
                                            tokens[1], //username
                                            tokens[2], //password
                                            DateTime.Parse(tokens[3]), //dateCreated
                                            tokens[4], //name
                                            tokens[5], //surname
                                            tokens[6], //middleName
                                            (Sex) Enum.Parse(typeof(Sex), tokens[7]),
                                            DateTime.Parse(tokens[8]), //dateOfBirth
                                            tokens[9], //uidn
                                            new Address(tokens[10], new Location(Int64.Parse(tokens[11]), tokens[12], tokens[13])),
                                            tokens[14], //homePhone
                                            tokens[15], //cellPhone
                                            tokens[16], //email1
                                            tokens[17], //email2
                                            new EmergencyContact(tokens[18], tokens[19], tokens[20], tokens[21]),
                                            (PatientType) Enum.Parse(typeof(PatientType), tokens[22]),
                                            new Doctor(new UserID(tokens[23])));

            return patient;
        }

        public string ConvertEntityToCSV(Patient patient)
            => string.Join(_delimiter,
                patient.GetId(),
                patient.UserName,
                patient.Password,
                patient.DateCreated.ToString(_dateTimeFormat),
                patient.Name,
                patient.Surname,
                patient.MiddleName,
                patient.Sex,
                patient.DateOfBirth.ToString(_dateTimeFormat),
                patient.Uidn,
                patient.Address.Street,
                patient.Address.Location.GetId(),
                patient.Address.Location.Country,
                patient.Address.Location.City,
                patient.HomePhone,
                patient.CellPhone,
                patient.Email1,
                patient.Email2,
                patient.EmergencyContact.Name,
                patient.EmergencyContact.Surname,
                patient.EmergencyContact.Email,
                patient.EmergencyContact.PhoneNumber,
                patient.PatientType,
                patient.SelectedDoctor.GetId());
    }
}