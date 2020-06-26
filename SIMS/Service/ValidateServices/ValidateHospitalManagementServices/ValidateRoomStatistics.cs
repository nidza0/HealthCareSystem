using SIMS.Exceptions;
using SIMS.Model.ManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateHospitalManagementServices
{
    class ValidateRoomStatistics : IValidateService<StatsRoom>
    {
        public void Validate(StatsRoom entity)
        {
            if(entity.AvgAppointmentTime < 0)
            {
                throw new ServiceException("RoomStatisticsService - AvgAppointmentTime is less than zero!");
            }

            if(entity.TimeOccupied < 0)
            {
                throw new ServiceException("RoomStatisticsService - TimeOccupied is less than zero!");
            }

            if (entity.Usage < 0)
            {
                throw new ServiceException("RoomStatisticsService - Usage is less than zero!");
            }
        }
    }
}
