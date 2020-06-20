// File:    HospitalService.cs
// Author:  Geri
// Created: 19. maj 2020 20:24:02
// Purpose: Definition of Class HospitalService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;

namespace SIMS.Service.HospitalManagementService
{
    public class HospitalService : IService<Hospital, long>
    {
        HospitalRepository _hospitalRepository; 

        public HospitalService(HospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public IEnumerable<Hospital> GetHospitalByLocation(Location location)
            => _hospitalRepository.GetHospitalByLocation(location);

        public IEnumerable<Hospital> GetAll()
            => _hospitalRepository.GetAllEager();

        public Hospital GetByID(long id)
            => _hospitalRepository.GetByID(id);

        public Hospital Create(Hospital entity)
            => _hospitalRepository.Create(entity);

        public void Update(Hospital entity)
            => _hospitalRepository.Update(entity);

        public void Delete(Hospital entity)
            => _hospitalRepository.Delete(entity);

        public IHospitalRepository iHospitalRepository;

    }
}