// File:    DoctorController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:50
// Purpose: Definition of Class DoctorController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;

namespace SIMS.Controller.UsersController
{
    public class DoctorController : IController<Doctor, UserID>
    {
        public Service.UsersService.DoctorService doctorService;
        public Service.MedicalService.DiagnosisService diagnosisService;
        public Service.MedicalService.TherapyService therapyService;
        public Service.MedicalService.MedicalRecordService medicalRecordService;

        public IEnumerable<Doctor> GetActiveDoctors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetDoctorByType(DocTypeEnum doctorType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAvailableDoctorsByTime(Util.TimeInterval timeInterval)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetFilteredDoctors(Util.DoctorFilter filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Doctor> GetAll()
        {
            throw new NotImplementedException();
        }

        public Doctor GetByID(UserID id)
        {
            throw new NotImplementedException();
        }

        public Doctor Create(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Doctor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Doctor entity)
        {
            throw new NotImplementedException();
        }


    }
}