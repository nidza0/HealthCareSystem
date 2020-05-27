// File:    ArticleConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:02:36
// Purpose: Definition of Class ArticleConverter

using System;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class ArticleConverter : ICSVConverter<Article>
    {
        private string delimiter;
        private string dateTimeFormat;

        public Article ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        public string ConvertEntityToCSV(Article entity)
        {
            throw new NotImplementedException();
        }
    }
}