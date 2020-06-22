// File:    AppointmentSecretaryStrategy.cs
// Author:  nikola
// Created: 21. maj 2020 13:11:36
// Purpose: Definition of Class AppointmentSecretaryStrategy

using System;
using SIMS.Exceptions;
using SIMS.Model.PatientModel;

namespace SIMS.Service.MedicalService
{
    public class AppointmentSecretaryStrategy : IAppointmentStrategy
    {
        private readonly int minMinutes = 10;
        public void checkDateTimeValid(Appointment appointment)
        {
            DateTime StartTime = appointment.TimeInterval.StartTime;
            DateTime EndTime = appointment.TimeInterval.EndTime;

            if (StartTime.CompareTo(DateTime.Now.AddMinutes(minMinutes)) < 0)
                throw new InvalidTimeException();
            else if (StartTime.CompareTo(EndTime) > 0)
                throw new InvalidTimeException();

        }

        public void CheckType(Appointment appointment)
        {
            if (appointment.AppointmentType == AppointmentType.operation)
            {
                if (appointment.DoctorInAppointment.DocTypeEnum != Model.DoctorModel.DocTypeEnum.FAMILYMEDICINE)
                {
                    throw new IllegalAppointmentBooking();
                }
            }
            else if (appointment.AppointmentType == AppointmentType.renovation)
            {
                if (appointment.DoctorInAppointment != null || appointment.Patient != null)
                {
                    throw new IllegalAppointmentBooking();
                }
            }
        }

        public bool isAppointmentChangeable(Appointment appointment)
            => appointment.TimeInterval.StartTime < DateTime.Now.AddMinutes(-minMinutes); 

        public void Validate(Appointment appointment)
        {
            checkDateTimeValid(appointment);
            CheckType(appointment);
        }
    }
}