// File:    StatsInventory.cs
// Author:  vule
// Created: 18. april 2020 17:13:16
// Purpose: Definition of Class StatsInventory

using System;

namespace Model.Manager
{
   public class StatsInventory : Stats
   {
      private Double usage;
      
      public Model.Patient.Medicine medicine;
      public InventoryItem inventoryItem;
   
   }
}