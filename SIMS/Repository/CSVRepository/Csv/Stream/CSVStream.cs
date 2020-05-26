// File:    CSVStream.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:44:52
// Purpose: Definition of Class CSVStream

using System;
using System.Collections.Generic;


namespace Repository.CSVRepository.Csv.Stream
{
   public class CSVStream<T> : ICSVStream<T>
   {
      private string path;
      
      public Repository.CSVRepository.Csv.Converter.ICSVConverter<T> iCSVConverter;

        public void SaveAll(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void AppendToFile(T enitity)
        {
            throw new NotImplementedException();
        }
    }
}