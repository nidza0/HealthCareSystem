// File:    ArticleService.cs
// Author:  Geri
// Created: 7. maj 2020 12:01:08
// Purpose: Definition of Class ArticleService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;

namespace SIMS.Service.MiscService
{
    public class ArticleService : IService<Article, long>
    {
        protected void CheckEditingPermission(Article article, Employee employee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetArticleByAuthor(Employee author)
        {
            throw new NotImplementedException();
        }

        public void ValidateArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public Article GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Article Create(Article entity)
        {
            throw new NotImplementedException();
        }

        public Article Update(Article entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Article entity)
        {
            throw new NotImplementedException();
        }

        void IService<Article, long>.Update(Article entity)
        {
            throw new NotImplementedException();
        }

        public IArticleRepository iArticleRepository;

    }
}