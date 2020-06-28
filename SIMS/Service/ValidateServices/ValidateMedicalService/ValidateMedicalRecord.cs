using SIMS.Exceptions;
using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateMedicalService
{
    class ValidateMedicalRecord : IValidateService<MedicalRecord>
    {
        public void Validate(MedicalRecord entity)
        {
            if(entity.Patient == null)
            {
                throw new ServiceException("MedicalRecordService - Patient is null");
            }
        }
    }
}
