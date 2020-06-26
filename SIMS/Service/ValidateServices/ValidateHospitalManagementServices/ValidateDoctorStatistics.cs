using SIMS.Exceptions;
using SIMS.Model.ManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices
{
    class ValidateDoctorStatistics : IValidateService<StatsDoctor>
    {
        public void Validate(StatsDoctor statsDoctor)
        {
            if(statsDoctor.NumberOfAppointments < 0)
            {
                throw new ServiceException("DoctorStatistics - Average appointment number is less than zero!");
            }

            if(statsDoctor.Doctor == null)
            {
                throw new ServiceException("DoctorStatistics - Doctor is not set!");
            }
        }

    }
}
