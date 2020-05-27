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
        private double _usage;

        public Medicine medicine;
        public InventoryItem inventoryItem;

        public double Usage { get { return _usage; } set { } }

        public Medicine Medicine { get { return medicine; } set { } }

        public InventoryItem InventoryItem { get { return inventoryItem} set { } }

        public StatsInventory(double usage, Medicine medicine, InventoryItem inventoryItem): base()
        {
            _usage = usage;
            this.medicine = medicine;
            InventoryItem = inventoryItem;
        }

        public StatsInventory(long id): base(id)
        {

        }
    }
}