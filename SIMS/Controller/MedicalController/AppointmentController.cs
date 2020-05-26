// File:    AppointmentController.cs
// Author:  nikola
// Created: 22. maj 2020 16:44:01
// Purpose: Definition of Class AppointmentController

using System;
using System.Collections.Generic;
using Model.Patient;
using Model.User;

namespace Controller.MedicalController
{
   public class AppointmentController : IController<Model.Patient.Appointment,long>
   {
      public Appointment CancelAppointment(Appointment appointment)
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
      
      public IEnumerable<Appointment> IsAppointmentChangeable(Appointment appointment)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<Doctor> GetAvailableDoctorsByTime(Util.TimeInterval timeInterval)
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

        public Service.MedicalService.AppointmentService appointmentService;
   
   }
}