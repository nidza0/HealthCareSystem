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

        public AppointmentService appointmentService;

        public AppointmentController(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }

        public Appointment CancelAppointment(Appointment appointment)
            => appointmentService.CancelAppointment(appointment);

        public IEnumerable<Appointment> GetPatientAppointments(Patient patient)
            => appointmentService.GetPatientAppointments(patient);

        public IEnumerable<Appointment> GetAppointmentsByTime(TimeInterval timeInterval)
            => appointmentService.GetAppointmentsByTime(timeInterval);

        public IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor)
            => appointmentService.GetAppointmentsByDoctor(doctor);

        public IEnumerable<Appointment> GetCanceledAppointments()
            => appointmentService.GetCanceledAppointments();

        public IEnumerable<Appointment> GetCompletedAppointmentsByPatient(Patient patient)
            => appointmentService.GetCompletedAppointmentsByPatient(patient);

        public IEnumerable<Appointment> GetAppointmentsByRoom(Room room)
            => appointmentService.GetAppointmentsByRoom(room);

        public IEnumerable<Appointment> GetFilteredAppointment(AppointmentFilter appointmentFilter)
            => appointmentService.GetFilteredAppointment(appointmentFilter);

        public IEnumerable<Appointment> GetUpcomingAppointmentsForPatient(Patient patient)
            => appointmentService.GetUpcomingAppointmentsForPatient(patient);

        public IEnumerable<Doctor> GetRecentDoctorsForPatient(Patient patient)
            => appointmentService.GetRecentDoctorsForPatient(patient);

        public IEnumerable<Appointment> GetUpcomingAppointmentsForDoctor(Doctor doctor)
            => appointmentService.GetUpcomingAppointmentsForDoctor(doctor);

        public bool IsAppointmentChangeable(Appointment appointment)
            => appointmentService.IsAppointmentChangeable(appointment);

        public IEnumerable<Doctor> GetAvailableDoctorsByTime(TimeInterval timeInterval)
        {
            throw new NotImplementedException();
        }

        public void AutoDeleteCanceledAppointments()
            => appointmentService.AutoDeleteCanceledAppointments();

        public IEnumerable<Appointment> GetAll()
            => appointmentService.GetAll();

        public Appointment GetByID(long id)
            => appointmentService.GetByID(id);

        public Appointment Create(Appointment entity)
            => appointmentService.Create(entity);

        public void Update(Appointment entity)
            => appointmentService.Update(entity);

        public void Delete(Appointment entity)
            => appointmentService.Delete(entity);

    }
}