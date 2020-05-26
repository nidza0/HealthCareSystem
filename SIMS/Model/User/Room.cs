/***********************************************************************
 * Module:  Room.cs
 * Author:  vule
 * Purpose: Definition of the Class Room
 ***********************************************************************/

using System;
using Model.Manager;

namespace Model.User
{
   public class Room
   {
      private long id;
      private String roomNumber;
      private bool occupied;
      private int floor;
      
      public bool Reserve()
      {
         throw new NotImplementedException();
      }
      
      public int Filter()
      {
         throw new NotImplementedException();
      }
      
      public bool AddAppointment()
      {
         throw new NotImplementedException();
      }
      
      public bool RemoveAppointment()
      {
         throw new NotImplementedException();
      }
      
      public bool EditAppointment()
      {
         throw new NotImplementedException();
      }
      
      public RoomType roomType;
      public InventoryItem inventoryItem;
   
   }
}