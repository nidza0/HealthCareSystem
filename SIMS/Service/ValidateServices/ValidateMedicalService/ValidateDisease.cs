using SIMS.Exceptions;
using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateMedicalService
{
    class ValidateDisease : IValidateService<Disease>
    {
        public void Validate(Disease entity)
        {
            string namePattern = @"[a-zA-Z0-9\\- ]*";
            if(!Regex.Match(entity.Name, namePattern).Success)
            {
                throw new ServiceException("DiseaseService - Name contains illegal characters");
            }
        }
    }
}
