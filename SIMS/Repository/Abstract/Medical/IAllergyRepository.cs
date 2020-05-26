// File:    IAllergyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 12:42:12
// Purpose: Definition of Interface IAllergyRepository

using System;

namespace Repository.Abstract.Medical
{
   public interface IAllergyRepository : IRepository<Model.Patient.Allergy,long>
   {
   }
}