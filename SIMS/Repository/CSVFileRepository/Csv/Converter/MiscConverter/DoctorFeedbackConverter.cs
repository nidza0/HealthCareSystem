// File:    DoctorFeedbackConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:03:13
// Purpose: Definition of Class DoctorFeedbackConverter

using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using System.Net;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class DoctorFeedbackConverter : ICSVConverter<DoctorFeedback>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";
        private readonly string _secondaryListDelimiter = "-";
        

        public DoctorFeedbackConverter(string delimiter, string listDelimiter)
        {
            _delimiter = delimiter;
            _listDelimiter = listDelimiter;
            

        }

        public DoctorFeedback ConvertCSVToEntity(string csv)
        {
            long tempId;
            User tempUser;
            string tempComment;
            List<Rating> tempRating;
            Doctor tempRecepient;

            char[] delimiter = _delimiter.ToCharArray();
            string[] tokens = csv.Split(delimiter);

            tempId = long.Parse(tokens[0]);
            tempUser = new User(new UserID(tokens[1].Trim()));
            tempComment = tokens[2];
            tempRating = GetList(tokens[3], _listDelimiter.ToCharArray());
            tempRecepient = new Doctor(new UserID(tokens[4].Trim()));

            return new DoctorFeedback(tempId, tempUser, tempComment, tempRating, tempRecepient);

        }

        private List<Rating> GetList(string listString, char[] delimiter)
        {
            List<Rating> retVal = new List<Rating>();
            string[] tokens = listString.Split(delimiter);
            
            foreach(string entity in tokens)
            {
                string[] attributes = entity.Split(_secondaryListDelimiter.ToCharArray());
                retVal.Add(GetRating(attributes));
            }

            return retVal;
        }

        private Rating GetRating(string[] attributes) 
        {
            long tempId;
            int tempStars;
            long.TryParse(attributes[0], out tempId);
            int.TryParse(attributes[2], out tempStars);
            return new Rating(tempId, attributes[1], tempStars);
        }
            

        public string ConvertEntityToCSV(DoctorFeedback entity)
            => string.Join(_delimiter,
                entity.GetId(),
                entity.User.GetId(),
                entity.Comment,
                ratingToCSV(entity.Rating),
                entity.Recepient.GetId()
                );


        private string ratingToCSV(IEnumerable<Rating> entity)
            => string.Join(_listDelimiter, entity.Select(rating => rating.GetId() + _secondaryListDelimiter + rating.Question + _secondaryListDelimiter + rating.Stars));

        
        
    }
}