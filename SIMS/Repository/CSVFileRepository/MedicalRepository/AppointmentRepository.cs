// File:    AppointmentRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:34
// Purpose: Definition of Class AppointmentRepository

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Specifications.Converter;
using SIMS.Util;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class AppointmentRepository : CSVRepository<Appointment, long>, IAppointmentRepository, IEagerCSVRepository<Appointment, long>
    {
        private void Bind(IEnumerable<Appointment> appointments, IEnumerable<Room> rooms, IEnumerable<Doctor> doctors, IEnumerable<Patient> patients)
        {
            throw new NotImplementedException();
        }

        private void BindAppointmentsWithDoctor(IEnumerable<Appointment> appointments, IEnumerable<Doctor> doctors)
        {
            throw new NotImplementedException();
        }

        private void BindAppointmentsWithPatient(IEnumerable<Appointment> appointments, IEnumerable<Patient> patient)
        {
            throw new NotImplementedException();
        }

        private void BindAppointmentsWithRoom(IEnumerable<Appointment> appointments, IEnumerable<Room> rooms)
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

        public IEnumerable<Appointment> GetUpcomingAppointmentsForDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void AutoDeleteCanceledAppointments()
        {
            throw new NotImplementedException();
        }

        public Appointment GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Appointment> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public AppointmentSpecificationConverter appointmentSpecificationConverter;
        public RoomRepository roomRepository;
        public DoctorRepository doctorRepository;
        public PatientRepository patientRepository;

    }
}