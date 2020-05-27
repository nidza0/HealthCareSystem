// File:    ManagerController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:51
// Purpose: Definition of Class ManagerController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.UsersService;

namespace SIMS.Controller.UsersController
{
    public class ManagerController : IController<Manager, UserID>
    {
        public ManagerService managerService;

        public Manager Create(Manager entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Manager entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Manager> GetAll()
        {
            throw new NotImplementedException();
        }

        public Manager GetByID(UserID id)
        {
            throw new NotImplementedException();
        }

        public Manager Update(Manager entity)
        {
            throw new NotImplementedException();
        }
    }
}