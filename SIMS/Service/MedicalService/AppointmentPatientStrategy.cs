// File:    AppointmentPatientStrategy.cs
// Author:  nikola
// Created: 21. maj 2020 13:10:55
// Purpose: Definition of Class AppointmentPatientStrategy

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Service.MedicalService
{
    public class AppointmentPatientStrategy : IAppointmentStrategy
    {
        private DateTime bottomHourMargin;
        private DateTime topDayMargin;

        public void checkDateTimeValid(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public bool CheckType(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public int Validate(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}