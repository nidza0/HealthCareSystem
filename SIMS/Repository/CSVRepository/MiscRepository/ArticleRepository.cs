// File:    ArticleRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:38:19
// Purpose: Definition of Class ArticleRepository

using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.MiscRepository
{
   public class ArticleRepository : CSVRepository<Article, long>, Abstract.Misc.IArticleRepository, IEagerCSVRepository<Article, long>
   {
      public void BindArticlesWithAuthors(IEnumerable<Article> articles)
      {
         throw new NotImplementedException();
      }
      
      public void BindArticlesWithDoctor(IEnumerable<Article> articles)
      {
         throw new NotImplementedException();
      }
      
      public void BindArticlesWithSecretary(IEnumerable<Article> articles)
      {
         throw new NotImplementedException();
      }
      
      public void BindArticlesWithManager(IEnumerable<Article> articles)
      {
         throw new NotImplementedException();
      }

        public IEnumerable<Article> GetArticleByAuthor(Employee author)
        {
            throw new NotImplementedException();
        }

        public Article GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Repository.CSVRepository.UserRepository.DoctorRepository doctorRepository;
      public Repository.CSVRepository.UserRepository.SecretaryRepository secretaryRepository;
      public Repository.CSVRepository.UserRepository.ManagerRepository managerRepository;
   
   }
}