// File:    ManagerController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:51
// Purpose: Definition of Class ManagerController

using System;
using System.Collections.Generic;
using Model.User;

namespace Controller.UserController
{
   public class ManagerController : IController<Model.User.Manager,Model.User.UserID>
   {
      public Service.UserService.ManagerService managerService;

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