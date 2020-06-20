// File:    MedicineController.cs
// Author:  Geri
// Created: 20. maj 2020 11:07:40
// Purpose: Definition of Class MedicineController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.PatientModel;
using SIMS.Service.HospitalManagementService;
using SIMS.Util;

namespace SIMS.Controller.HospitalManagementController
{
    public class MedicineController : IController<Medicine, long>
    {
        public IEnumerable<Medicine> GetMedicineForDisease(Disease disease)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetMedicineByIngredient(Ingredient ingredient)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetMedicineByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetFilteredMedicine(MedicineFilter medicineFilter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetMedicinePendingApproval()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetAll()
        {
            throw new NotImplementedException();
        }

        public Medicine GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Medicine Create(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public MedicineService medicineService;

    }
}