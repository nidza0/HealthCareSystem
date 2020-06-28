using SIMS.Exceptions;
using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SIMS.View.ViewSecretary.ViewModel
{
    class AppointmentViewModel : INotifyPropertyChanged
    {
        private Appointment appointment;

        public Appointment Appointment { get => appointment; set => appointment = value; }

        public AppointmentViewModel(Appointment a)
        {
            GetEagerAppointment(a);
        }

        private void GetEagerAppointment(Appointment a)
        {
            appointment = AppResources.getInstance().appointmentController.GetByID(a.GetId());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        internal void CancelAppointment()
        {
            //appointment.Canceled = true;
            //SecretaryAppResources.GetInstance().appointmentRepository.Update(appointment);
            try
            {
                AppResources.getInstance().appointmentController.CancelAppointment(appointment);
            }
            catch(AppointmentServiceException ex)
            {
                MessageBox.Show(ex.Message, "Cancel Appointment Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
