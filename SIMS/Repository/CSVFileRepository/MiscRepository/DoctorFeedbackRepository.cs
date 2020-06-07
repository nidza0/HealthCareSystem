// File:    DoctorFeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:52:51
// Purpose: Definition of Class DoctorFeedbackRepository

using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.Abstract.UsersAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class DoctorFeedbackRepository : CSVRepository<DoctorFeedback, long>, IDoctorFeedbackRepository, IEagerCSVRepository<DoctorFeedback, long>
    {
        private IDoctorRepository _doctorRepository;

        public DoctorFeedbackRepository(string entityName, IDoctorRepository doctorRepository, ICSVStream<DoctorFeedback> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<DoctorFeedback>())
        {
            _doctorRepository = doctorRepository;
        }
        public void BindWithDoctor(IEnumerable<DoctorFeedback> doctorFeedbacks, IEnumerable<Doctor> doctors)
            => doctorFeedbacks.ToList().ForEach(df => df.Recepient = GetRecepientById(doctors, df.Recepient.GetId()));

        private Doctor GetRecepientById(IEnumerable<Doctor> doctors, UserID id)
            => doctors.SingleOrDefault(d => d.GetId() == id);

        public IEnumerable<DoctorFeedback> GetByDoctor(Doctor doctor)
            => GetAll().ToList().Where(df => df.Recepient.Equals(doctor));

        public DoctorFeedback GetByPatientDoctor(Patient patient, Doctor doctor)
            => GetAll().ToList().SingleOrDefault(df => df.Recepient.Equals(doctor) && df.User.Equals(patient));

        public DoctorFeedback GetEager(long id)
            => GetAllEager().SingleOrDefault(df => df.GetId() == id);

        public IEnumerable<DoctorFeedback> GetAllEager()
        {
            IEnumerable<DoctorFeedback> feedback = GetAll();
            IEnumerable<Doctor> doctors = _doctorRepository.GetAll();

            BindWithDoctor(feedback, doctors);
            return feedback;
        }

        public DoctorRepository doctorRepository;
    }
}