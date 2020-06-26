// File:    MedicineService.cs
// Author:  Geri
// Created: 20. maj 2020 10:27:14
// Purpose: Definition of Class MedicineService

using System;
using System.Collections.Generic;
using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;

namespace SIMS.Service.HospitalManagementService
{
    public class MedicineService : IService<Medicine, long>
    {

        MedicineRepository _medicineRepository;
        

        public MedicineService(MedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public IEnumerable<Medicine> GetMedicineForDisease(Disease disease)
            => _medicineRepository.GetMedicineForDisease(disease);

        public IEnumerable<Medicine> GetMedicineByIngredient(Ingredient ingredient)
            => _medicineRepository.GetMedicineByIngredient(ingredient);

        public Medicine GetMedicineByName(string name)
            => _medicineRepository.GetMedicineByName(name);

        public IEnumerable<Medicine> GetFilteredMedicine(Util.MedicineFilter medicineFilter)
            => _medicineRepository.GetFilteredMedicine(medicineFilter);

        public IEnumerable<Medicine> GetMedicinePendingApproval()
            => _medicineRepository.GetMedicinePendingApproval();

        public IEnumerable<Medicine> GetAll()
            => _medicineRepository.GetAllEager();

        public Medicine GetByID(long id)
            => _medicineRepository.GetByID(id);

        public Medicine Create(Medicine entity)
        {
            // TODO: Validate
            return _medicineRepository.Create(entity);
        }

        public void Update(Medicine entity)
        {   
            // TODO: Validate
            _medicineRepository.Update(entity);
        }

        public void Delete(Medicine entity)
            => _medicineRepository.Delete(entity);

        void IService<Medicine, long>.Update(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public void Validate(Medicine entity)
        {
            throw new NotImplementedException();
        }

        public IMedicineRepository iMedicineRepository;

    }
}