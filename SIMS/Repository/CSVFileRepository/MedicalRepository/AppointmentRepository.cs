// File:    AppointmentRepository.cs
// Author:  Geri
// Created: 23. maj 2020 18:19:34
// Purpose: Definition of Class AppointmentRepository

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Repository.Sequencer;
using SIMS.Specifications;
using SIMS.Specifications.Converter;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class AppointmentRepository : CSVRepository<Appointment, long>, IAppointmentRepository, IEagerCSVRepository<Appointment, long>
    {
        private IPatientRepository _patientRepository;
        private IDoctorRepository _doctorRepository;
        private IRoomRepository _roomRepository;

        public AppointmentRepository(string entityName, ICSVStream<Appointment> stream, ISequencer<long> sequencer, IPatientRepository patientRepository, IDoctorRepository doctorRepository, IRoomRepository roomRepository) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Appointment>())
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _roomRepository = roomRepository;
        }

        private void Bind(IEnumerable<Appointment> appointments)
        {
            var patients = _patientRepository.GetAll();
            BindAppointmentsWithPatient(appointments, patients);

            var doctors = _doctorRepository.GetAll();
            BindAppointmentsWithDoctor(appointments, doctors);

            var rooms = _roomRepository.GetAll();
            BindAppointmentsWithRoom(appointments, rooms);
        }

        private void BindAppointmentsWithDoctor(IEnumerable<Appointment> appointments, IEnumerable<Doctor> doctors)
            => appointments.ToList().ForEach(appointment => appointment.DoctorInAppointment = GetDoctorById(doctors,appointment.DoctorInAppointment.GetId()));

        private void BindAppointmentsWithPatient(IEnumerable<Appointment> appointments, IEnumerable<Patient> patients)
            => appointments.ToList().ForEach(appointment => appointment.Patient = GetPationtById(patients, appointment.Patient.GetId()));

        private void BindAppointmentsWithRoom(IEnumerable<Appointment> appointments, IEnumerable<Room> rooms)
            => appointments.ToList().ForEach(appointment => appointment.Room = GetRoomById(rooms, appointment.Patient.GetId()));

        public IEnumerable<Appointment> GetPatientAppointments(Patient patient)
            => GetAll().Where(appointment => appointment.Patient.GetId().Equals(patient.GetId()));

        public IEnumerable<Appointment> GetAppointmentsByTime(TimeInterval timeInterval)
            => GetAll().Where(appointment => appointment.TimeInterval.Equals(timeInterval));

        public IEnumerable<Appointment> GetAppointmentsByDoctor(Doctor doctor)
            => GetAll().Where(appointment => appointment.GetId().Equals(doctor.GetId()));

        public IEnumerable<Appointment> GetCanceledAppointments()
            => GetAll().Where(appointment => appointment.Canceled == true);

        public IEnumerable<Appointment> GetCompletedAppointmentsByPatient(Patient patient)
            => GetAll().Where(appointment => appointment.Patient.GetId().Equals(patient.GetId())&& isCompleted(appointment));

        public IEnumerable<Appointment> GetAppointmentsByRoom(Room room)
            => GetAll().Where(appointment => appointment.Room.GetId().Equals(room.GetId()));

        public IEnumerable<Appointment> GetFilteredAppointment(AppointmentFilter appointmentFilter)
        {
            ISpecification<Appointment> specification = new AppointmentSpecificationConverter(appointmentFilter).GetSpecification();
            var appointments = Find(specification);
            Bind(appointments);
            return appointments;            
        }

        public IEnumerable<Appointment> GetUpcomingAppointmentsForPatient(Patient patient)
            => GetAll().Where(appointment => appointment.Patient.GetId().Equals(patient.GetId()) && isInFuture(appointment) );

        public IEnumerable<Appointment> GetUpcomingAppointmentsForDoctor(Doctor doctor)
            => GetAll().Where(appointment => appointment.DoctorInAppointment.GetId().Equals(doctor.GetId()));

        public Appointment GetEager(long id)
        {
            var appointment = GetByID(id);

            var patients = _patientRepository.GetAll();
            appointment.Patient = patients.SingleOrDefault(patient => patient.GetId() == appointment.Patient.GetId());

            var doctors = _doctorRepository.GetAll();
            appointment.DoctorInAppointment = doctors.SingleOrDefault(doctor => doctor.GetId() == appointment.DoctorInAppointment.GetId());

            var rooms = _roomRepository.GetAll();
            appointment.Room = rooms.SingleOrDefault(room => room.GetId() == appointment.Room.GetId());

            return appointment;
        }

        public IEnumerable<Appointment> GetAllEager()
        {
            IEnumerable<Appointment> appointments = GetAll();

            IEnumerable<Patient> patients = _patientRepository.GetAll();
            IEnumerable<Room> rooms = _roomRepository.GetAll();
            IEnumerable<Doctor> doctors = _doctorRepository.GetAll();

            Bind(appointments);

            return appointments;
        }

        private Doctor GetDoctorById(IEnumerable<Doctor> doctors, UserID id)
            => doctors.ToList().SingleOrDefault(doctor => doctor.GetId().Equals(id));

        private Patient GetPationtById(IEnumerable<Patient> patients, UserID id)
            => patients.ToList().SingleOrDefault(patient => patient.GetId().Equals(id));

        private Room GetRoomById(IEnumerable<Room> rooms, UserID id)
            => rooms.ToList().SingleOrDefault(room => room.GetId().Equals(id));

        private bool isCompleted(Appointment appointment)
            => appointment.TimeInterval.EndTime.CompareTo(DateTime.Now) < 0 && !appointment.Canceled;

        private bool isInFuture(Appointment appointment)
            => appointment.TimeInterval.StartTime.CompareTo(DateTime.Now) > 0 && !appointment.Canceled;

        public AppointmentSpecificationConverter appointmentSpecificationConverter;
        public RoomRepository roomRepository;
        public DoctorRepository doctorRepository;
        public PatientRepository patientRepository;

    }
}