/***********************************************************************
 * Module:  Inventory.cs
 * Author:  vule
 * Purpose: Definition of the Class Inventory
 ***********************************************************************/

using System;
using SIMS.Model.PatientModel;

namespace SIMS.Model.ManagerModel
{
    public class Inventory
    {
        private long _id;
        public System.Collections.Generic.List<InventoryItem> inventoryItem;
        public System.Collections.Generic.List<Medicine> medicine;

        public bool AddItem()
        {
            throw new NotImplementedException();
        }

        public bool AddMedicine()
        {
            throw new NotImplementedException();
        }

        

        /// <summary>
        /// Property for collection of Model.Patient.Medicine
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Medicine> Medicine
        {
            get
            {
                if (medicine == null)
                    medicine = new System.Collections.Generic.List<Medicine>();
                return medicine;
            }
            set
            {
                RemoveAllMedicine();
                if (value != null)
                {
                    foreach (Medicine oMedicine in value)
                        AddMedicine(oMedicine);
                }
            }
        }

        /// <summary>
        /// Add a new Model.Patient.Medicine in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddMedicine(Medicine newMedicine)
        {
            if (newMedicine == null)
                return;
            if (medicine == null)
                medicine = new System.Collections.Generic.List<Medicine>();
            if (!medicine.Contains(newMedicine))
                medicine.Add(newMedicine);
        }

        /// <summary>
        /// Remove an existing Model.Patient.Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveMedicine(Medicine oldMedicine)
        {
            if (oldMedicine == null)
                return;
            if (medicine != null)
                if (medicine.Contains(oldMedicine))
                    medicine.Remove(oldMedicine);
        }

        /// <summary>
        /// Remove all instances of Model.Patient.Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllMedicine()
        {
            if (medicine != null)
                medicine.Clear();
        }
        

        /// <summary>
        /// Property for collection of InventoryItem
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<InventoryItem> InventoryItem
        {
            get
            {
                if (inventoryItem == null)
                    inventoryItem = new System.Collections.Generic.List<InventoryItem>();
                return inventoryItem;
            }
            set
            {
                RemoveAllInventoryItem();
                if (value != null)
                {
                    foreach (InventoryItem oInventoryItem in value)
                        AddInventoryItem(oInventoryItem);
                }
            }
        }

        /// <summary>
        /// Add a new InventoryItem in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddInventoryItem(InventoryItem newInventoryItem)
        {
            if (newInventoryItem == null)
                return;
            if (inventoryItem == null)
                inventoryItem = new System.Collections.Generic.List<InventoryItem>();
            if (!inventoryItem.Contains(newInventoryItem))
                inventoryItem.Add(newInventoryItem);
        }

        /// <summary>
        /// Remove an existing InventoryItem from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveInventoryItem(InventoryItem oldInventoryItem)
        {
            if (oldInventoryItem == null)
                return;
            if (inventoryItem != null)
                if (inventoryItem.Contains(oldInventoryItem))
                    inventoryItem.Remove(oldInventoryItem);
        }

        /// <summary>
        /// Remove all instances of InventoryItem from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllInventoryItem()
        {
            if (inventoryItem != null)
                inventoryItem.Clear();
        }

    }
}