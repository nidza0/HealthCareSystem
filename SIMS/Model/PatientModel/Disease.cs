/***********************************************************************
 * Module:  Disease.cs
 * Author:  nikola
 * Purpose: Definition of the Class Disease
 ***********************************************************************/

using System;

namespace SIMS.Model.PatientModel
{
    public class Disease
    {
        private long id;
        private string name;
        private string overview;
        private bool isChronic;

        public void AddSymptom()
        {
            throw new NotImplementedException();
        }

        public void RemoveSymptom()
        {
            throw new NotImplementedException();
        }

        public int AddMedicine()
        {
            throw new NotImplementedException();
        }

        public int RemoveMedicine()
        {
            throw new NotImplementedException();
        }

        public DiseaseType diseaseType;

        /// <summary>
        /// Property for DiseaseType
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public DiseaseType DiseaseType
        {
            get
            {
                return diseaseType;
            }
            set
            {
                diseaseType = value;
            }
        }
        public System.Collections.ArrayList administratedFor;

        /// <summary>
        /// Property for collection of Medicine
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.ArrayList AdministratedFor
        {
            get
            {
                if (administratedFor == null)
                    administratedFor = new System.Collections.ArrayList();
                return administratedFor;
            }
            set
            {
                RemoveAllAdministratedFor();
                if (value != null)
                {
                    foreach (Medicine oMedicine in value)
                        AddAdministratedFor(oMedicine);
                }
            }
        }

        /// <summary>
        /// Add a new Medicine in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddAdministratedFor(Medicine newMedicine)
        {
            if (newMedicine == null)
                return;
            if (administratedFor == null)
                administratedFor = new System.Collections.ArrayList();
            if (!administratedFor.Contains(newMedicine))
            {
                administratedFor.Add(newMedicine);
                newMedicine.AddUsedFor(this);
            }
        }

        /// <summary>
        /// Remove an existing Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveAdministratedFor(Medicine oldMedicine)
        {
            if (oldMedicine == null)
                return;
            if (administratedFor != null)
                if (administratedFor.Contains(oldMedicine))
                {
                    administratedFor.Remove(oldMedicine);
                    oldMedicine.RemoveUsedFor(this);
                }
        }

        /// <summary>
        /// Remove all instances of Medicine from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllAdministratedFor()
        {
            if (administratedFor != null)
            {
                System.Collections.ArrayList tmpAdministratedFor = new System.Collections.ArrayList();
                foreach (Medicine oldMedicine in administratedFor)
                    tmpAdministratedFor.Add(oldMedicine);
                administratedFor.Clear();
                foreach (Medicine oldMedicine in tmpAdministratedFor)
                    oldMedicine.RemoveUsedFor(this);
                tmpAdministratedFor.Clear();
            }
        }
        public System.Collections.ArrayList symptoms;

        /// <summary>
        /// Property for collection of Symptom
        /// </summary>
        /// <pdGenerated>Default opposite class collection property</pdGenerated>
        public System.Collections.ArrayList Symptoms
        {
            get
            {
                if (symptoms == null)
                    symptoms = new System.Collections.ArrayList();
                return symptoms;
            }
            set
            {
                RemoveAllSymptoms();
                if (value != null)
                {
                    foreach (Symptom oSymptom in value)
                        AddSymptoms(oSymptom);
                }
            }
        }

        /// <summary>
        /// Add a new Symptom in the collection
        /// </summary>
        /// <pdGenerated>Default Add</pdGenerated>
        public void AddSymptoms(Symptom newSymptom)
        {
            if (newSymptom == null)
                return;
            if (symptoms == null)
                symptoms = new System.Collections.ArrayList();
            if (!symptoms.Contains(newSymptom))
                symptoms.Add(newSymptom);
        }

        /// <summary>
        /// Remove an existing Symptom from the collection
        /// </summary>
        /// <pdGenerated>Default Remove</pdGenerated>
        public void RemoveSymptoms(Symptom oldSymptom)
        {
            if (oldSymptom == null)
                return;
            if (symptoms != null)
                if (symptoms.Contains(oldSymptom))
                    symptoms.Remove(oldSymptom);
        }

        /// <summary>
        /// Remove all instances of Symptom from the collection
        /// </summary>
        /// <pdGenerated>Default removeAll</pdGenerated>
        public void RemoveAllSymptoms()
        {
            if (symptoms != null)
                symptoms.Clear();
        }

    }
}