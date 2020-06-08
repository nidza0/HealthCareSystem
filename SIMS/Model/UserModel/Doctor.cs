// File:    Doctor.cs
// Author:  Geri
// Created: 18. april 2020 19:45:12
// Purpose: Definition of Class Doctor

using System;
using System.Collections.Generic;
using SIMS.Model.DoctorModel;

namespace SIMS.Model.UserModel
{
    public class Doctor : Employee
    {
        private Room _office;
        private DocTypeEnum _docTypeEnum;

        public Doctor(  string userName, 
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName, 
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2, 
                        TimeTable timeTable, 
                        Hospital hospital, 
                        Room office, 
                        DocTypeEnum doctorType) 
            : base(timeTable, hospital, userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _office = office;
            _docTypeEnum = doctorType;
        }

        public Doctor(  UserID id, 
                        string userName, 
                        string password, 
                        DateTime dateCreated, 
                        string name, 
                        string surname, 
                        string middleName, 
                        Sex sex, 
                        DateTime dateOfBirth, 
                        string uidn, 
                        Address address, 
                        string homePhone, 
                        string cellPhone, 
                        string email1, 
                        string email2, 
                        TimeTable timeTable, 
                        Hospital hospital, 
                        Room office, 
                        DocTypeEnum doctorType) 
            : base(id, timeTable, hospital, userName, password, dateCreated, name, surname, middleName, sex, dateOfBirth, uidn, address, homePhone, cellPhone, email1, email2)
        {
            _office = office;
            _docTypeEnum = doctorType;
        }

        public Doctor(UserID id) : base(id) { }

        public Room Office { get => _office; set => _office = value; }
        public DocTypeEnum DocTypeEnum { get => _docTypeEnum; }
    }
}