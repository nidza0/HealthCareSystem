// File:    InventoryService.cs
// Author:  Geri
// Created: 19. maj 2020 20:24:02
// Purpose: Definition of Class InventoryService

using System;
using System.Collections.Generic;
using Model.Manager;
using Model.Patient;

namespace Service.HospitalManagementService
{
   public class InventoryService : IService<Model.Manager.Inventory,long>
   {
      public Model.Manager.Inventory AddInventoryItem(Model.Manager.Inventory inventory, Model.Manager.InventoryItem item)
      {
         throw new NotImplementedException();
      }
      
      public Model.Manager.Inventory SetInventoryItem(Model.Manager.InventoryItem inventoryItem)
      {
         throw new NotImplementedException();
      }
      
      public bool RemoveInventoryItem(Model.Patient.Item item)
      {
         throw new NotImplementedException();
      }
      
      public IEnumerable<InventoryItem> GetInventoryItemsForRoom(Model.User.Room room)
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

        public Repository.Abstract.HospitalManagement.IInventoryRepository iInventoryRepository;
   
   }
}