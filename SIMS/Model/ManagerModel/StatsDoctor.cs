// File:    StatsDoctor.cs
// Author:  vule
// Created: 18. april 2020 17:12:34
// Purpose: Definition of Class StatsDoctor

using System;

namespace SIMS.Model.ManagerModel
{
    public class StatsDoctor : Stats
    {
        private double numberOfAppointments;
        private string avgAppointmentTime;

        public UserModel.Doctor doctor;

    }
}