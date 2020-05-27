// File:    HospitalController.cs
// Author:  Geri
// Created: 20. maj 2020 11:07:40
// Purpose: Definition of Class HospitalController

using System;
using System.Collections.Generic;
using Model.User;

namespace Controller.HospitalManagementController
{
   public class HospitalController : IController<Hospital, long>
   {
        public Service.HospitalManagementService.HospitalService hospitalService;

        public IEnumerable<Hospital> GetHospitalByLocation(Model.User.Location location)
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
//pera smrad
        }

        public void Delete(Hospital entity)
        {
            throw new NotImplementedException();
        }

    }
}