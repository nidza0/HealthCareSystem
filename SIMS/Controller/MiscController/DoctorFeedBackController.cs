// File:    DoctorFeedBackController.cs
// Author:  nikola
// Created: 22. maj 2020 17:30:10
// Purpose: Definition of Class DoctorFeedBackController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Service.MiscService;

namespace SIMS.Controller.MiscController
{
    public class DoctorFeedBackController : IController<DoctorFeedback, long>
    {
        public DoctorFeedback GetByPatientDoctor(Patient patient, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorFeedback> GetByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public double GetAverageRatingByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorFeedback> GetRecentRatingsByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorFeedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public DoctorFeedback GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public DoctorFeedback Create(DoctorFeedback entity)
        {
            throw new NotImplementedException();
        }

        public void Update(DoctorFeedback entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DoctorFeedback entity)
        {
            throw new NotImplementedException();
        }

        public DoctorFeedbackService doctorFeedbackService;

    }
}