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
using SIMS.Model.DoctorModel;

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
        private readonly String notificationFile = @"..\..\Files\MiscFiles\notifications.txt";
        private readonly String messageFile = @"..\..\Files\MiscFiles\messages.txt";
        private readonly String articleFile = @"..\..\Files\MiscFiles\articles.txt";
        private readonly String questionFile = @"..\..\Files\MiscFiles\questions.txt";
        private readonly String doctorQuestionFile = @"..\..\Files\MiscFiles\doctorQuestions.txt";
        private readonly String feedbackFile = @"..\..\Files\MiscFiles\feedbacks.txt";
        private readonly String doctorFeedbackFile = @"..\..\Files\MiscFiles\doctorFeedbacks.txt";

     

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
        public NotificationRepository notificationRepository;
        public MessageRepository messageRepository;
        public ArticleRepository articleRepository;
        public QuestionRepository questionRepository;
        public QuestionRepository doctorQuestionRepository;
        public FeedbackRepository feedbackRepository;
        public DoctorFeedbackRepository doctorFeedbackRepository;


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
            // USER OK

            inventoryItemRepository = new InventoryItemRepository(new CSVStream<InventoryItem>(inventoryItemFile, new InventoryItemConverter()), new LongSequencer(), roomRepository);
            roomRepository = new RoomRepository(new CSVStream<Room>(roomFile, new RoomConverter()), new LongSequencer());
            // ROOM OK
            timeTableRepository = new TimeTableRepository(new CSVStream<TimeTable>(timeTableFile, new TimeTableConverter()), new LongSequencer());
            // TIMETABLE OK
            hospitalRepository = new HospitalRepository(new CSVStream<Hospital>(hospitalFile, new HospitalConverter()), new LongSequencer(), roomRepository);
            // HOSPITAL OK

            secretaryRepository = new SecretaryRepository(new CSVStream<Secretary>(secretaryFile, new SecretaryConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, userRepository);
            // SECRETARY OK
            managerRepository = new ManagerRepository(new CSVStream<Manager>(managerFile, new ManagerConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, userRepository);
            // MANAGER OK
            doctorRepository = new DoctorRepository(new CSVStream<Doctor>(doctorFile, new DoctorConverter()), new ComplexSequencer(), timeTableRepository, hospitalRepository, roomRepository, userRepository);
            // DOCTOR OK
            patientRepository = new PatientRepository(new CSVStream<Patient>(patientFile, new PatientConverter()), new ComplexSequencer(), doctorRepository, userRepository);
            // PATIENT OK

            hospitalRepository.DoctorRepository = doctorRepository;
            hospitalRepository.ManagerRepository = managerRepository;
            hospitalRepository.SecretaryRepository = secretaryRepository;
            
            
            //Misc repositories
            locationRepository = new LocationRepository(new CSVStream<Location>(locationFile, new LocationConverter()), new LongSequencer());
            // LOCATION OK
            notificationRepository = new NotificationRepository(new CSVStream<Notification>(notificationFile, new NotificationConverter()), new LongSequencer(), patientRepository, doctorRepository, managerRepository, secretaryRepository);
            // NOTIFICATION OK
            messageRepository = new MessageRepository(new CSVStream<Message>(messageFile, new MessageConverter()), new LongSequencer(), patientRepository, doctorRepository, managerRepository, secretaryRepository);
            // MESSAGE OK
            articleRepository = new ArticleRepository(new CSVStream<Article>(articleFile, new ArticleConverter()), new LongSequencer(), doctorRepository, managerRepository, secretaryRepository);
            //ARTICLE OK
            questionRepository = new QuestionRepository(new CSVStream<Question>(questionFile, new QuestionConverter()), new LongSequencer());
            // QUESTION OK
            doctorQuestionRepository = new QuestionRepository(new CSVStream<Question>(doctorQuestionFile, new QuestionConverter()), new LongSequencer());
            //DOCTOR QUESTION OK
            feedbackRepository = new FeedbackRepository(new CSVStream<Feedback>(feedbackFile, new FeedbackConverter()), new LongSequencer(), questionRepository, patientRepository, doctorRepository, managerRepository, secretaryRepository);
            doctorFeedbackRepository = new DoctorFeedbackRepository(new CSVStream<DoctorFeedback>(doctorFeedbackFile, new DoctorFeedbackConverter()), new LongSequencer(), doctorQuestionRepository, patientRepository, doctorRepository);


            //Hospital management repositories
            symptomRepository = new SymptomRepository(new CSVStream<Symptom>(symptomsFile, new SymptomConverter()), new LongSequencer());
            //SYMPTOM REPO OK
            diseaseRepository = new DiseaseRepository(new CSVStream<Disease>(diseaseFile, new DiseaseConverter()), new LongSequencer(), medicineRepository, symptomRepository);
            //DISEASE REPO OK
            ingredientRepository = new IngredientRepository(new CSVStream<Ingredient>(ingredientFile, new IngredientConverter()), new LongSequencer());
            //INGREDIENT REPO OK
            medicineRepository = new MedicineRepository(new CSVStream<Medicine>(medicineFile, new MedicineConverter()), new LongSequencer(), ingredientRepository, diseaseRepository);
            //MEDICINE REPO OK


            prescriptionRepository = new PrescriptionRepository(new CSVStream<Prescription>(prescriptionFile, new PrescriptionConverter()), new LongSequencer(),doctorRepository,medicineRepository);
            //PRESCRIPTION REPO OK

            //Medical repositories

            allergyRepository = new AllergyRepository(new CSVStream<Allergy>(allergyFile, new AllergyConverter()), new LongSequencer(), ingredientRepository, symptomRepository);
            //ALLERGY REPO OK
           
            appointmentRepository = new AppointmentRepository(new CSVStream<Appointment>(appointmentsFile, new AppointmentConverter()), new LongSequencer(), patientRepository, doctorRepository,roomRepository);
            //GERGO REPO OK?
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
