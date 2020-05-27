// File:    SymptomRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:35
// Purpose: Definition of Class SymptomRepository

using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using System;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class SymptomRepository : CSVRepository<Symptom, long>, ISymptomRepository
    {
    }
}