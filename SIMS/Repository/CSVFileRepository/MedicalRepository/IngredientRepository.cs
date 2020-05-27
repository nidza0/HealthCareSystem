// File:    IngredientRepository.cs
// Author:  nikola
// Created: 24. maj 2020 12:24:56
// Purpose: Definition of Class IngredientRepository

using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class IngredientRepository : CSVRepository<Ingredient, long>, IIngredientRepository, IEagerCSVRepository<Ingredient, long>
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