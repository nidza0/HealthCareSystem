// File:    ArticleController.cs
// Author:  nikola
// Created: 22. maj 2020 17:30:10
// Purpose: Definition of Class ArticleController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.MiscService;

namespace SIMS.Controller.MiscController
{
    public class ArticleController : IController<Article, long>
    {
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

        public void Update(Article entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Article entity)
        {
            throw new NotImplementedException();
        }

        public ArticleService articleService;

    }
}