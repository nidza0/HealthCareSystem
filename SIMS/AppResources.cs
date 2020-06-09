using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using SIMS.Repository.CSVFileRepository.Csv.Converter.HospitalManagementConverter;
using SIMS.Repository.CSVFileRepository.Csv.Converter.UsersConverter;
using SIMS.Repository.CSVFileRepository.Csv.Converter.MedicalConverter;

using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.CSVFileRepository.HospitalManagementRepository;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.Repository.CSVFileRepository.MedicalRepository;
using SIMS.Repository.Sequencer;
using SIMS.Model.PatientModel;
using System;
using SIMS.Repository.CSVFileRepository.MiscRepository;
using SIMS.Repository.CSVFileRepository.Csv.Converter.MiscConverter;

namespace SIMS
{
    class AppResources
    {
        //Hospital management files
        private readonly String userFile = @"..\..\Files\UserFiles\users.txt";
        private readonly String patientFile = @"..\..\Files\UserFiles\patients.txt";
        private readonly String doctorFile = @"..\..\Files\UserFiles\doctors.txt";
        private readonly String managerFile = @"..\..\Files\UserFiles\managers.txt";
        private readonly String secretaryFile = @"..\..\Files\UserFiles\secretaries.txt";
        private readonly String timeTableFile = @"..\..\Files\HospitalManagementFiles\timeTables.txt";
        private readonly String hospitalFile = @"..\..\Files\HospitalManagementFiles\hospitals.txt";
        private readonly String roomFile = @"..\..\Files\HospitalManagementFiles\rooms.txt";
        private readonly String medicineFile = @"..\..\Files\HospitalManagementFiles\medicines.txt";
        private readonly String inventoryItemFile = @"..\..\Files\HospitalManagementFiles\inventoryItems.txt";

        //MiscFiles
        private readonly String locationFile = @"..\..\Files\MiscFiles\locations.txt";

     

        //Medical repository files
        private readonly String allergyFile = @"..\..\Files\MedicalFiles\allergies.txt";
        private readonly String appointmentsFile = @"..\..\Files\MedicalFiles\appointments.txt";
        private readonly String diagnosisFile = @"..\..\Files\MedicalFiles\diagnosis.txt";
        private readonly String diseaseFile = @"..\..\Files\MedicalFiles\diseases.txt";
        private readonly String ingredientFile = @"..\..\Files\MedicalFiles\ingredients.txt";
        private readonly String medicalRecordFile = @"..\..\Files\MedicalFiles\medicalRecords.txt";
        private readonly String prescriptionFile = @"..\..\Files\MedicalFiles\prescriptions.txt";
        private readonly String symptomsFile = @"..\..\Files\MedicalFiles\symptoms.txt";
        private readonly String therapyFile = @"..\..\Files\MedicalFiles\therapies.txt";

        private static AppResources instance = null;

        public UserRepository userRepository;
        public DoctorRepository doctorRepository;
        public PatientRepository patientRepository;
        public ManagerRepository managerRepository;
        public SecretaryRepository secretaryRepository;
        public TimeTableRepository timeTableRepository;
        public HospitalRepository hospitalRepository;
        public RoomRepository roomRepository;
        public InventoryItemRepository inventoryItemRepository;

        //Misc repositories
        public LocationRepository locationRepository;


        //Hospital management
        public MedicineRepository medicineRepository;

        //Medical repositories
        public AllergyRepository allergyRepository;
        public AppointmentRepository appointmentRepository;
        public DiagnosisRepository diagnosisRepository;
        public DiseaseRepository diseaseRepository;
        public IngredientRepository ingredientRepository;
        public MedicalRecordRepository medicalRecordRepository;
        public PrescriptionRepository prescriptionRepository;
        public SymptomRepository symptomRepository;
        public TherapyRepository therapyRepository;

