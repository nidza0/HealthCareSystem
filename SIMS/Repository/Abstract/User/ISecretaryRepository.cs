// File:    ISecretaryRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:08:58
// Purpose: Definition of Interface ISecretaryRepository

using System;

namespace Repository.Abstract.User
{
   public interface ISecretaryRepository : IRepository<Model.User.Secretary,Model.User.UserID>
   {
   }
}