using SIMS.Exceptions;
using SIMS.Model.ManagerModel;

namespace SIMS.Service.ValidateServices.ValidateHospitalManagementServices
{
    class ValidateRoomStatistics : IValidateService<StatsRoom>
    {
        public void Validate(StatsRoom entity)
        {
            CheckAppointmentTime(entity.AvgAppointmentTime);
            CheckTimeOccupied(entity.TimeOccupied);
            CheckUsage(entity.Usage); 
        }

        private void CheckUsage(double usage)
        {
            if (usage < 0)
                throw new ServiceException("RoomStatisticsService - Usage is less than zero!");
        }

        private void CheckTimeOccupied(double timeOccupied)
        {
            if (timeOccupied < 0)
                throw new ServiceException("RoomStatisticsService - TimeOccupied is less than zero!");
        }

        private void CheckAppointmentTime(int avgAppointmentTime)
        {
            if (avgAppointmentTime < 0)
                throw new ServiceException("RoomStatisticsService - AvgAppointmentTime is less than zero!");
        }
    }
}
