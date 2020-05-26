// File:    Employee.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class Employee

using System;

namespace Model.User
{
   public class Employee : User
   {
      public TimeTable timeTable;
      public Hospital hospital;
      
      /// <summary>
      /// Property for Hospital
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
      public Hospital Hospital
      {
         get
         {
            return hospital;
         }
         set
         {
            if (this.hospital == null || !this.hospital.Equals(value))
            {
               if (this.hospital != null)
               {
                  Hospital oldHospital = this.hospital;
                  this.hospital = null;
                  oldHospital.RemoveEmployee(this);
               }
               if (value != null)
               {
                  this.hospital = value;
                  this.hospital.AddEmployee(this);
               }
            }
         }
      }
   
   }
}