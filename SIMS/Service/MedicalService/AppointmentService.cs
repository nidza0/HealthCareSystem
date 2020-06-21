// File:    AppointmentService.cs
// Author:  Geri
// Created: 19. maj 2020 20:26:06
// Purpose: Definition of Class AppointmentService

using System;
using System.Collections.Generic;
using System.Linq;
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

        protected void validate(Appointment appointment)
        {
          
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
            // TODO: Proveri da li moze da se otkaze appointment
            appointment.Canceled = true;
            _appointmentRepository.Update(appointment);
            return appointment;
        }

        public IEnumerable<Appointment> GetPatientAppointments(Patient patient)
            => _appointmentRepository.GetPatientAppointments(patient);

        public IEnumerable<Appointment> GetAppointmentsByTime(Util.TimeInterval timeInterval)
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
            => _appointmentRepository.Create(entity);


        public void Delete(Appointment entity)
            => _appointmentRepository.Delete(entity);

        public void Update(Appointment entity)
        {
            // TODO: Proveriti da li je update moguc
            _appointmentRepository.Update(entity);
        }
            



    }
}