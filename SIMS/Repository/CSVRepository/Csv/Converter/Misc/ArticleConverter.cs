// File:    ArticleConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:02:36
// Purpose: Definition of Class ArticleConverter

using System;
using Model.User;

namespace Repository.CSVRepository.Csv.Converter.Misc
{
   public class ArticleConverter : ICSVConverter<Model.User.Article>
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