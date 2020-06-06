using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;

//CSVRepository<Stats, long>, IStatisticsRepository, IEagerCSVRepository<Stats, long>

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    class TimeTableRepository : CSVRepository<TimeTable, long>, ITimeTableRepository, IEagerCSVRepository<TimeTable, long>
    {
        public IEnumerable<TimeTable> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public TimeTable GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}
