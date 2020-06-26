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
    class InventoryStatisticsService : IService<StatsInventory, long>
    {

        private InventoryStatisticsRepository _inventoryStatisticsRepository;

        public InventoryStatisticsService(InventoryStatisticsRepository inventoryStatisticsRepository)
        {
            _inventoryStatisticsRepository = inventoryStatisticsRepository;
        }

        public StatsInventory Create(StatsInventory entity)
        {
            // TODO: Validate
            return _inventoryStatisticsRepository.Create(entity);
        }

        public void Delete(StatsInventory entity)
            => _inventoryStatisticsRepository.Delete(entity);

        public IEnumerable<StatsInventory> GetAll()
            => _inventoryStatisticsRepository.GetAllEager();

        public StatsInventory GetByID(long id)
            => this.GetAll().SingleOrDefault(stat => stat.GetId() == id);

        public void Update(StatsInventory entity)
        {
            // TODO: Validate
            _inventoryStatisticsRepository.Update(entity);
        }

        public void Validate(StatsInventory entity)
        {
            throw new NotImplementedException();
        }
    }
}
