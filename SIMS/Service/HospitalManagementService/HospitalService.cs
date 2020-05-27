// File:    HospitalService.cs
// Author:  Geri
// Created: 19. maj 2020 20:24:02
// Purpose: Definition of Class HospitalService

using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;

namespace SIMS.Service.HospitalManagementService
{
    public class HospitalService : IService<Hospital, long>
    {
        public IEnumerable<Hospital> GetHospitalByLocation(Location location)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Hospital> GetAll()
        {
            throw new NotImplementedException();
        }

        public Hospital GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Hospital Create(Hospital entity)
        {
            throw new NotImplementedException();
        }

        public Hospital Update(Hospital entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Hospital entity)
        {
            throw new NotImplementedException();
        }

        public IHospitalRepository iHospitalRepository;

    }
}