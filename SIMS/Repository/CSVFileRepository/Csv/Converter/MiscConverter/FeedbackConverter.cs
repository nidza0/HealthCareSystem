// File:    FeedbackConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:04:00
// Purpose: Definition of Class FeedbackConverter

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class FeedbackConverter : ICSVConverter<Feedback>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";
        private readonly string _secondaryListDelimiter = "-";
       

        public FeedbackConverter(string delimiter, string secondaryListDelimiter, string listDelimiter)
        {
            _delimiter = delimiter;
            _listDelimiter = listDelimiter;
            
        }

        public Feedback ConvertCSVToEntity(string csv)
        {

            long tempId;
            string tempComment;
            List<Rating> tempList;

            char[] delimiter = _delimiter.ToCharArray();
            string[] tokens = csv.Split(delimiter);
            tempList = GetList(tokens[3], _listDelimiter.ToCharArray());
            
            tempId = long.Parse(tokens[0]);
            tempComment = tokens[2];

            return new Feedback(tempId, new User(new UserID(tokens[1])) ,tempComment, tempList);
        }

        private List<Rating> GetList(string listString, char[] delimiter)
        {
            List<Rating> retVal = new List<Rating>();
            string[] tokens = listString.Split(_listDelimiter.ToCharArray());

            foreach (string entity in tokens)
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

        public string ConvertEntityToCSV(Feedback entity)
            => string.Join(_delimiter,
                entity.GetId(),
                entity.User.GetId(),
                entity.Comment,
                ratingToCSV(entity.Rating)
                );

        private string ratingToCSV(IEnumerable<Rating> entity)
            => string.Join(_listDelimiter, entity.Select(rating => rating.GetId() + _secondaryListDelimiter + rating.Question + _secondaryListDelimiter + rating.Stars));
    }
}

/*
 long id, user user, List<Rating> rating
     */