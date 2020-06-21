// File:    AppointmentManagerStrategy.cs
// Author:  nikola
// Created: 21. maj 2020 14:58:55
// Purpose: Definition of Class AppointmentManagerStrategy

using System;
using SIMS.Exceptions;
using SIMS.Model.PatientModel;

namespace SIMS.Service.MedicalService
{
    public class AppointmentManagerStrategy : IAppointmentStrategy
    {
        private readonly int bottomHourMargin = 24; //Represent hours after which you can't make an appointment
        private readonly int topDayMargin = 90; //Represents maximum upfront days when patient can make an appointment

        public void checkDateTimeValid(Appointment appointment)
        {
            DateTime StartTime = appointment.TimeInterval.StartTime;
            DateTime EndTime = appointment.TimeInterval.EndTime;

            if (StartTime.CompareTo(DateTime.Now.AddHours(bottomHourMargin)) < 0)
                throw new InvalidTimeException();
            else if (StartTime.CompareTo(EndTime) > 0)
                throw new InvalidTimeException();
            else if (StartTime.CompareTo(DateTime.Now.AddDays(topDayMargin)) > 0)
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
        => appointment.TimeInterval.StartTime.AddHours(-bottomHourMargin) > DateTime.Now;

        public void Validate(Appointment appointment)
        {
            checkDateTimeValid(appointment);
            CheckType(appointment);
        }
    }
}