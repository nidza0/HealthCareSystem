// File:    Diagnosis.cs
// Author:  Windows 10
// Created: 16. april 2020 18:22:13
// Purpose: Definition of Class Diagnosis

using System;
using System.Collections.Generic;
using SIMS.Repository.Abstract;

namespace SIMS.Model.PatientModel
{
    public class Diagnosis : IIdentifiable<long>
    {
        private long _id;
        private Therapy _activeTherapy;
        private DateTime _date;
        private Disease _diagnosedDisease;
        private List<Therapy> _previousTherapies;

        public Diagnosis(long id)
        {
            _id = id;
        }

        public Diagnosis(Disease disease, Therapy activeTherapy, List<Therapy> previousTherapy = null)
        {
            //Constructor used when first created by Doctor.
            _diagnosedDisease = disease;
            _activeTherapy = activeTherapy;
            _date = DateTime.Now;

            if (previousTherapy == null)
                _previousTherapies = new List<Therapy>();
            else
                _previousTherapies = previousTherapy;
        }

        public Diagnosis(Disease disease, Therapy activeTherapy,DateTime issuedOn, List<Therapy> previousTherapy = null)
        {
            //Constructor used for complete initialization(eg. reading from the database)
            _diagnosedDisease = disease;
            _activeTherapy = activeTherapy;
            _date = issuedOn;

            if (previousTherapy == null)
                _previousTherapies = new List<Therapy>();
            else
                _previousTherapies = previousTherapy;
        }



        private void ChangeActiveTherapy(Therapy therapy)
        {
            if (_previousTherapies.Contains(therapy))
            {
                //If we are choosing one from the previous therapies
                RemovePreviousTherapies(therapy);
            }
            else
            {
               //If it's not one from the previous therapies, we add the current therapy(if not null) to the list of previous therapies
               if(_activeTherapy != null)
                {
                    AddPreviousTherapies(_activeTherapy); //We put the active therapy to the list of previous therapies
                }
            }

            _activeTherapy = therapy; //We finally set the active therapy.
        }

        public void RemoveActiveTherapy()
        {
            if(_activeTherapy != null)
            {
                //If there is active therapy at the moment, put it to the list of previous therapies.
                _previousTherapies.Add(_activeTherapy);
            }
            _activeTherapy = null; //Remove active therapy.
        }



        /// <summary>
        /// Property for collection of Therapy
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public List<Therapy> PreviousTherapies
        {
            get
            {
                if (_previousTherapies == null)
                    _previousTherapies = new List<Therapy>();
                return _previousTherapies;
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

        public long Id { get => _id; set => _id = value; }
        public Therapy ActiveTherapy { get => _activeTherapy; set => ChangeActiveTherapy(value); }
        public DateTime Date { get => _date; set => _date = value; }
        public Disease DiagnosedDisease { get => _diagnosedDisease; set => _diagnosedDisease = value; }

        /// <summary>
        /// Add a new Therapy in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddPreviousTherapies(Therapy newTherapy)
        {
            if (newTherapy == null)
                return;
            if (_previousTherapies == null)
                _previousTherapies = new List<Therapy>();
            if (!_previousTherapies.Contains(newTherapy))
                _previousTherapies.Add(newTherapy);
        }

        /// <summary>
        /// Remove an existing Therapy from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemovePreviousTherapies(Therapy oldTherapy)
        {
            if (oldTherapy == null)
                return;
            if (_previousTherapies != null)
                if (_previousTherapies.Contains(oldTherapy))
                    _previousTherapies.Remove(oldTherapy);
        }

        /// <summary>
        /// Remove all instances of Therapy from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllPreviousTherapies()
        {
            if (_previousTherapies != null)
                _previousTherapies.Clear();
        }

        public long GetId() => _id;

        public void SetId(long id) => _id = id;
    }
}