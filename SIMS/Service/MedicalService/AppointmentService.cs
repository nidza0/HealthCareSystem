// File:    AppointmentService.cs
// Author:  Geri
// Created: 19. maj 2020 20:26:06
// Purpose: Definition of Class AppointmentService

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Util;

namespace SIMS.Service.MedicalService
{
    public class AppointmentService : IService<Appointment, long>
    {
        private DateTime daysBeforeAutoDelete;

        protected void validate(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        protected void checkDateTimeValid(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        protected void CheckSchedules(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        protected bool CheckDoctorSchedule(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        protected bool CheckPatientSchedule(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        protected bool CheckRoomSchedules(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        protected bool CheckType(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public Appointment CancelAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetPatientAppointments(Patient patient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAppointmentsByTime(Util.TimeInterval timeInterval)
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

        public IAppointmentStrategy iAppointmentStrategy;
        public IAppointmentRepository iAppointmentRepository;

    }
}