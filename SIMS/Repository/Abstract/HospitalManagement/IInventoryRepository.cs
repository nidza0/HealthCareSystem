// File:    IInventoryRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 13:57:59
// Purpose: Definition of Interface IInventoryRepository

using System;
using System.Collections.Generic;
using Model.Manager;

namespace Repository.Abstract.HospitalManagement
{
   public interface IInventoryRepository : IRepository<Model.Manager.Inventory,long>
   {
      Model.Manager.Inventory AddInventoryItem(Model.Manager.Inventory inventory, Model.Manager.InventoryItem item);
      
      Model.Manager.Inventory SetInventoryItem(Model.Manager.InventoryItem inventoryItem);
      
      bool RemoveInventoryItem(Model.Patient.Item item);
      
      IEnumerable<InventoryItem> GetInventoryItemsForRoom(Model.User.Room room);
      
      IEnumerable<InventoryItem> GetInventoryItems();
   
   }
}