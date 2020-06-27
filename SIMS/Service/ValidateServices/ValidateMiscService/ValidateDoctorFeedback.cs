using SIMS.Exceptions;
using SIMS.Model.DoctorModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateMiscService
{
    class ValidateDoctorFeedback : IValidateService<DoctorFeedback>
    {
        public void Validate(DoctorFeedback entity)
        {
            if(entity.Doctor == null)
            {
                throw new ServiceException("DoctorFeedbackService - Doctor is null!");
            }
        }
    }
}
