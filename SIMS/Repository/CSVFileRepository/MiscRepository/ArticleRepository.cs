// File:    ArticleRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:38:19
// Purpose: Definition of Class ArticleRepository

using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class ArticleRepository : CSVRepository<Article, long>, IArticleRepository, IEagerCSVRepository<Article, long>
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

        public DoctorRepository doctorRepository;
        public SecretaryRepository secretaryRepository;
        public ManagerRepository managerRepository;

    }
}