// File:    AppointmentSecretaryStrategy.cs
// Author:  nikola
// Created: 21. maj 2020 13:11:36
// Purpose: Definition of Class AppointmentSecretaryStrategy

using System;
using Model.Patient;

namespace Service.MedicalService
{
    public class AppointmentSecretaryStrategy : IAppointmentStrategy
    {
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