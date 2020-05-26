// File:    AllergyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 13:02:09
// Purpose: Definition of Class AllergyRepository

using Repository.CSVRepository.Csv;
using System;

namespace Repository.CSVRepository.MedicalRepository
{
   public class AllergyRepository : CSVRepository<Model.Patient.Allergy,long>, Abstract.Medical.IAllergyRepository
   {
   }
}