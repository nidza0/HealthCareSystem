using SIMS.Exceptions;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateMiscService
{
    class ValidateLocation : IValidateService<Location>
    {
        public void Validate(Location entity)
        {
            string namingPattern = @"[a-zA-Z\\- ]*";
            if(!Regex.Match(entity.City, namingPattern).Success)
            {
                throw new ServiceException("LocationService - City contains illegal characters!");
            }

            if (!Regex.Match(entity.Country, namingPattern).Success)
            {
                throw new ServiceException("LocationService - Country contains illegal characters!");
            }
        }
    }
}
