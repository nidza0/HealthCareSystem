// File:    AppointmentService.cs
// Author:  Geri
// Created: 19. maj 2020 20:26:06
// Purpose: Definition of Class AppointmentService

using System;
using System.Collections.Generic;
using System.Linq;
using SIMS.Exceptions;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.MedicalRepository;
using SIMS.Util;

namespace SIMS.Service.MedicalService
{
    public class AppointmentService : IService<Appointment, long>
    {
        private IAppointmentStrategy _appointmentStrategy;
        private AppointmentRepository _appointmentRepository;
        private DateTime dayBeforeAutoDelete;

        public AppointmentService(AppointmentRepository appointmentRepository,IAppointmentStrategy appointmentStrategy)
        {
            _appointmentRepository = appointmentRepository;
            _appointmentStrategy = appointmentStrategy;

        }

        protected void CheckSchedules(Appointment appointment)
        {
            if (!CheckDoctorSchedule(appointment))
                throw new AppointmentServiceException("Appointment clashes with doctor appointments!");

            if (!CheckPatientSchedule(appointment))
                throw new AppointmentServiceException("Appointment clashes with patient appointments!");

            if (!CheckRoomSchedules(appointment))
                throw new AppointmentServiceException("Appointment clashes with room appointments!");
        }

        protected bool CheckDoctorSchedule(Appointment appointment)
        {
            IEnumerable<Appointment> overlapping = _appointmentRepository.GetAppointmentsByDoctor(appointment.DoctorInAppointment)
                .Where(app => app.TimeInterval.IsOverlappingWith(appointment.TimeInterval));

            if (overlapping.Count() > 0)
            {
                return false;
            }

            return true;
        }

        protected bool CheckPatientSchedule(Appointment appointment)
        {
            IEnumerable<Appointment> overlapping = _appointmentRepository.GetPatientAppointments(appointment.Patient)
                .Where(app => app.TimeInterval.IsOverlappingWith(appointment.TimeInterval));

            if(overlapping.Count() > 0)
            {
                return false;
            }

            return true;
        }

        protected bool CheckRoomSchedules(Appointment appointment)
        {
            // Checks if the selected room is available
            IEnumerable<Appointment> appointments = _appointmentRepository.GetAppointmentsByRoom(appointment.Room)
                .Where(app => app.TimeInterval.IsOverlappingWith(appointment.TimeInterval));
            if(appointments.Count() > 0)
            {
                return false;
            }

            return true;
        }

        protected void CheckType(Appointment appointment)
            => _appointmentStrategy.CheckType(appointment);

        public Appointment CancelAppointment(Appointment appointment)
        {
            // TODO: Proveri da li moze da se otkaze appointment
            Validate(appointment);
            appointment.Canceled = true;
            _appointmentRepository.Update(appointment);
            
            return appointment;
        }

        public IEnumerable<Appointment> GetPatientAppointments(Patient patient)
            => _appointmentRepository.GetPatientAppointments(patient);

        public IEnumerable<Appointment> GetAppointmentsByTime(TimeInterval timeInterval)
            => _appointmentRepository.GetAppointmentsByTime(timeInterval);

        public IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor)
            => _appointmentRepository.GetAppointmentsByDoctor(doctor);

        public IEnumerable<Appointment> GetCanceledAppointments()
            => _appointmentRepository.GetAllEager().Where(app => app.Canceled == true);

        public IEnumerable<Appointment> GetCompletedAppointmentsByPatient(Patient patient)
            => _appointmentRepository.GetAllEager().Where(app => app.Canceled == false && app.TimeInterval.EndTime.CompareTo(DateTime.Now) < 0);

        public IEnumerable<Appointment> GetAppointmentsByRoom(Room room)
            => _appointmentRepository.GetAppointmentsByRoom(room);

        public IEnumerable<Appointment> GetFilteredAppointment(AppointmentFilter appointmentFilter)
            => _appointmentRepository.GetFilteredAppointment(appointmentFilter);

        public IEnumerable<Appointment> GetUpcomingAppointmentsForPatient(Patient patient)
            => _appointmentRepository.GetUpcomingAppointmentsForPatient(patient);

        public IEnumerable<Doctor> GetRecentDoctorsForPatient(Patient patient)
            => _appointmentRepository.GetPatientAppointments(patient).Select(app => app.DoctorInAppointment);

        public IEnumerable<Appointment> GetUpcomingAppointmentsForDoctor(Doctor doctor)
            => _appointmentRepository.GetUpcomingAppointmentsForDoctor(doctor);

        public bool IsAppointmentChangeable(Appointment appointment)
            => _appointmentStrategy.isAppointmentChangeable(appointment);

        public void AutoDeleteCanceledAppointments()
        {
            //Method that goes through all appointments that are far in the past to free the memory.
            IEnumerable<Appointment> allAppointments = GetAll();

            foreach(Appointment appointment in allAppointments)
            {
                if (appointment.TimeInterval.StartTime < dayBeforeAutoDelete)
                    _appointmentRepository.Delete(appointment);
            }
        }

        public IEnumerable<Appointment> GetAll()
            => _appointmentRepository.GetAllEager();

        public Appointment GetByID(long id)
            => _appointmentRepository.GetEager(id);

        public Appointment Create(Appointment entity)
        {
            Validate(entity);
            _appointmentRepository.Create(entity);
            return entity;
        }

        public void Delete(Appointment entity)
            => _appointmentRepository.Delete(entity);

        public void Update(Appointment entity)
        {
            Validate(entity);
            if (this.IsAppointmentChangeable(entity)) { 
                _appointmentRepository.Update(entity);
            }
        }

        public void Validate(Appointment entity)
            => _appointmentStrategy.Validate(entity);
    }
}