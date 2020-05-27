// File:    CSVStream.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:44:52
// Purpose: Definition of Class CSVStream

using SIMS.Repository.CSVFileRepository.Csv.Converter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.Csv.Stream
{
    public class CSVStream<T> : ICSVStream<T> where T : class
    {
        private readonly string _path;
        private ICSVConverter<T> _converter;

        public CSVStream(string path, ICSVConverter<T> converter)
        {
            _path = path;
            _converter = converter;
        }

        public void SaveAll(IEnumerable<T> entities)
            => WriteAllLinesToFile(entities.Select(_converter.ConvertEntityToCSV).ToList());
        
        private void WriteAllLinesToFile(IEnumerable<string> list)
            => File.WriteAllLines(_path, list.ToArray());

        public IEnumerable<T> ReadAll()
            => File.ReadAllLines(_path)
            .Select(_converter.ConvertCSVToEntity)
            .ToList();

        public void AppendToFile(T entity)
            => File.AppendAllText(_path, _converter.ConvertEntityToCSV(entity) + Environment.NewLine)
    }
}