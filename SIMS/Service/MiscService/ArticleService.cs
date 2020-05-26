// File:    ArticleService.cs
// Author:  Geri
// Created: 7. maj 2020 12:01:08
// Purpose: Definition of Class ArticleService

using System;
using System.Collections.Generic;
using Model.User;

namespace Service.MiscService
{
   public class ArticleService : IService<Model.User.Article,long>
   {
      protected void CheckEditingPermission(Model.User.Article article, Model.User.Employee employee)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Article> GetArticleByAuthor(Model.User.Employee author)
      {
         throw new NotImplementedException();
      }
      
      public void ValidateArticle(Model.User.Article article)
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

        public Repository.Abstract.Misc.IArticleRepository iArticleRepository;
   
   }
}