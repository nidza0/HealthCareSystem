// File:    ComplexSequencer.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:21:53
// Purpose: Definition of Class ComplexSequencer

using System;
using Model.User;

namespace Repository.Sequencer
{
   public class ComplexSequencer : ISequencer<UserID>
   {
      private Model.User.UserID nextID;

        public UserID GenerateID()
        {
            throw new NotImplementedException();
        }

        public void Initialize(UserID initID)
        {
            throw new NotImplementedException();
        }
    }
}