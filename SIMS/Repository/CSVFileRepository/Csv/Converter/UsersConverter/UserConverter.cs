// File:    UserConverter.cs
// Author:  nikola
// Created: 26. maj 2020 22:09:02
// Purpose: Definition of Class UserConverter

using System;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter
{
    public class UserConverter : ICSVConverter<Model.UserModel.User>
    {
        private string delimiter;
        private string dateTimeFormat;

        public Model.UserModel.User ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Model.UserModel.User entity)
        {
            throw new NotImplementedException();
        }
    }
}