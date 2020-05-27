// File:    Hospital.cs
// Author:  Windows 10
// Created: 19. april 2020 22:03:33
// Purpose: Definition of Class Hospital

using System;
using System.Collections.Generic;

namespace SIMS.Model.UserModel
{
    public class Hospital
    {
        private string _name;
        private long _id;
        private string _telephone;
        private string _website;

        private System.Collections.Generic.List<Room> _room;

        public Hospital(string name, long id, string telephone, string website, List<Room> room, List<Employee> employee, Address address)
        {
            _name = name;
            _id = id;
            _telephone = telephone;
            _website = website;
            _room = room;
            _employee = employee;
            _address = address;
        }






        /// <summary>
        /// Property for collection of Room
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Room> Room
        {
            get
            {
                if (_room == null)
                    _room = new System.Collections.Generic.List<Room>();
                return _room;
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
            if (_room == null)
                _room = new System.Collections.Generic.List<Room>();
            if (!_room.Contains(newRoom))
                _room.Add(newRoom);
        }

        /// <summary>
        /// Remove an existing Room from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveRoom(Room oldRoom)
        {
            if (oldRoom == null)
                return;
            if (_room != null)
                if (_room.Contains(oldRoom))
                    _room.Remove(oldRoom);
        }

        /// <summary>
        /// Remove all instances of Room from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllRoom()
        {
            if (_room != null)
                _room.Clear();
        }

        public System.Collections.Generic.List<Employee> _employee;

        /// <summary>
        /// Property for collection of Employee
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<Employee> Employee
        {
            get
            {
                if (_employee == null)
                    _employee = new System.Collections.Generic.List<Employee>();
                return _employee;
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
            if (_employee == null)
                _employee = new System.Collections.Generic.List<Employee>();
            if (!_employee.Contains(newEmployee))
            {
                _employee.Add(newEmployee);
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
            if (_employee != null)
                if (_employee.Contains(oldEmployee))
                {
                    _employee.Remove(oldEmployee);
                    oldEmployee.Hospital = null;
                }
        }

        /// <summary>
        /// Remove all instances of Employee from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllEmployee()
        {
            if (_employee != null)
            {
                System.Collections.ArrayList tmpEmployee = new System.Collections.ArrayList();
                foreach (Employee oldEmployee in _employee)
                    tmpEmployee.Add(oldEmployee);
                _employee.Clear();
                foreach (Employee oldEmployee in tmpEmployee)
                    oldEmployee.Hospital = null;
                tmpEmployee.Clear();
            }
        }
        public Address _address;

        //Properties
        public long ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Address Address {
            get { return _address; }
            set { _address = value;  }
        }

        public string Telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        public string Website
        {
            get { return _website;  }
            set { _website = value;  }
        }
    }
}