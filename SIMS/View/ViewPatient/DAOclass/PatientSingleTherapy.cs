using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SIMS.Model.PatientModel;
using SIMS.Util;
using SIMS.Model.UserModel;

namespace SIMS.View.ViewPatient.DAOclass
{
    
    public class PatientSingleTherapy
    {
        private Medicine _medicine;
        private TimeInterval _timeInterval;
        private Doctor _doctor;
        private Dictionary<TherapyTime, double> _therapyTime;

      

        public PatientSingleTherapy(Medicine medicine, TimeInterval timeInterval, Dictionary<TherapyTime,double> therapyTime, Doctor doctor)
        {
            _medicine = medicine;
            _timeInterval = timeInterval;
            _therapyTime = therapyTime;
            _doctor = doctor;
        }

        public Medicine Medicine { get => _medicine; set => _medicine = value; }
        public TimeInterval TimeInterval { get => _timeInterval; set => _timeInterval = value; }
        public List<TherapyTime> TherapyTimes
        {
            get
            {
                return _therapyTime.Keys.ToList();
            }
        }

        public double Dosage
        {
            get
            {
                return TherapyTime.Values.ToList()[0];
            }
        }

        public Dictionary<TherapyTime, double> TherapyTime { get => _therapyTime; set => _therapyTime = value; }
        public Doctor Doctor { get => _doctor; set => _doctor = value; }
    }
}
