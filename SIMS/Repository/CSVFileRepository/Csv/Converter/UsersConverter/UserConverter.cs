// File:    UserConverter.cs
// Author:  nikola
// Created: 26. maj 2020 22:09:02
// Purpose: Definition of Class UserConverter

using SIMS.Model.UserModel;
using System;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class UserConverter : ICSVConverter<User>
    {
        private string _delimiter;
        private string _dateTimeFormat;

        public UserConverter(string delimiter, string dateTimeFormat)
        {
            _delimiter = delimiter;
            _dateTimeFormat = dateTimeFormat;
        }

        public User ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            User user = new User(new UserID(tokens[0]),
                                    tokens[1], //username
                                    tokens[2], //password
                                    DateTime.Parse(tokens[3]),
                                    bool.Parse(tokens[4])); //deleted

            return user;
        }

        public string ConvertEntityToCSV(User user)
            => string.Join(_delimiter,
                            user.GetId().ToString(),
                            user.UserName,
                            user.Password,
                            user.DateCreated.ToString(_dateTimeFormat),
                            user.Deleted);
    }
}