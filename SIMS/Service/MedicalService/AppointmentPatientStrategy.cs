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
        private readonly int bottomHourMargin = 24; //Represent hours after which you can't make an appointment
        private readonly int topDayMargin = 90; //Represents maximum upfront days when patient can make an appointment

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
            DateTime startTime = appointment.TimeInterval.StartTime;

            return startTime.AddHours(-bottomHourMargin) > DateTime.Now && startTime > DateTime.Now.AddDays(90);
        }

        public int Validate(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}