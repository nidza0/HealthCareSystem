// File:    Therapy.cs
// Author:  Windows 10
// Created: 15. april 2020 22:03:13
// Purpose: Definition of Class Therapy

using Model.Patient;
using SIMS.Repository.Abstract;
using SIMS.Util;
using System;
using System.Collections.Generic;

namespace SIMS.Model.PatientModel
{
    public class Therapy : IIdentifiable<long>
    {
        private long _id;
        private TimeInterval _timeInterval;
        private Prescription _prescription;

        public Therapy(long id)
        {
            _id = id;
        }

        public Therapy(long id, TimeInterval timeInterval, Prescription prescription)
        {
            _id = id;
            _timeInterval = timeInterval;
            _prescription = prescription;
        }

        public Therapy(TimeInterval timeInterval, Prescription prescription)
        {
            _timeInterval = timeInterval;
            _prescription = prescription;
        }

        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;

        public TimeInterval TimeInterval { get => _timeInterval; }
        public Prescription Prescription { get => _prescription; }
    }
}