        private AppResources() {
            userRepository = new UserRepository(new CSVStream<User>(userFile, new UserConverter()), new ComplexSequencer());


            inventoryItemRepository = new InventoryItemRepository(new CSVStream<InventoryItem>(inventoryItemFile, new InventoryItemConverter()), new LongSequencer(), roomRepository);
            roomRepository = new RoomRepository(new CSVStream<Room>(roomFile, new RoomConverter()), new LongSequencer());
            timeTableRepository = new TimeTableRepository(new CSVStream<TimeTable>(timeTableFile, new TimeTableConverter()), new LongSequencer());
            hospitalRepository = new HospitalRepository(new CSVStream<Hospital>(hospitalFile, new HospitalConverter()), new LongSequencer(), roomRepository);


            secretaryRepository = new SecretaryRepository(new CSVStream<Secretary>(secretaryFile, new SecretaryConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, userRepository);
            managerRepository = new ManagerRepository(new CSVStream<Manager>(managerFile, new ManagerConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, userRepository);
            doctorRepository = new DoctorRepository(new CSVStream<Doctor>(doctorFile, new DoctorConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, roomRepository, userRepository);
            patientRepository = new PatientRepository(new CSVStream<Patient>(patientFile, new PatientConverter()), new ComplexSequencer(), doctorRepository, userRepository);

            //Misc repositories
            locationRepository = new LocationRepository(new CSVStream<Location>(locationFile, new LocationConverter()), new LongSequencer());

            //Hospital management repositories
            symptomRepository = new SymptomRepository(new CSVStream<Symptom>(symptomsFile, new SymptomConverter()), new LongSequencer());
            diseaseRepository = new DiseaseRepository(new CSVStream<Disease>(diseaseFile, new DiseaseConverter()), new LongSequencer(), medicineRepository, symptomRepository);
            ingredientRepository = new IngredientRepository(new CSVStream<Ingredient>(ingredientFile, new IngredientConverter()), new LongSequencer());
            medicineRepository = new MedicineRepository(new CSVStream<Medicine>(medicineFile, new MedicineConverter()), new LongSequencer(), ingredientRepository, diseaseRepository);
            //checked


            prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(prescriptionFile, new PrescriptionConverter()), new LongSequencer(),doctorRepository,medicineRepository);
            //Medical repositories
           //checked
            
            allergyRepository = new AllergyRepository(new CSVStream<Allergy>(allergyFile, new AllergyConverter()), new LongSequencer(), ingredientRepository, symptomRepository);

           
            appointmentRepository = new AppointmentRepository(new CSVStream<Appointment>(appointmentsFile, new AppointmentConverter()), new LongSequencer(), patientRepository, doctorRepository,roomRepository);
            //checked
            therapyRepository = new TherapyRepository(new CSVStream<Therapy>(therapyFile, new TherapyConverter()), new LongSequencer(), medicalRecordRepository, medicalRecordRepository, prescriptionRepository, diagnosisRepository);

            //med record
            medicalRecordRepository = new MedicalRecordRepository(new CSVStream<MedicalRecord>(medicalRecordFile, new MedicalRecordConverter()), new LongSequencer(), patientRepository, diagnosisRepository, allergyRepository);
            //u medical record moras da set diagnosis repo
            diagnosisRepository = new DiagnosisRepository(new CSVStream<Diagnosis>(diagnosisFile, new DiagnosisConverter()), new LongSequencer(), therapyRepository, diseaseRepository,medicalRecordRepository);
            //therapy
            // therapyRepository = new TherapyRepository(new CSVStream<Therapy>(therapyFile,new TherapyConverter()),new LongSequencer(),medicalRecordRepository, )

            diseaseRepository.MedicineEagerCSVRepository = medicineRepository;
            medicineRepository.DiseaseRepository = diseaseRepository;

            medicalRecordRepository.DiagnosisRepository = diagnosisRepository;
            diagnosisRepository.MedicalRecordRepository = medicalRecordRepository;
            diagnosisRepository.TherapyEagerCSVRepository = therapyRepository;
            therapyRepository.DiagnosisCSVRepository = diagnosisRepository;
            therapyRepository.MedicalRecordRepository = medicalRecordRepository;
            therapyRepository.MedicalRecordEagerCSVRepository = medicalRecordRepository;



            //ODAVDDE RADITI OSTALE
        }

        public static AppResources getInstance()
        {
            if(instance == null)
            {
                instance = new AppResources();
            }

            return instance;
        }
    }
}
