/***********************************************************************
 * Module:  Patient.cs
 * Author:  nikola
 * Purpose: Definition of the Class Patient
 ***********************************************************************/

using Model.Patient;
using SIMS.Model.PatientModel;
using System;

namespace SIMS.Model.UserModel
{
    public class Patient : User
    {
        private string emergencyContactFirstName;
        private string emergencyContactLastname;
        private string emergencyContactEmailAddress;
        private string emergencyContactPhoneNumber;

        public PatientType patientType;
        public MedicalRecord medicalRecord;
        public System.Collections.ArrayList specialistBookingPermissions;

        /// <summary>
        /// Property for collection of SpecialistBookingLicence
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.ArrayList SpecialistBookingPermissions
        {
            get
            {
                if (specialistBookingPermissions == null)
                    specialistBookingPermissions = new System.Collections.ArrayList();
                return specialistBookingPermissions;
            }
            set
            {
                RemoveAllSpecialistBookingPermissions();
                if (value != null)
                {
                    foreach (SpecialistBookingLicence oSpecialistBookingLicence in value)
                        AddSpecialistBookingPermissions(oSpecialistBookingLicence);
                }
            }
        }

        /// <summary>
        /// Add a new SpecialistBookingLicence in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddSpecialistBookingPermissions(SpecialistBookingLicence newSpecialistBookingLicence)
        {
            if (newSpecialistBookingLicence == null)
                return;
            if (specialistBookingPermissions == null)
                specialistBookingPermissions = new System.Collections.ArrayList();
            if (!specialistBookingPermissions.Contains(newSpecialistBookingLicence))
            {
                specialistBookingPermissions.Add(newSpecialistBookingLicence);
                newSpecialistBookingLicence.Patient = this;
            }
        }

        /// <summary>
        /// Remove an existing SpecialistBookingLicence from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveSpecialistBookingPermissions(SpecialistBookingLicence oldSpecialistBookingLicence)
        {
            if (oldSpecialistBookingLicence == null)
                return;
            if (specialistBookingPermissions != null)
                if (specialistBookingPermissions.Contains(oldSpecialistBookingLicence))
                {
                    specialistBookingPermissions.Remove(oldSpecialistBookingLicence);
                    oldSpecialistBookingLicence.Patient = null;
                }
        }

        /// <summary>
        /// Remove all instances of SpecialistBookingLicence from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllSpecialistBookingPermissions()
        {
            if (specialistBookingPermissions != null)
            {
                System.Collections.ArrayList tmpSpecialistBookingPermissions = new System.Collections.ArrayList();
                foreach (SpecialistBookingLicence oldSpecialistBookingLicence in specialistBookingPermissions)
                    tmpSpecialistBookingPermissions.Add(oldSpecialistBookingLicence);
                specialistBookingPermissions.Clear();
                foreach (SpecialistBookingLicence oldSpecialistBookingLicence in tmpSpecialistBookingPermissions)
                    oldSpecialistBookingLicence.Patient = null;
                tmpSpecialistBookingPermissions.Clear();
            }
        }
        public Doctor selectedDoctor;

        /// <summary>
        /// Property for Model.User.Doctor
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Doctor SelectedDoctor
        {
            get
            {
                return selectedDoctor;
            }
            set
            {
                selectedDoctor = value;
            }
        }

    }
}