// File:    Diagnosis.cs
// Author:  Windows 10
// Created: 16. april 2020 18:22:13
// Purpose: Definition of Class Diagnosis

using System;

namespace SIMS.Model.PatientModel
{
    public class Diagnosis
    {
        private long id;
        private Therapy activeTherapy;
        private DateTime date;

        public bool AddTherapy()
        {
            throw new NotImplementedException();
        }

        public bool ChangeActiveTherapy()
        {
            throw new NotImplementedException();
        }

        public bool RemoveTherapy()
        {
            throw new NotImplementedException();
        }

        public Disease diagnosedDisease;

        /// <summary>
        /// Property for Disease
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Disease DiagnosedDisease
        {
            get
            {
                return diagnosedDisease;
            }
            set
            {
                diagnosedDisease = value;
            }
        }
        public System.Collections.ArrayList previousTherapies;

        /// <summary>
        /// Property for collection of Therapy
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.ArrayList PreviousTherapies
        {
            get
            {
                if (previousTherapies == null)
                    previousTherapies = new System.Collections.ArrayList();
                return previousTherapies;
            }
            set
            {
                RemoveAllPreviousTherapies();
                if (value != null)
                {
                    foreach (Therapy oTherapy in value)
                        AddPreviousTherapies(oTherapy);
                }
            }
        }

        /// <summary>
        /// Add a new Therapy in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddPreviousTherapies(Therapy newTherapy)
        {
            if (newTherapy == null)
                return;
            if (previousTherapies == null)
                previousTherapies = new System.Collections.ArrayList();
            if (!previousTherapies.Contains(newTherapy))
                previousTherapies.Add(newTherapy);
        }

        /// <summary>
        /// Remove an existing Therapy from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemovePreviousTherapies(Therapy oldTherapy)
        {
            if (oldTherapy == null)
                return;
            if (previousTherapies != null)
                if (previousTherapies.Contains(oldTherapy))
                    previousTherapies.Remove(oldTherapy);
        }

        /// <summary>
        /// Remove all instances of Therapy from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllPreviousTherapies()
        {
            if (previousTherapies != null)
                previousTherapies.Clear();
        }

    }
}