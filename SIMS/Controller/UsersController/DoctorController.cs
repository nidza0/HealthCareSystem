// File:    DoctorController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:50
// Purpose: Definition of Class DoctorController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Service.MedicalService;
using SIMS.Service.UsersService;

namespace SIMS.Controller.UsersController
{
    public class DoctorController : IController<Doctor, UserID>
    {
        public DoctorService doctorService;
        public DiagnosisService diagnosisService;
        public TherapyService therapyService;
        public MedicalRecordService medicalRecordService;

        public DoctorController(DoctorService doctorService, DiagnosisService diagnosisService, TherapyService therapyService, MedicalRecordService medicalRecordService)
        {
            this.doctorService = doctorService;
            this.diagnosisService = diagnosisService;
            this.therapyService = therapyService;
            this.medicalRecordService = medicalRecordService;
        }

        public IEnumerable<Doctor> GetActiveDoctors()
            => doctorService.GetActiveDoctors();

        public IEnumerable<Doctor> GetDoctorByType(DoctorType doctorType)
            => doctorService.GetDoctorByType(doctorType);

        public IEnumerable<Doctor> GetAvailableDoctorsByTime(Util.TimeInterval timeInterval)
            => doctorService.GetAvailableDoctorsByTime(timeInterval);

        public IEnumerable<Doctor> GetFilteredDoctors(Util.DoctorFilter filter)
            => doctorService.GetFilteredDoctors(filter);

        public IEnumerable<Doctor> GetAll()
            => doctorService.GetAll();

        public Doctor GetByID(UserID id)
            => doctorService.GetByID(id);

        public Doctor Create(Doctor entity)
            => doctorService.Create(entity);

        public void Update(Doctor entity)
            => doctorService.Update(entity);

        public void Delete(Doctor entity)
            => doctorService.Delete(entity);

    }
}