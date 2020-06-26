using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Util
{
    class RecommendationDTO
    {
        private TimeInterval _doctorShift;
        private List<Appointment> _takenAppointments;

        public RecommendationDTO(TimeInterval doctorShift, List<Appointment> takenAppointments)
        {
            _doctorShift = doctorShift;
            _takenAppointments = takenAppointments;
        }

        public TimeInterval DoctorShift { get => _doctorShift; set => _doctorShift = value; }
        public List<Appointment> TakenAppointments { get => _takenAppointments; set => _takenAppointments = value; }
    }
}
