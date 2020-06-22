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
        public PatientService patientService;
        public MedicalRecordService medicalRecordService;
        public TherapyService therapyService;
        public DiagnosisService diagnosisService;

        public PatientController(PatientService patientService, MedicalRecordService medicalRecordService, TherapyService therapyService, DiagnosisService diagnosisService)
        {
            this.patientService = patientService;
            this.medicalRecordService = medicalRecordService;
            this.therapyService = therapyService;
            this.diagnosisService = diagnosisService;
        }

        public MedicalRecord GetMedicalRecordByPatient(Patient patient)
            => medicalRecordService.GetPatientMedicalRecord(patient);

        public IEnumerable<Patient> GetPatientByType(PatientType patientType)
            => patientService.GetPatientByType(patientType);

        public IEnumerable<Patient> GetPatientByDoctor(Doctor doctor) 
            => patientService.GetPatientByDoctor(doctor);

        public IEnumerable<Diagnosis> GetAllDiagnosisForPatient(Patient patient)
            => diagnosisService.GetAllDiagnosisForPatient(patient);


        public IEnumerable<Therapy> GetFilteredTherapy(Util.TherapyFilter therapyFilter)
            => therapyService.GetFilteredTherapy(therapyFilter);

        public IEnumerable<Therapy> GetActiveTherapyForPatient(Patient patient)
            => therapyService.GetActiveTherapyForPatient(patient);

        public Diagnosis AddDiagnosis(Patient patient, Diagnosis diagnosis)
            => medicalRecordService.AddDiagnosis(patient, diagnosis);

        public IEnumerable<Allergy> GetPatientAllergies(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Patient> GetAll()
            => patientService.GetAll();

        public Patient GetByID(UserID id)
            => patientService.GetByID(id);

        public Patient Create(Patient entity)
            => patientService.Create(entity);

        public void Update(Patient entity)
            => patientService.Update(entity);

        public void Delete(Patient entity)
            => patientService.Delete(entity);
    }
}