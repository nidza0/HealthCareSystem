// File:    TimeInterval.cs
// Author:  nikola
// Created: 21. maj 2020 13:42:07
// Purpose: Definition of Class TimeInterval

using System;

namespace SIMS.Util
{
    public class TimeInterval
    {
        private DateTime startTime;
        private DateTime endTime;

        public bool IsTimeBetween(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public bool IsOverlappingWith(TimeInterval timeInterval)
        {
            throw new NotImplementedException();
        }

        public DateTime Duration()
        {
            throw new NotImplementedException();
        }

    }
}