// File:    AppointmentFilter.cs
// Author:  nikola
// Created: 21. maj 2020 12:39:03
// Purpose: Definition of Class AppointmentFilter

using SIMS.Model.DoctorModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using System;

namespace SIMS.Util
{
    public class AppointmentFilter
    {
        private DocTypeEnum doctorType;
        private Doctor doctor;
        private TimeInterval timeInterval;
        private AppointmentType type;
        private bool showUpcomingOnly;

    }
}