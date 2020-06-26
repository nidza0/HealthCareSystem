using SIMS.Model.ManagerModel;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;
using SIMS.Service.ValidateServices.ValidateHospitalManagementServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.HospitalManagementService
{
    public class RoomStatisticsService : IService<StatsRoom, long>
    {
        private RoomStatisticsRepository _roomStatisticsRepository;
        private ValidateRoomStatistics _validateRoomStatistics;

        public RoomStatisticsService(RoomStatisticsRepository roomStatisticsRepository)
        {
            _roomStatisticsRepository = roomStatisticsRepository;
        }

        public StatsRoom Create(StatsRoom entity)
        {
            Validate(entity);
            return _roomStatisticsRepository.Create(entity);
        }

        public void Delete(StatsRoom entity)
            => _roomStatisticsRepository.Delete(entity);

        public IEnumerable<StatsRoom> GetAll()
            => _roomStatisticsRepository.GetAllEager();

        public StatsRoom GetByID(long id)
            => this.GetAll().SingleOrDefault(stat => stat.GetId() == id);

        public void Update(StatsRoom entity)
        {
            Validate(entity);
            _roomStatisticsRepository.Update(entity);
        }

        public void Validate(StatsRoom entity)
        {
            _validateRoomStatistics.Validate(entity);
        }
    }
}
