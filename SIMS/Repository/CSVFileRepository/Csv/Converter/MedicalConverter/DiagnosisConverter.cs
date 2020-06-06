// File:    DiagnosisConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:27
// Purpose: Definition of Class DiagnosisConverter

using System;
using SIMS.Model.PatientModel;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class DiagnosisConverter : ICSVConverter<Diagnosis>
    {
        private readonly string _delimiter;
        private readonly string _dateTimeFormat;
        private readonly string _listDelimiter;

        public DiagnosisConverter(string delimiter, string listDelimiter, string dateTimeFormat = "dd.MM.yyyy. HH:mm")
        {
            _delimiter = delimiter;
            _listDelimiter = listDelimiter;
            _dateTimeFormat = dateTimeFormat;
        }


        //private long _id;
        //private Therapy _activeTherapy;
        //private DateTime _date;
        //private Disease _diagnosedDisease;
        //private List<Therapy> _previousTherapies;
        public Diagnosis ConvertCSVToEntity(string csv)
        {
            string[] tokens = SplitStringByDelimiter(csv, _delimiter);

            return new Diagnosis(
                    long.Parse(tokens[0]),
                    GetDummyDisease(tokens[1]),
                    GetDummyActiveTherapy(tokens[2]),
                    GetDateTimeFromString(tokens[3]),
                    tokens[4] == "" ? new List<Therapy>() : GetDummyPreviousTherapies(SplitStringByDelimiter(tokens[4], _listDelimiter))

                );
        }
        //public Diagnosis(long id, Disease disease, Therapy activeTherapy, DateTime issuedOn, List<Therapy> previousTherapy = null)
        public string ConvertEntityToCSV(Diagnosis entity)
            => string.Join(_delimiter,
                    entity.GetId(),
                    entity.DiagnosedDisease.GetId(),
                    entity.ActiveTherapy.GetId(),
                    entity.Date.ToString(_dateTimeFormat),
                    GetPreviousTherapyCSV(entity.PreviousTherapies)
                );

        private string[] SplitStringByDelimiter(string stringToSplit, string delimiter)
            => stringToSplit.Split(delimiter.ToCharArray());

        private string GetPreviousTherapyCSV(List<Therapy> previousTherapies)
            => string.Join(_listDelimiter, previousTherapies.Select(previousTherapy=> previousTherapy.GetId()));

        private List<Therapy> GetDummyPreviousTherapies(string[] ids)
            => ids.ToList().ConvertAll(x => new Therapy(long.Parse(x)));

        private Disease GetDummyDisease(string id)
            => new Disease(long.Parse(id));
        private Therapy GetDummyActiveTherapy(string id)
            => new Therapy(long.Parse(id));
        private DateTime GetDateTimeFromString(string dateTime)
           => DateTime.ParseExact(dateTime, _dateTimeFormat, null);
    }
}