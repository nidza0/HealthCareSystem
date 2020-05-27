// File:    Employee.cs
// Author:  Geri
// Created: 18. april 2020 19:35:17
// Purpose: Definition of Class Employee

using System;

namespace SIMS.Model.UserModel
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
                if (hospital == null || !hospital.Equals(value))
                {
                    if (hospital != null)
                    {
                        Hospital oldHospital = hospital;
                        hospital = null;
                        oldHospital.RemoveEmployee(this);
                    }
                    if (value != null)
                    {
                        hospital = value;
                        hospital.AddEmployee(this);
                    }
                }
            }
        }

    }
}