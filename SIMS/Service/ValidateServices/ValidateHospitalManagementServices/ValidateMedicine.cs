using SIMS.Exceptions;
using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateHospitalManagementServices
{
    class ValidateMedicine : IValidateService<Medicine>
    {
        public void Validate(Medicine entity)
        {

            string namePattern = @"[a-zA-Z0-9\\-\\! ]*";

            if(entity.Strength < 0)
            {
                throw new ServiceException("MedicineService - Strength is less than zero!");
            }

            if(entity.InStock < 0)
            {
                throw new ServiceException("MedicineService - InStock is less than zero!");
            }

            if(entity.MinNumber < 0)
            {
                throw new ServiceException("MedicineService - MinNumber is less than zero!");
            }

            if(!Regex.Match(entity.Name, namePattern).Success)
            {
                throw new ServiceException("MedicineService - Name contains illegal characters!");
            }
        }
    }
}
