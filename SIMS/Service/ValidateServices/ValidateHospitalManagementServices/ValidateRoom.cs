using SIMS.Exceptions;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateHospitalManagementServices
{
    class ValidateRoom : IValidateService<Room>
    {
        public void Validate(Room entity)
        {

            string numberPattern = @"[a-zA-Z0-9\\- ]*";

            if(entity.Floor < 0)
            {
                throw new ServiceException("RoomService - Floor is less than zero!");
            }

            if(!Regex.Match(entity.RoomNumber, numberPattern).Success)
            {
                throw new ServiceException("RoomService - RoomNumber contains illegal characters!");
            }
        }
    }
}
