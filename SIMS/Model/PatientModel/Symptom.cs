/***********************************************************************
 * Module:  Symptom.cs
 * Author:  nikola
 * Purpose: Definition of the Class Symptom
 ***********************************************************************/

using System;
using System.Collections.Generic;
using SIMS.Repository.Abstract;

namespace SIMS.Model.PatientModel
{
    public class Symptom : IIdentifiable<long>
    {
        private long _id;
        private string _name;
        private string _shortDescription;

        private Symptom(long id){
            _id = id;
        }

        private Symptom(string name, string shortDescription)
        {
            _name = name;
            _shortDescription = shortDescription;
        }


        public string Name { get => _name; set => _name = value; }
        public string ShortDescription { get => _shortDescription; set => _shortDescription = value; }

        public long GetId()
            => _id;

        public void SetId(long id)
            => _id = id;
    }
}