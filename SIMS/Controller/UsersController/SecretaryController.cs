// File:    SecretaryController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:51
// Purpose: Definition of Class SecretaryController

using System;
using System.Collections.Generic;
using Controller;
using SIMS.Model.UserModel;
using SIMS.Service.UsersService;

namespace SIMS.Controller.UsersController
{
    public class SecretaryController : IController<Secretary, UserID>
    {
        public SecretaryService secretaryService;

        public Secretary Create(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Secretary entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Secretary> GetAll()
        {
            throw new NotImplementedException();
        }

        public Secretary GetByID(UserID id)
        {
            throw new NotImplementedException();
        }

        public Secretary Update(Secretary entity)
        {
            throw new NotImplementedException();
        }
    }
}