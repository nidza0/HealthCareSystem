using System;
using System.Collections.Generic;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;

//CSVRepository<Stats, long>, IStatisticsRepository, IEagerCSVRepository<Stats, long>

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class TimeTableRepository : CSVRepository<TimeTable, long>, ITimeTableRepository
    {
        public TimeTableRepository(string entityName, ICSVStream<TimeTable> stream, ISequencer<long> sequencer, IIdGeneratorStrategy<TimeTable, long> idGeneratorStrategy) : base(entityName, stream, sequencer, idGeneratorStrategy)
        {
        }

        
    }
}
