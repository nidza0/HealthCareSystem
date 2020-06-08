using SIMS.Model.UserModel;
using SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS
{
    class Resources
    {
        private readonly String userFile = @"Files\UserFiles\users.txt";
        private readonly String patientFile = @"Files\UserFiles\patients.txt";
        private readonly String doctorFile = @"Files\UserFiles\doctors.txt";
        private readonly String managerFile = @"Files\UserFiles\managers.txt";


        private static Resources instance = null;

        public UserRepository userRepository;
        public DoctorRepository doctorRepository;
        public PatientRepository patientRepository;
        public ManagerRepository managerRepository;
        public SecretaryRepository secretaryRepository;

        private Resources() {
            userRepository = new UserRepository(new CSVStream<User>(userFile, new UserConverter()), new ComplexSequencer());

            /*
            secretaryRepository = new SecretaryRepository(new CSVStream<Secretary>(managerFile, new SecretaryConverter()), new ComplexSequencer(), TimeTable, Hospital, userRepository);
            managerRepository = new ManagerRepository(new CSVStream<Manager>(managerFile, new ManagerConverter()), new ComplexSequencer(), TimeTable, Hospital, userRepository);
            doctorRepository = new DoctorRepository(new CSVStream<Doctor>(doctorFile, new DoctorConverter()), new ComplexSequencer(), TimeTable, Hospital, Room, userRepository);
            patientRepository = new PatientRepository(new CSVStream<Patient>(patientFile, new PatientConverter()), new ComplexSequencer(), doctorRepository, userRepository);
            */
        }

        public static Resources getInstance()
        {
            if(instance == null)
            {
                instance = new Resources();
            }

            return instance;
        }
    }
}
