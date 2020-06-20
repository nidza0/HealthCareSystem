// File:    AppointmentManagerStrategy.cs
// Author:  nikola
// Created: 21. maj 2020 14:58:55
// Purpose: Definition of Class AppointmentManagerStrategy

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Service.MedicalService
{
    public class AppointmentManagerStrategy : IAppointmentStrategy
    {
        public void checkDateTimeValid(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public bool CheckType(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public bool isAppointmentChangeable(Appointment appointment)
        {
            return false;
        }

        public int Validate(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}