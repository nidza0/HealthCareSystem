// File:    AppointmentDoctorStrategy.cs
// Author:  nikola
// Created: 21. maj 2020 13:10:43
// Purpose: Definition of Class AppointmentDoctorStrategy

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Service.MedicalService
{
    public class AppointmentDoctorStrategy : IAppointmentStrategy
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