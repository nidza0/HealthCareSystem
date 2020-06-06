// File:    InventoryRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:37
// Purpose: Definition of Class InventoryRepository

using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class InventoryRepository : CSVRepository<Inventory, long>, IInventoryRepository, IEagerCSVRepository<Inventory, long>
    {
        private void BindInventoryWithMedicine(Inventory inventory, IEnumerable<Medicine> medicines)
        {
            throw new NotImplementedException();
        }

        private void BindInventoryWithItems(Inventory inventory, IEnumerable<InventoryItem> items)
        {
            throw new NotImplementedException();
        }

        public void Bind(Inventory inventory, IEnumerable<InventoryItem> inventoryItems, IEnumerable<Medicine> medicine)
        {
            throw new NotImplementedException();
        }

        public Inventory AddInventoryItem(Inventory inventory, InventoryItem item)
        {
            throw new NotImplementedException();
        }

        public Inventory SetInventoryItem(InventoryItem inventoryItem)
        {
            throw new NotImplementedException();
        }

        public bool RemoveInventoryItem(Item item)
        {
            throw new NotImplementedException();
        }


        public Inventory GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventory> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public MedicineRepository medicineRepository;

    }
}