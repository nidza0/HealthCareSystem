// File:    InventoryRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:37
// Purpose: Definition of Class InventoryRepository

using Model.Manager;
using Model.Patient;
using Model.User;
using Repository.CSVRepository.Csv;
using System;
using System.Collections.Generic;

namespace Repository.CSVRepository.HospitalManagementRepository
{
   public class InventoryRepository : CSVRepository<Model.Manager.Inventory,long>, Abstract.HospitalManagement.IInventoryRepository, IEagerCSVRepository<Model.Manager.Inventory,long>
   {
      private void BindInventoryWithMedicine(Model.Manager.Inventory inventory, IEnumerable<Medicine> medicines)
      {
         throw new NotImplementedException();
      }
      
      private void BindInventoryWithItems(Model.Manager.Inventory inventory, IEnumerable<InventoryItem> items)
      {
         throw new NotImplementedException();
      }
      
      public void Bind(Model.Manager.Inventory inventory, IEnumerable<InventoryItem> inventoryItems, IEnumerable<Medicine> medicine)
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

        public IEnumerable<InventoryItem> GetInventoryItemsForRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventoryItem> GetInventoryItems()
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