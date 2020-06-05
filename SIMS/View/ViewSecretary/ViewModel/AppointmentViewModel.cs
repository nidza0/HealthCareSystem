using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewSecretary.ViewModel
{
    class AppointmentViewModel
    {
        private Appointment appointment;

        public Appointment Appointment { get => appointment; set => appointment = value; }

        public AppointmentViewModel(Appointment a)
        {
            GetEagerAppointment();
            appointment = a;
        }

        private void GetEagerAppointment()
        {
            //TODO: Get eager appointment
        }
    }
}
