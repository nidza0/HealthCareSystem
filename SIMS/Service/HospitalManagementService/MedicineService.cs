// File:    MedicineService.cs
// Author:  Geri
// Created: 20. maj 2020 10:27:14
// Purpose: Definition of Class MedicineService

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;

namespace SIMS.Service.HospitalManagementService
{
    public class MedicineService : IService<Medicine, long>
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

        public IEnumerable<Medicine> GetFilteredMedicine(Util.MedicineFilter medicineFilter)
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

        public Medicine Update(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public IMedicineRepository iMedicineRepository;

    }
}