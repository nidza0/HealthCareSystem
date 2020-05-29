// File:    ArticleConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:02:36
// Purpose: Definition of Class ArticleConverter

using System;
using System.Text;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter
{
    public class ArticleConverter : ICSVConverter<Article>
    {
        private string _delimiter;
        private string _dateTimeFormat;

        public ArticleConverter(string delimiter, string dateTimeFormat)
        {
            _delimiter = delimiter;
            _dateTimeFormat = dateTimeFormat;
        }

        public Article ConvertCSVToEntity(string csv)
        {
            string[] tokens = csv.Split(_delimiter.ToCharArray());

            Article retVal = new Article(tokens[1], tokens[2], tokens[3], new Employee(new UserID(tokens[4])), DateTime.Parse(tokens[5]));
            retVal.SetId(Convert.ToInt64(tokens[0]));
            return retVal;
        }

        public string ConvertEntityToCSV(Article article)
            => string.Join(_delimiter,
                article.GetId(),
                article.Title,
                article.ShortDescription,
                article.Text,
                article.Author.GetId().ToString(),
                article.Date.ToString(_dateTimeFormat));
    }
}