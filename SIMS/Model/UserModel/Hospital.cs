// File:    Hospital.cs
// Author:  Windows 10
// Created: 19. april 2020 22:03:33
// Purpose: Definition of Class Hospital

using System;

namespace SIMS.Model.UserModel
{
    public class Hospital
    {
        private string name;
        private long id;
        private string telephone;
        private string website;

        private System.Collections.Generic.List<Room> room;

        /// <summary>
        /// Property for collection of Room
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Room> Room
        {
            get
            {
                if (room == null)
                    room = new System.Collections.Generic.List<Room>();
                return room;
            }
            set
            {
                RemoveAllRoom();
                if (value != null)
                {
                    foreach (Room oRoom in value)
                        AddRoom(oRoom);
                }
            }
        }

        /// <summary>
        /// Add a new Room in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddRoom(Room newRoom)
        {
            if (newRoom == null)
                return;
            if (room == null)
                room = new System.Collections.Generic.List<Room>();
            if (!room.Contains(newRoom))
                room.Add(newRoom);
        }

        /// <summary>
        /// Remove an existing Room from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveRoom(Room oldRoom)
        {
            if (oldRoom == null)
                return;
            if (room != null)
                if (room.Contains(oldRoom))
                    room.Remove(oldRoom);
        }

        /// <summary>
        /// Remove all instances of Room from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllRoom()
        {
            if (room != null)
                room.Clear();
        }

        public System.Collections.Generic.List<Employee> employee;

        /// <summary>
        /// Property for collection of Employee
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Employee> Employee
        {
            get
            {
                if (employee == null)
                    employee = new System.Collections.Generic.List<Employee>();
                return employee;
            }
            set
            {
                RemoveAllEmployee();
                if (value != null)
                {
                    foreach (Employee oEmployee in value)
                        AddEmployee(oEmployee);
                }
            }
        }

        /// <summary>
        /// Add a new Employee in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddEmployee(Employee newEmployee)
        {
            if (newEmployee == null)
                return;
            if (employee == null)
                employee = new System.Collections.Generic.List<Employee>();
            if (!employee.Contains(newEmployee))
            {
                employee.Add(newEmployee);
                newEmployee.Hospital = this;
            }
        }

        /// <summary>
        /// Remove an existing Employee from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveEmployee(Employee oldEmployee)
        {
            if (oldEmployee == null)
                return;
            if (employee != null)
                if (employee.Contains(oldEmployee))
                {
                    employee.Remove(oldEmployee);
                    oldEmployee.Hospital = null;
                }
        }

        /// <summary>
        /// Remove all instances of Employee from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllEmployee()
        {
            if (employee != null)
            {
                System.Collections.ArrayList tmpEmployee = new System.Collections.ArrayList();
                foreach (Employee oldEmployee in employee)
                    tmpEmployee.Add(oldEmployee);
                employee.Clear();
                foreach (Employee oldEmployee in tmpEmployee)
                    oldEmployee.Hospital = null;
                tmpEmployee.Clear();
            }
        }
        public Address address;

    }
}