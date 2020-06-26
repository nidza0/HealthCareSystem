using SIMS.Exceptions;
using SIMS.Model.ManagerModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service.ValidateServices.ValidateHospitalManagementServices
{
    class ValidateInventoryStatistics : IValidateService<StatsInventory>
    {
        public void Validate(StatsInventory entity)
        {
            if(entity.Usage < 0)
            {
                throw new ServiceException("InventoryStatisticsService - usage is less than zero!");
            }

            
        }
    }
}
