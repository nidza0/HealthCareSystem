using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.HospitalManagementService
{
    class DoctorStatisticsService : IService<StatsDoctor, UserID>
    {

        private DoctorStatisticRepository _doctorStatisticRepository;

        public DoctorStatisticsService(DoctorStatisticRepository doctorStatisticRepository)
        {
            _doctorStatisticRepository = doctorStatisticRepository;
        }

        public StatsDoctor Create(StatsDoctor entity)
            => _doctorStatisticRepository.Create(entity);

        public void Delete(StatsDoctor entity)
            => _doctorStatisticRepository.Delete(entity);

        public IEnumerable<StatsDoctor> GetAll()
            => _doctorStatisticRepository.GetAllEager();

        public StatsDoctor GetByID(UserID id)
            => this.GetAll().SingleOrDefault(stat => stat.GetId().Equals(id));

        public void Update(StatsDoctor entity)
            => _doctorStatisticRepository.Update(entity);
    }
}
