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
                throw new IllegalAppointmentBooking("Time invalid!");
            else if (StartTime.CompareTo(EndTime) > 0)
                throw new IllegalAppointmentBooking("Time invalid!");

        }

        public void CheckType(Appointment appointment)
        {
            if (appointment.AppointmentType == AppointmentType.operation)
            {
                if (appointment.DoctorInAppointment.DocTypeEnum != Model.DoctorModel.DocTypeEnum.FAMILYMEDICINE)
                {
                    throw new IllegalAppointmentBooking("Family medicine doctor can not book operation!");
                }
            }
            else if (appointment.AppointmentType == AppointmentType.renovation)
            {
                if (appointment.DoctorInAppointment != null || appointment.Patient != null)
                {
                    throw new IllegalAppointmentBooking("Doctor and patient can not be in renovation appointment!");
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