// File:    AppointmentConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:27
// Purpose: Definition of Class AppointmentConverter

using System;
using SIMS.Model.PatientModel;
using SIMS.Util;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class AppointmentConverter : ICSVConverter<Appointment>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";
        private readonly string _dateTimeFormat = "dd.MM.yyyy. HH:mm";

        public AppointmentConverter(string delimiter, string listDelimiter, string dateTimeFormat = "dd.MM.yyyy. HH:mm")
        {
            //Date time format not allowed in the constructor intentionally. 
            //TODO: Create an ENUM with datetimeFormat's so user can't enter a wrong format
            _delimiter = delimiter;
            _listDelimiter = listDelimiter;
            _dateTimeFormat = dateTimeFormat;
        }

        public Appointment ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);
            AppointmentType appointmentType = (AppointmentType)Enum.Parse(typeof(AppointmentType), tokens[4]); //Casting string to Enum.

            return new Appointment(
                    long.Parse(tokens[0]),
                    GetDummyDoctor(tokens[1]),
                    GetDummyPatient(tokens[2]),
                    GetDummyRoom(tokens[3]),
                    appointmentType,
                    GetTimeInterval(SplitStringByDelimiter(tokens[5], _listDelimiter))
                    );
        }

        public string ConvertEntityToCSV(Appointment entity)
            => string.Join(
                _delimiter,
                entity.GetId(),
                entity.DoctorInAppointment.GetId(),
                entity.Patient.GetId(),
                entity.Room.GetId(),
                entity.AppointmentType,
                transformTimeIntervalToCSV(entity.TimeInterval)
                );
        private string transformTimeIntervalToCSV(TimeInterval timeInterval)
            => string.Join(_listDelimiter, timeInterval.StartTime.ToString(_dateTimeFormat), timeInterval.EndTime.ToString(_dateTimeFormat));

        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
            => stringToSplit.Split(delimiter.ToCharArray());

        private Room GetDummyRoom(string id)
            => new Room(long.Parse(id));

        private Doctor GetDummyDoctor(string id)
            => new Doctor(new UserID(id));

        private Patient GetDummyPatient(string id)
            => new Patient(new UserID(id));

        private DateTime GetDateTimeFromString(string dateTime)
            => DateTime.ParseExact(dateTime, _dateTimeFormat, null);

        private TimeInterval GetTimeInterval(string[] timeIntervalCSV)
            => new TimeInterval(GetDateTimeFromString(timeIntervalCSV[0]), GetDateTimeFromString(timeIntervalCSV[1]));
    }
}