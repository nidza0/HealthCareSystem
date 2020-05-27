/***********************************************************************
 * Module:  Patient.cs
 * Author:  nikola
 * Purpose: Definition of the Class Patient
 ***********************************************************************/

using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;

namespace SIMS.Model.UserModel
{
    public class Patient : User
    {
        private PatientType _patientType;
        //public MedicalRecord medicalRecord;
        private List<SpecialistBookingLicence> _specialistBookingPermissions;
        private EmergencyContact _emergencyContact;

        private Doctor _selectedDoctor;

        public Patient(UserID id) : base(id) { }

        public Patient(string userName, string password, DateTime dateCreated, string name, string surname, string middleName, Sex sex, DateTime dateOfBirth, string uidn, Address address, string homePhone, string cellPhone, string email1, string email2, EmergencyContact emergencyContact, PatientType patientType, Doctor selectedDoctor, List<SpecialistBookingLicence> bookingLicences) : base(userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _patientType = patientType;
            _specialistBookingPermissions = bookingLicences;
            _selectedDoctor = selectedDoctor;
            _emergencyContact = emergencyContact;
        }

        public PatientType PatientType { get => _patientType; }
        public List<SpecialistBookingLicence> SpecialistBookingPermissions { get => _specialistBookingPermissions; }
        public EmergencyContact EmergencyContact { get => _emergencyContact; }
    }
}