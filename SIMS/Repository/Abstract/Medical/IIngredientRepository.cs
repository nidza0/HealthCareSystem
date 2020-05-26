// File:    IIngredientRepository.cs
// Author:  nikola
// Created: 24. maj 2020 12:23:32
// Purpose: Definition of Interface IIngredientRepository

using System;

namespace Repository.Abstract.Medical
{
   public interface IIngredientRepository : IRepository<Model.Patient.Ingredient,long>
   {
   }
}