// File:    IArticleRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:06:57
// Purpose: Definition of Interface IArticleRepository

using System;
using System.Collections.Generic;
using Model.User;

namespace Repository.Abstract.Misc
{
   public interface IArticleRepository : IRepository<Model.User.Article,long>
   {
      IEnumerable<Article> GetArticleByAuthor(Model.User.Employee author);
   
   }
}