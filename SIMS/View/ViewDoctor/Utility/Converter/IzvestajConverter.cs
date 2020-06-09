using SIMS.Controller.UsersController;
using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewDoctor.Utility.Converter
{
    class IzvestajConverter
    {
        private Model.UserModel.Patient _selektovaniPacijent;
        Model.PatientModel.Diagnosis _selektovanaDijagnoza;
        public string output;
        public IzvestajConverter(Model.UserModel.Patient selektovaniPacijent, Model.PatientModel.Diagnosis selektovanaDijagnoza)
        {
            _selektovanaDijagnoza = selektovanaDijagnoza;
            _selektovaniPacijent = selektovaniPacijent;
            output = flushToString();
        }

        private string flushToString()
        {
            string retVal = _selektovaniPacijent.Name + " " + _selektovaniPacijent.Surname + "/n/n";
            retVal += _selektovanaDijagnoza.DiagnosedDisease.Name + "/n/n";
            retVal += "Aktivna terapija: /n" + _selektovanaDijagnoza.ActiveTherapy.ToString() + "/n/n";
            retVal += "Prethodne terapije: /n";
            foreach (Therapy therapy in _selektovanaDijagnoza.Therapies)
            {
                retVal += therapy.Prescription.Medicine.ToString() + ", " + therapy.TimeInterval.ToString() + "/n";
            }

            return retVal;
        }
    }
}
