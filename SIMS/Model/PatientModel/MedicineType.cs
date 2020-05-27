/***********************************************************************
 * Module:  MedicineType.cs
 * Author:  nikola
 * Purpose: Definition of the Class MedicineType
 ***********************************************************************/

using System;

namespace SIMS.Model.PatientModel
{
    public enum MedicineType
    {
        Pill,
        Iv,
        Liquid,
        Tablet,
        TopicalMedicine,
        Drops,
        Suppositories,
        Inhalers,
        Injections
    }
}