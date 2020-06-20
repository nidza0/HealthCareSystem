// File:    AppointmentSecretaryStrategy.cs
// Author:  nikola
// Created: 21. maj 2020 13:11:36
// Purpose: Definition of Class AppointmentSecretaryStrategy

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Service.MedicalService
{
    public class AppointmentSecretaryStrategy : IAppointmentStrategy
    {
        private readonly int minMinutes = 10;
        public void checkDateTimeValid(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public bool CheckType(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public bool isAppointmentChangeable(Appointment appointment)
            => appointment.TimeInterval.StartTime < DateTime.Now.AddMinutes(-minMinutes); 

        public int Validate(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}