// File:    Item.cs
// Author:  vule
// Created: 18. april 2020 16:49:38
// Purpose: Definition of Class Item

using System;

namespace Model.Patient
{
   public abstract class Item
   {
      private String name;
      private int inStock;
      private int minNumber;
      private long id;
      
      public bool EditMinNumber()
      {
         throw new NotImplementedException();
      }
      
      public bool AddItem()
      {
         throw new NotImplementedException();
      }
      
      public bool RemoveItem()
      {
         throw new NotImplementedException();
      }
      
      public bool Buy()
      {
         throw new NotImplementedException();
      }
   
   }
}