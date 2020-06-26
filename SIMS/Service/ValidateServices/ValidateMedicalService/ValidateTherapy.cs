using SIMS.Exceptions;
using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateMedicalService
{
    class ValidateTherapy : IValidateService<Therapy>
    {
        public void Validate(Therapy entity)
        {
            if(entity.TimeInterval.StartTime.Ticks > entity.TimeInterval.EndTime.Ticks)
            {
                throw new ServiceException("TherapyService - EndTime is before StartTime");
            }
        }
    }
}
