// File:    ISymptomRepository.cs
// Author:  Geri
// Created: 23. maj 2020 19:56:20
// Purpose: Definition of Interface ISymptomRepository

using System;

namespace Repository.Abstract.Medical
{
   public interface ISymptomRepository : IRepository<Model.Patient.Symptom,long>
   {
   }
}