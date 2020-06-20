// File:    DoctorFeedbackService.cs
// Author:  vule
// Created: 21. maj 2020 15:04:26
// Purpose: Definition of Class DoctorFeedbackService

using System;
using System.Collections.Generic;
using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;

namespace SIMS.Service.MiscService
{
    public class DoctorFeedbackService : IService<DoctorFeedback, long>
    {
        public IEnumerable<DoctorFeedback> GetByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public double GetAverageRatingByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public void Validate(DoctorFeedback doctorFeedback)
        {
            throw new NotImplementedException();
        }

        public DoctorFeedback GetByPatientDoctor(Patient patient, Doctor doctor)
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

        public DoctorFeedback Update(DoctorFeedback entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(DoctorFeedback entity)
        {
            throw new NotImplementedException();
        }

        void IService<DoctorFeedback, long>.Update(DoctorFeedback entity)
        {
            throw new NotImplementedException();
        }

        public IDoctorFeedbackRepository iDoctorFeedbackRepository;

    }
}