// File:    InventoryItem.cs
// Author:  vule
// Created: 18. april 2020 16:53:25
// Purpose: Definition of Class InventoryItem

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using System;

namespace SIMS.Model.ManagerModel
{
    public class InventoryItem : Item
    {
        public Room room;

    }
}