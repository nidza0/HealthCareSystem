// File:    PatientController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:50
// Purpose: Definition of Class PatientController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Model.PatientModel;
using SIMS.Service.UsersService;
using SIMS.Service.MedicalService;

namespace SIMS.Controller.UsersController
{
    public class PatientController : IController<Patient, UserID>
    {
        public IEnumerable<Patient> GetPatientByType(PatientType patientType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetPatientByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diagnosis> GetActiveDiagnosisForPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Diagnosis> GetInactiveDiagnosisForPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetFilteredTherapy(Util.TherapyFilter therapyFilter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Therapy> GetActiveTherapyForPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public Diagnosis AddDiagnosis(Patient patient, Diagnosis diagnosis)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Allergy> GetPatientAllergies(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Patient GetByID(UserID id)
        {
            throw new NotImplementedException();
        }

        public Patient Create(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Patient Update(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Patient entity)
        {
            throw new NotImplementedException();
        }

        public PatientService patientService;
        public MedicalRecordService medicalRecordService;
        public TherapyService therapyService;
        public DiagnosisService diagnosisService;

    }
}