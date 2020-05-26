// File:    IAppointmentRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 14:02:02
// Purpose: Definition of Interface IAppointmentRepository

using System;
using System.Collections.Generic;
using Model.Patient;

namespace Repository.Abstract.Medical
{
   public interface IAppointmentRepository : IRepository<Model.Patient.Appointment,long>
   {
      IEnumerable<Appointment> GetPatientAppointments(Model.User.Patient patient);
      
      IEnumerable<Appointment> GetAppointmentsByTime(Util.TimeInterval timeInterval);
      
      IEnumerable<Appointment> GetAppointmentsByDoctor(Model.User.Doctor doctor);
      
      IEnumerable<Appointment> GetCanceledAppointments();
      
      IEnumerable<Appointment> GetCompletedAppointmentsByPatient(Model.User.Patient patient);
      
      IEnumerable<Appointment> GetAppointmentsByRoom(Model.User.Room room);
      
      IEnumerable<Appointment> GetFilteredAppointment(Util.AppointmentFilter appointmentFilter);
      
      IEnumerable<Appointment> GetUpcomingAppointmentsForPatient(Model.User.Patient patient);
      
      IEnumerable<Appointment> GetUpcomingAppointmentsForDoctor(Model.User.Doctor doctor);
      
      void AutoDeleteCanceledAppointments();
   
   }
}