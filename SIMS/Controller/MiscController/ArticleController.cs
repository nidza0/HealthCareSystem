// File:    ArticleController.cs
// Author:  nikola
// Created: 22. maj 2020 17:30:10
// Purpose: Definition of Class ArticleController

using System;
using System.Collections.Generic;
using Model.User;

namespace Controller.MiscController
{
   public class ArticleController : IController<Model.User.Article,long>
   {
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

        public Service.MiscService.ArticleService articleService;
   
   }
}