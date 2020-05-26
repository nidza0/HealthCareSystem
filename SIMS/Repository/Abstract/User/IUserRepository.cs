// File:    IUserRepository.cs
// Author:  vule
// Created: 26. maj 2020 17:27:21
// Purpose: Definition of Interface IUserRepository

using System;

namespace Repository.Abstract.User
{
   public interface IUserRepository : IRepository<Model.User.User,Model.User.UserID>
   {
      Model.User.User GetByUsername(string username);
   
   }
}