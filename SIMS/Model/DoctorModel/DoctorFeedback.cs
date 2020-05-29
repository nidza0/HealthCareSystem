// File:    DoctorFeedback.cs
// Author:  Geri
// Created: 18. april 2020 20:50:38
// Purpose: Definition of Class DoctorFeedback

using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;

namespace SIMS.Model.DoctorModel
{
    public class DoctorFeedback : Feedback
    {
        private Doctor _recepient;

        public DoctorFeedback(User user, string comment, List<Rating> rating, Doctor recepient) : base(user, comment, rating) => _recepient = recepient;
        public DoctorFeedback(long id, User user, string comment, List<Rating> rating, Doctor recepient) : base(id, user, comment, rating) => _recepient = recepient;

        public DoctorFeedback(long id) : base(id)
        {
        }

        public Doctor Recepient
        {
            get { return _recepient; }
            set { _recepient = value; }
        }

        

    }
}