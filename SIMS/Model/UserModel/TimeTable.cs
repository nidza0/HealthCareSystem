// File:    TimeTable.cs
// Author:  Geri
// Created: 18. april 2020 19:37:52
// Purpose: Definition of Class TimeTable

using SIMS.Repository.Abstract;
using SIMS.Util;
using System;
using System.Collections.Generic;

namespace SIMS.Model.UserModel
{
    public class TimeTable : IIdentifiable<long>
    {
        private long _id;
        private Dictionary<WorkingDaysEnum, TimeInterval> _workingHours;

        public TimeTable(Dictionary<WorkingDaysEnum, TimeInterval> workingHours)
        {
            _workingHours = workingHours;
        }

        public TimeTable(long id, Dictionary<WorkingDaysEnum, TimeInterval> workingHours)
        {
            _workingHours = workingHours;
        }

        public TimeTable()
        {
            _workingHours = new Dictionary<WorkingDaysEnum, TimeInterval>();
        }

        public TimeTable(long id)
        {
            _id = id;
        }

        public bool Edit()
        {
            throw new NotImplementedException();
        }

        public Dictionary<WorkingDaysEnum, TimeInterval> getWorkingHours()
        {
            return _workingHours;
        }

        public void setWorkingHours(WorkingDaysEnum workingDaysEnum, TimeInterval timeInterval)
        {
            if (_workingHours.ContainsKey(workingDaysEnum))
            {
                _workingHours[workingDaysEnum] = timeInterval;
            }
            else
            {
                _workingHours.Add(workingDaysEnum, timeInterval);
            }
        }

        public long GetId()
        {
            return _id;
        }

        public void SetId(long id)
        {
            _id = id;
        }
    }
}