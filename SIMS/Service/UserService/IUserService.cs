// File:    IUserService.cs
// Author:  Geri
// Created: 22. maj 2020 11:50:44
// Purpose: Definition of Interface IUserService

using System;

namespace Service.UserService
{
   public interface IUserService<T>
   {
      void Validate(T user);
      
      void Login(Model.User.User user);
   
   }
}