// File:    DoctorFeedbackRepository.cs
// Author:  Geri
// Created: 24. maj 2020 17:52:51
// Purpose: Definition of Class DoctorFeedbackRepository

using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.MiscAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.MiscRepository
{
    public class DoctorFeedbackRepository : CSVRepository<DoctorFeedback, long>, IDoctorFeedbackRepository, IEagerCSVRepository<DoctorFeedback, long>
    {
        public DoctorFeedbackRepository(string entityName, ICSVStream<DoctorFeedback> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<DoctorFeedback>())
        {
        }
        public void BindWithDoctor(IEnumerable<DoctorFeedback> doctorFeedbacks)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorFeedback> GetByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public DoctorFeedback GetByPatientDoctor(Patient patient, Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public DoctorFeedback GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DoctorFeedback> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public DoctorRepository doctorRepository;
    }
}