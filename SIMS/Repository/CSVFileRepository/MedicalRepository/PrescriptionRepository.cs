using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.MedicalAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository.CSVFileRepository.MedicalRepository
{
    public class PrescriptionRepository : CSVRepository<Prescription, long>, IPrescriptionRepository, IEagerCSVRepository<Prescription, long>
    {
        public PrescriptionRepository(string entityName, ICSVStream<Prescription> stream, ISequencer<long> sequencer) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Prescription>())
        {
        }

        public IEnumerable<Prescription> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public Prescription GetEager(long id)
        {
            throw new NotImplementedException();
        }
    }
}
