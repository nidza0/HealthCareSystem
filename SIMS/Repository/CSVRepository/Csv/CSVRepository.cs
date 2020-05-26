// File:    CSVRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:43:05
// Purpose: Definition of Class CSVRepository

using System;
using Specifications;
using System.Collections.Generic;

namespace Repository.CSVRepository.Csv
{
   public class CSVRepository<T,ID> : Repository.IRepository<T,ID>
   {
      public ID GetMaxId(IEnumerable<T> entities)
      {
         throw new NotImplementedException();
      }
      
      public void InitializeId()
      {
         throw new NotImplementedException();
      }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetByID(ID id)
        {
            throw new NotImplementedException();
        }

        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(ISpecification<T> criteria)
        {
            throw new NotImplementedException();
        }

        public Repository.CSVRepository.Csv.Stream.ICSVStream<T> iCSVStream;
      public Repository.Sequencer.ISequencer<T> iSequencer;
   
   }
}