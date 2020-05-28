// File:    SpecialistBookingLicence.cs
// Author:  Windows 10
// Created: 15. april 2020 21:47:38
// Purpose: Definition of Class SpecialistBookingLicence

using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract;
using SIMS.Util;
using System;
using System.Collections.Generic;

namespace SIMS.Model.PatientModel
{
    public class SpecialistBookingLicence : IIdentifiable<long>
    {
        private long _id;
        private DocTypeEnum _doctorAllowed;
        private int _numberOfAppointments;
        private bool _active;
        public Patient _patient;

        public TimeInterval _timeInterval;
        public List<Doctor> _handsOutLicence;

        //TODO: Constructors

        public long GetId()
        {
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }

    }
}