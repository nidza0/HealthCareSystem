// File:    SymptomRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:35
// Purpose: Definition of Class SymptomRepository

using Repository.CSVRepository.Csv;
using System;

namespace Repository.CSVRepository.MedicalRepository
{
   public class SymptomRepository : CSVRepository<Model.Patient.Symptom,long>, Abstract.Medical.ISymptomRepository
   {
   }
}