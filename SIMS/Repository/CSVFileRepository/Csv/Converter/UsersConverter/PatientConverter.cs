// File:    PatientConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:07:26
// Purpose: Definition of Class PatientConverter

using System;
using System.Globalization;
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

            Patient patient = new Patient(id: new UserID(tokens[0]),
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
                                            emergencyContact: new EmergencyContact(tokens[18], tokens[19], tokens[20], tokens[21]),
                                            patientType: (PatientType)Enum.Parse(typeof(PatientType), tokens[22]),
                                            selectedDoctor: new Doctor(new UserID(tokens[23])));

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