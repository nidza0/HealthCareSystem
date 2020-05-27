// File:    HospitalController.cs
// Author:  Geri
// Created: 20. maj 2020 11:07:40
// Purpose: Definition of Class HospitalController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.HospitalManagementService;

namespace SIMS.Controller.HospitalManagementController
{
    public class HospitalController : IController<Hospital, long>
    {
        public HospitalService hospitalService;

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

    }
}