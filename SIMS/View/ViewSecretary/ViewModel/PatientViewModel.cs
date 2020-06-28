using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewSecretary.ViewModel
{
    public class PatientViewModel
    {
        private Patient patient;

        public Patient Patient { get => patient; set => patient = value; }

        public PatientViewModel()
        {
            patient = new Patient("", "", "", "", "", Sex.MALE, DateTime.Now, "", new Address("", null), "", "", "", "", new EmergencyContact(), PatientType.GUEST, null);
        }

        public PatientViewModel(Patient p)
        {
            GetEagerPatient(p);
        }

        private void GetEagerPatient(Patient p)
        {
            patient = AppResources.getInstance().patientController.GetByID(p.GetId());
        }

    }
}
