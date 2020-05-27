// File:    StatsInventory.cs
// Author:  vule
// Created: 18. april 2020 17:13:16
// Purpose: Definition of Class StatsInventory

using SIMS.Model.PatientModel;
using System;

namespace SIMS.Model.ManagerModel
{
    public class StatsInventory : Stats
    {
        private double usage;

        public Medicine medicine;
        public InventoryItem inventoryItem;

    }
}