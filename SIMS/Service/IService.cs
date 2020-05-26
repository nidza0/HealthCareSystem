// File:    IService.cs
// Author:  Geri
// Created: 20. maj 2020 12:19:22
// Purpose: Definition of Interface IService

using System;
using System.Collections.Generic;

namespace Service
{
   public interface IService<T,ID>
   {
      IEnumerable<T> GetAll();
      
      T GetByID(ID id);
      
      T Create(T entity);
      
      T Update(T entity);
      
      void Delete(T entity);
   
   }
}