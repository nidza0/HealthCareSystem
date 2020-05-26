// File:    SecretaryController.cs
// Author:  nikola
// Created: 22. maj 2020 17:03:51
// Purpose: Definition of Class SecretaryController

using System;
using System.Collections.Generic;
using Model.User;

namespace Controller.UserController
{
   public class SecretaryController : IController<Model.User.Secretary,Model.User.UserID>
   {
      public Service.UserService.SecretaryService secretaryService;

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