// File:    MedicineRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:40
// Purpose: Definition of Class MedicineRepository

using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.MedicalRepository;
using SIMS.Specifications.Converter;
using SIMS.Util;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class MedicineRepository : CSVRepository<Medicine, long>, IMedicineRepository, IEagerCSVRepository<Medicine, long>
    {
        private void BindMedicineWithDisease(IEnumerable<Medicine> medicine, IEnumerable<Disease> disease)
        {
            throw new NotImplementedException();
        }

        private void BindMedicineWithIngredients(IEnumerable<Medicine> medicine, IEnumerable<Ingredient> ingredients)
        {
            throw new NotImplementedException();
        }

        private void Bind(IEnumerable<Medicine> medicine)
        {
            throw new NotImplementedException();
        }

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

        public Medicine GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medicine> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public IngredientRepository ingredientRepository;
        public MedicineSpecificationConverter medicineSpecificationConverter;
        public DiseaseRepository diseaseRepository;

    }
}