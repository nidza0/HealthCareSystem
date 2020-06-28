using SIMS.Exceptions;
using SIMS.Model.UserModel;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateHospitalManagementServices
{
    class ValidateHospital : IValidateService<Hospital>
    {

        public void Validate(Hospital hospital)
        {
            string phonePattern = Regexes.phoneRegex;

            // TODO: Mozda implementirati REGEX
            if (hospital.Name.Length == 0)
            {
                throw new ServiceException("Hospital Service - Name is not valid!");
            }

            if(!Regex.Match(hospital.Telephone, phonePattern).Success)
            {
                throw new ServiceException("Hospital Service - Telephone is not valid!");
            }
        }
    }
}
