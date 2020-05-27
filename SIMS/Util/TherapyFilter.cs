// File:    TherapyFilter.cs
// Author:  nikola
// Created: 21. maj 2020 15:56:47
// Purpose: Definition of Class TherapyFilter

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;

namespace SIMS.Util
{
    public class TherapyFilter
    {
        private string drugName;
        private Doctor doctor;
        private TimeInterval timeInterval;
        private IEnumerable<TherapyTime> time;

    }
}