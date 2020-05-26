// File:    LongSequencer.cs
// Author:  Windows 10
// Created: 23. maj 2020 16:21:53
// Purpose: Definition of Class LongSequencer

using System;

namespace Repository.Sequencer
{
   public class LongSequencer : ISequencer<long>
   {
      private long nextID;

        public long GenerateID()
        {
            throw new NotImplementedException();
        }

        public void Initialize(long initID)
        {
            throw new NotImplementedException();
        }
    }
}