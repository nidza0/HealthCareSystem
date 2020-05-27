// File:    AllergyRepository.cs
// Author:  nikola
// Created: 24. maj 2020 13:02:09
// Purpose: Definition of Class AllergyRepository

using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using System;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class AllergyRepository : CSVRepository<Allergy, long>, IAllergyRepository
    {
    }
}