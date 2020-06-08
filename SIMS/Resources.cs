using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter;
using SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;
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
        private readonly String timeTableFile = @"Files\HospitalManagementFiles\timeTables.txt";
        private readonly String hospitalFile = @"Files\HospitalManagementFiles\hospitals.txt";
        private readonly String roomFile = @"Files\HospitalManagementFiles\rooms.txt";
        private readonly String inventoryItemFile = @"Files\HospitalManagementFiles\inventoryItems.txt";

        private static Resources instance = null;

        public UserRepository userRepository;
        public DoctorRepository doctorRepository;
        public PatientRepository patientRepository;
        public ManagerRepository managerRepository;
        public SecretaryRepository secretaryRepository;
        public TimeTableRepository timeTableRepository;
        public HospitalRepository hospitalRepository;
        public RoomRepository roomRepository;
        public InventoryItemRepository inventoryItemRepository;

        private Resources() {
            userRepository = new UserRepository(new CSVStream<User>(userFile, new UserConverter()), new ComplexSequencer());


            inventoryItemRepository = new InventoryItemRepository(new CSVStream<InventoryItem>(inventoryItemFile, new InventoryItemConverter()), new LongSequencer(), roomRepository);
            roomRepository = new RoomRepository(new CSVStream<Room>(roomFile, new RoomConverter()), new LongSequencer());
            timeTableRepository = new TimeTableRepository(new CSVStream<TimeTable>(timeTableFile, new TimeTableConverter()), new LongSequencer());
            hospitalRepository = new HospitalRepository(new CSVStream<Hospital>(hospitalFile, new HospitalConverter()), new LongSequencer(), roomRepository);


            secretaryRepository = new SecretaryRepository(new CSVStream<Secretary>(managerFile, new SecretaryConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, userRepository);
            managerRepository = new ManagerRepository(new CSVStream<Manager>(managerFile, new ManagerConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, userRepository);
            doctorRepository = new DoctorRepository(new CSVStream<Doctor>(doctorFile, new DoctorConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, roomRepository, userRepository);
            patientRepository = new PatientRepository(new CSVStream<Patient>(patientFile, new PatientConverter()), new ComplexSequencer(), doctorRepository, userRepository);
            
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
