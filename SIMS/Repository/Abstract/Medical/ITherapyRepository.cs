// File:    ITherapyRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:05:08
// Purpose: Definition of Interface ITherapyRepository

using System;
using System.Collections.Generic;
using Model.Patient;

namespace Repository.Abstract.Medical
{
   public interface ITherapyRepository : IRepository<Model.Patient.Therapy,long>
   {
      Prescription AddPrescription(Model.Patient.Therapy therapy, Prescription perscription);
      
      IEnumerable<Therapy> GetTherapyByDate(Util.TimeInterval dateRange);
      
      IEnumerable<Therapy> GetTherapyByMedicine(Model.Patient.Medicine medicine);
      
      IEnumerable<Therapy> GetTherapyByPatient(Model.User.Patient patient);
      
      IEnumerable<Therapy> GetFilteredTherapy(Util.TherapyFilter filter);
      
      IEnumerable<Therapy> GetTherapyByDiagnosis(Model.Patient.Diagnosis diagnosis);
      
      IEnumerable<Therapy> GetActiveTherapyForPatient(Model.User.Patient patient);
      
      IEnumerable<Therapy> GetPastTherapyForPatient(Model.User.Patient patient);
      
      IEnumerable<Therapy> GetActiveTherapyForDiagnosis(Model.Patient.Diagnosis diagnosis);
      
      IEnumerable<Therapy> GetPastTherapiesForDiagnosis(Model.Patient.Diagnosis diagnosis);
   
   }
}