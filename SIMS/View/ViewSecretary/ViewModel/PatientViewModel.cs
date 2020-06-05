using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewSecretary.ViewModel
{
    class PatientViewModel
    {
        private Patient patient;

        public Patient Patient { get => patient; set => patient = value; }

        public PatientViewModel(Patient p)
        {
            GetEagerPatient();
            patient = p;
        }

        private void GetEagerPatient()
        {
            //TODO: Get patient with selected doctor
        }

    }
}
