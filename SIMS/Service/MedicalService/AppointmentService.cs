// File:    AppointmentService.cs
// Author:  Geri
// Created: 19. maj 2020 20:26:06
// Purpose: Definition of Class AppointmentService

using System;
using System.Collections.Generic;
using Model.Patient;

namespace Service.MedicalService
{
   public class AppointmentService : IService<Appointment, long>
   {
      private DateTime daysBeforeAutoDelete;
      
      protected void validate(Model.Patient.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      protected void checkDateTimeValid(Model.Patient.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      protected void CheckSchedules(Model.Patient.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      protected bool CheckDoctorSchedule(Model.Patient.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      protected bool CheckPatientSchedule(Model.Patient.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      protected bool CheckRoomSchedules(Model.Patient.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      protected bool CheckType(Model.Patient.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public Model.Patient.Appointment CancelAppointment(Model.Patient.Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Appointment> GetPatientAppointments(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Appointment> GetAppointmentsByTime(Util.TimeInterval timeInterval)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Appointment> GetAppointmentsByDoctor(Model.User.Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Appointment> GetCanceledAppointments()
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Appointment> GetCompletedAppointmentsByPatient(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Appointment> GetAppointmentsByRoom(Model.User.Room room)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Appointment> GetFilteredAppointment(Util.AppointmentFilter appointmentFilter)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Appointment> GetUpcomingAppointmentsForPatient(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Appointment> GetRecentDoctorsForPatient(Model.User.Patient patient)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Appointment> GetUpcomingAppointmentsForDoctor(Model.User.Doctor doctor)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Appointment> IsAppointmentChangeable(Model.Patient.Appointment appointment)
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
      public Repository.Abstract.Medical.IAppointmentRepository iAppointmentRepository;
   
   }
}