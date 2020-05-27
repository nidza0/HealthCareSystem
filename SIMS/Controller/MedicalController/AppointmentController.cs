// File:    AppointmentController.cs
// Author:  nikola
// Created: 22. maj 2020 16:44:01
// Purpose: Definition of Class AppointmentController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Service.MedicalService;
using SIMS.Util;

namespace SIMS.Controller.MedicalController
{
    public class AppointmentController : IController<Appointment, long>
    {
        public Appointment CancelAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetPatientAppointments(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAppointmentsByTime(TimeInterval timeInterval)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetCanceledAppointments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetCompletedAppointmentsByPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAppointmentsByRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetFilteredAppointment(AppointmentFilter appointmentFilter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetUpcomingAppointmentsForPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetRecentDoctorsForPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetUpcomingAppointmentsForDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> IsAppointmentChangeable(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAvailableDoctorsByTime(TimeInterval timeInterval)
        {
            throw new NotImplementedException();
        }

        public void AutoDeleteCanceledAppointments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Appointment GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Appointment Create(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public Appointment Update(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Appointment entity)
        {
            throw new NotImplementedException();
        }

        public AppointmentService appointmentService;

    }
}