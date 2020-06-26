using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;
using SIMS.Service.ValidateServices;
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
        {
            // TODO: Validate
            _doctorStatisticRepository.Create(entity);
            return entity;
        }
        public void Delete(StatsDoctor entity)
            => _doctorStatisticRepository.Delete(entity);

        public IEnumerable<StatsDoctor> GetAll()
            => _doctorStatisticRepository.GetAllEager();

        public StatsDoctor GetByID(UserID id)
            => this.GetAll().SingleOrDefault(stat => stat.GetId().Equals(id));

        public void Update(StatsDoctor entity)
        {
            // TODO: Validate
            _doctorStatisticRepository.Update(entity);
        }

        public void Validate(StatsDoctor entity)
        {
            throw new NotImplementedException();
        }
    }
}
