// File:    IngredientRepository.cs
// Author:  nikola
// Created: 24. maj 2020 12:24:56
// Purpose: Definition of Class IngredientRepository

using Model.Patient;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.MedicalRepository
{
    public class IngredientRepository : CSVRepository<Ingredient, long>, Abstract.Medical.IIngredientRepository, IEagerCSVRepository<Ingredient, long>
    {
        public IEnumerable<Ingredient> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Ingredient GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}