// File:    MedicalRecordConverter.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:58:28
// Purpose: Definition of Class MedicalRecordConverter

using System;
using System.Collections.Generic;
using System.Linq;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;

namespace SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter
{
    public class MedicalRecordConverter : ICSVConverter<MedicalRecord>
    {
        private readonly string _delimiter = ",";
        private readonly string _listDelimiter = ";";

        public MedicalRecordConverter(string delimiter)
        {
            _delimiter = delimiter;
        }

        public MedicalRecord ConvertCSVToEntity(string csv)
        {
            throw new NotImplementedException();
        }

        /*private long _id;
        private BloodType _patientBloodType;
        private Patient _patient;

        private List<Diagnosis> _patientDiagnosis;
        public List<Allergy> _allergy;

        public MedicalRecord(long id, Patient patient, BloodType bloodType, List<Diagnosis> patientDiagnosis, List<Allergy> patientAllergies)
        {
            _id = id;
            _patient = patient;
            _patientBloodType = bloodType;
            _patientDiagnosis = patientDiagnosis;
            _allergy = patientAllergies;
        }*/

        public string ConvertEntityToCSV(MedicalRecord medicalRecord)
            => string.Join(_delimiter,
                           medicalRecord.GetId(),
                           medicalRecord.Patient.GetId(),
                           medicalRecord.PatientBloodType,
                           GetDiagnosisCSVstring(medicalRecord.PatientDiagnosis),
                           GetPatientAllergyCSVstring(medicalRecord.Allergy));


        private string GetDiagnosisCSVstring(List<Diagnosis> diagnosis)
            => string.Join(_listDelimiter, diagnosis.Select(_patientDiagnosis => _patientDiagnosis.GetId()));

        private string GetPatientAllergyCSVstring(List<Allergy> allergies)
            => string.Join(_listDelimiter, allergies.Select(_allergy => _allergy.GetId()));
    }
}