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
    class ValidateRoom : IValidateService<Room>
    {
        public void Validate(Room entity)
        {
            CheckFloorNumber(entity.Floor);
            CheckRoomNumber(entity.RoomNumber);
        }

        private void CheckRoomNumber(string roomNumber)
        {
            if (!Regex.Match(roomNumber, Regexes.roomNumberPattern).Success)
                throw new ServiceException("RoomService - RoomNumber contains illegal characters!");
        }

        private void CheckFloorNumber(int floor)
        {
            if (floor < 0)
                throw new ServiceException("RoomService - Floor is less than zero!");
        }
    }
}
