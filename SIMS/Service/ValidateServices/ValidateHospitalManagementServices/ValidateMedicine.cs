using SIMS.Exceptions;
using SIMS.Model.PatientModel;
using SIMS.Util;
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
            CheckStrength(entity.Strength);
            CheckInStock(entity.InStock);
            CheckMinNumber(entity.MinNumber);
            CheckName(entity.Name);
        }

        private void CheckName(string name)
        {
            if (!Regex.Match(name, Regexes.medicineNamePattern).Success)
                throw new ServiceException("MedicineService - Name contains illegal characters!");
        }

        private void CheckMinNumber(int minNumber)
        {
            if (minNumber < 0)
                throw new ServiceException("MedicineService - MinNumber is less than zero!");
        }

        private void CheckInStock(int inStock)
        {
            if (inStock < 0)
                throw new ServiceException("MedicineService - InStock is less than zero!");
        }

        private void CheckStrength(double strength)
        {
            if (strength < 0)
                throw new ServiceException("MedicineService - Strength is less than zero!"); 
        }

    }
}
