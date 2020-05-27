// File:    InventoryService.cs
// Author:  Geri
// Created: 19. maj 2020 20:24:02
// Purpose: Definition of Class InventoryService

using System;
using System.Collections.Generic;
using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;

namespace SIMS.Service.HospitalManagementService
{
    public class InventoryService : IService<Inventory, long>
    {
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

        public IEnumerable<Item> GetResupply()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventoryItem> GetInventoryItems()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventory> GetAll()
        {
            throw new NotImplementedException();
        }

        public Inventory GetByID(long id)
        {
            throw new NotImplementedException();
        }

        public Inventory Create(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public Inventory Update(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public IInventoryRepository iInventoryRepository;

    }
}