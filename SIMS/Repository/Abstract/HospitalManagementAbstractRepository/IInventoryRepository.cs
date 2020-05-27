// File:    IInventoryRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 13:57:59
// Purpose: Definition of Interface IInventoryRepository

using System;
using System.Collections.Generic;
using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;

namespace SIMS.Repository.Abstract.HospitalManagementAbstractRepository
{
    public interface IInventoryRepository : IRepository<Inventory, long>
    {
        Inventory AddInventoryItem(Inventory inventory, InventoryItem item);

        Inventory SetInventoryItem(InventoryItem inventoryItem);

        bool RemoveInventoryItem(Item item);

        IEnumerable<InventoryItem> GetInventoryItemsForRoom(Room room);

        IEnumerable<InventoryItem> GetInventoryItems();

    }
}