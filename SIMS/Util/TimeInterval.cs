// File:    TimeInterval.cs
// Author:  nikola
// Created: 21. maj 2020 13:42:07
// Purpose: Definition of Class TimeInterval

using System;

namespace SIMS.Util
{
    public class TimeInterval
    {
        private DateTime _startTime;
        private DateTime _endTime;

        public DateTime StartTime { get => _startTime; set => _startTime = value; }
        public DateTime EndTime { get => _endTime; set => _endTime = value; }

        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            //TODO: Enforce endTime >= startTime
            _startTime = startTime;
            _endTime = endTime;
        }

        public bool IsTimeBetween(DateTime dateTime)
            => ((dateTime >= StartTime) && (dateTime <= EndTime));

        public bool IsOverlappingWith(TimeInterval timeInterval)
        {
            //(StartA <(=) EndB) and (EndA >(=) StartB)
            return ((StartTime < timeInterval.EndTime) && (EndTime > timeInterval.StartTime));
        }

        public TimeSpan Duration()
            => EndTime.Subtract(StartTime);

    }
}