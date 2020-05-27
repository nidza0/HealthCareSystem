// File:    Therapy.cs
// Author:  Windows 10
// Created: 15. april 2020 22:03:13
// Purpose: Definition of Class Therapy

using Model.Patient;
using System;

namespace SIMS.Model.PatientModel
{
    public class Therapy
    {
        private long id;

        public bool AddMedicine()
        {
            throw new NotImplementedException();
        }

        public void RemoveMedicine()
        {
            throw new NotImplementedException();
        }

        public void SetTherapyTime()
        {
            throw new NotImplementedException();
        }

        public Util.TimeInterval timeInterval;
        public System.Collections.Generic.List<TherapyDose> therapyDose;

        /// <summary>
        /// Property for collection of TherapyDose
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.Generic.List<TherapyDose> TherapyDose
        {
            get
            {
                if (therapyDose == null)
                    therapyDose = new System.Collections.Generic.List<TherapyDose>();
                return therapyDose;
            }
            set
            {
                RemoveAllTherapyDose();
                if (value != null)
                {
                    foreach (TherapyDose oTherapyDose in value)
                        AddTherapyDose(oTherapyDose);
                }
            }
        }

        /// <summary>
        /// Add a new TherapyDose in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddTherapyDose(TherapyDose newTherapyDose)
        {
            if (newTherapyDose == null)
                return;
            if (therapyDose == null)
                therapyDose = new System.Collections.Generic.List<TherapyDose>();
            if (!therapyDose.Contains(newTherapyDose))
                therapyDose.Add(newTherapyDose);
        }

        /// <summary>
        /// Remove an existing TherapyDose from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveTherapyDose(TherapyDose oldTherapyDose)
        {
            if (oldTherapyDose == null)
                return;
            if (therapyDose != null)
                if (therapyDose.Contains(oldTherapyDose))
                    therapyDose.Remove(oldTherapyDose);
        }

        /// <summary>
        /// Remove all instances of TherapyDose from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllTherapyDose()
        {
            if (therapyDose != null)
                therapyDose.Clear();
        }
        public Prescription prescription;

    }
}