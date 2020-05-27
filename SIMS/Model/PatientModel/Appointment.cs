// File:    Appointment.cs
// Author:  Windows 10
// Created: 15. april 2020 21:19:22
// Purpose: Definition of Class Appointment

using SIMS.Model.UserModel;
using System;

namespace SIMS.Model.PatientModel
{
    public class Appointment
    {
        private long id;
        private bool canceled = false;

        public AppointmentType appointmentType;
        public Util.TimeInterval timeInterval;
        public Patient patient;

        /// <summary>
        /// Property for Model.User.Patient
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                patient = value;
            }
        }
        public Room room;

        /// <summary>
        /// Property for Model.User.Room
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Room Room
        {
            get
            {
                return room;
            }
            set
            {
                room = value;
            }
        }
        public Doctor doctorInAppointment;

    }
}