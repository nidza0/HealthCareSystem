// File:    IManagerRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:08:58
// Purpose: Definition of Interface IManagerRepository

using System;

namespace Repository.Abstract.User
{
   public interface IManagerRepository : IRepository<Model.User.Manager,Model.User.UserID>
   {
   }
}