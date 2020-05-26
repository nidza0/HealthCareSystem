// File:    IDiagnosisRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:03:26
// Purpose: Definition of Interface IDiagnosisRepository

using System;
using System.Collections.Generic;
using Model.Patient;

namespace Repository.Abstract.Medical
{
   public interface IDiagnosisRepository : IRepository<Model.Patient.Diagnosis,long>
   {
      IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Model.User.Patient patient);
      
      IEnumerable<Diagnosis> GetDiagnosisByMedicine(Model.Patient.Medicine medicine);
      
      IEnumerable<Diagnosis> GetActiveDiagnosisForPatient();
      
      IEnumerable<Diagnosis> GetInactiveDiagnosisForPatient(Model.User.Patient patient);
   
   }
}