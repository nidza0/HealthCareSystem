// File:    InventoryItem.cs
// Author:  vule
// Created: 18. april 2020 16:53:25
// Purpose: Definition of Class InventoryItem

using System;

namespace Model.Manager
{
   public class InventoryItem : Model.Patient.Item
   {
      public Model.User.Room room;
   
   }
}