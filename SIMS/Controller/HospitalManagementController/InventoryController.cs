// File:    InventoryController.cs
// Author:  Geri
// Created: 20. maj 2020 11:07:40
// Purpose: Definition of Class InventoryController

using System;
using System.Collections.Generic;
using Model.Manager;
using Model.Patient;
using Model.User;
using Service.HospitalManagementService;

namespace Controller.HospitalManagementController
{
   public class InventoryController : IController<Inventory, long>
   {
      public Model.Manager.Inventory AddInventoryItem(Inventory inventory, InventoryItem item)
      {
         throw new NotImplementedException();
      }
      
      public Model.Manager.Inventory SetInventoryItem(InventoryItem inventoryItem)
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

        public InventoryService inventoryService;
   
   }
}