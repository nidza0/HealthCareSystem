using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Util;
using SIMS.View.ViewSecretary.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SIMS.View.ViewSecretary
{
    /// <summary>
    /// Interaction logic for MainSecretary.xaml
    /// </summary>
    public partial class MainSecretary : Window
    {
        public MainSecretary()
        {
            InitializeComponent();
            SecretaryAppResources.GetInstance();
            FrameManager.getInstance().MainFrame = MainFrame;
            //MakeTimeTables();
            //MakeDoctors();
            //MakePatients();
            MainFrame.Navigate(new LoginPage());
            //MainFrame.Navigate(new FlowDoc());
        }

        private void MakeTimeTables()
        {
            Dictionary<WorkingDaysEnum, TimeInterval> shift1 = new Dictionary<WorkingDaysEnum, TimeInterval>();
            shift1.Add(WorkingDaysEnum.MONDAY, new TimeInterval(new DateTime(2020, 1, 1, 8, 0, 0), new DateTime(2020, 1, 1, 14, 0, 0)));
            shift1.Add(WorkingDaysEnum.TUESDAY, new TimeInterval(new DateTime(2020, 1, 1, 12, 0, 0), new DateTime(2020, 1, 1, 18, 0, 0)));
            shift1.Add(WorkingDaysEnum.WEDNESDAY, new TimeInterval(new DateTime(2020, 1, 1, 8, 0, 0), new DateTime(2020, 1, 1, 14, 0, 0)));
            shift1.Add(WorkingDaysEnum.THURSDAY, new TimeInterval(new DateTime(2020, 1, 1, 12, 0, 0), new DateTime(2020, 1, 1, 18, 0, 0)));
            shift1.Add(WorkingDaysEnum.FRIDAY, new TimeInterval(new DateTime(2020, 1, 1, 8, 0, 0), new DateTime(2020, 1, 1, 14, 0, 0)));

            Dictionary<WorkingDaysEnum, TimeInterval> shift2 = new Dictionary<WorkingDaysEnum, TimeInterval>();
            shift2.Add(WorkingDaysEnum.MONDAY, new TimeInterval(new DateTime(2020, 1, 1, 12, 0, 0), new DateTime(2020, 1, 1, 18, 0, 0)));
            shift2.Add(WorkingDaysEnum.TUESDAY, new TimeInterval(new DateTime(2020, 1, 1, 8, 0, 0), new DateTime(2020, 1, 1, 14, 0, 0)));
            shift2.Add(WorkingDaysEnum.WEDNESDAY, new TimeInterval(new DateTime(2020, 1, 1, 12, 0, 0), new DateTime(2020, 1, 1, 18, 0, 0)));
            shift2.Add(WorkingDaysEnum.THURSDAY, new TimeInterval(new DateTime(2020, 1, 1, 8, 0, 0), new DateTime(2020, 1, 1, 14, 0, 0)));
            shift2.Add(WorkingDaysEnum.FRIDAY, new TimeInterval(new DateTime(2020, 1, 1, 12, 0, 0), new DateTime(2020, 1, 1, 18, 0, 0)));

            TimeTable t1 = new TimeTable(shift1);
            TimeTable t2 = new TimeTable(shift2);
            TimeTable t3 = new TimeTable(shift1);
            TimeTable t4 = new TimeTable(shift2);
            TimeTable t5 = new TimeTable(shift1);
            TimeTable t6 = new TimeTable(shift2);
            TimeTable t7 = new TimeTable(shift1);

            SecretaryAppResources.GetInstance().timeTableRepository.Create(t1);
            SecretaryAppResources.GetInstance().timeTableRepository.Create(t2);
            SecretaryAppResources.GetInstance().timeTableRepository.Create(t3);
            SecretaryAppResources.GetInstance().timeTableRepository.Create(t4);
            SecretaryAppResources.GetInstance().timeTableRepository.Create(t5);
            SecretaryAppResources.GetInstance().timeTableRepository.Create(t6);
            SecretaryAppResources.GetInstance().timeTableRepository.Create(t7);
        }

        private void MakePatients()
        {
            
            Patient p1 = new Patient("pera12", "perapasswd", "Pera", "Perić", "P.", Sex.MALE, new DateTime(1978, 4, 6), "06049784512874", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021745896352", "0685421542", "pera@email.com", "", new EmergencyContact("Milan", "Milanović", "", "06412585432"), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d2")));
            Patient p2 = new Patient("milica12", "ishdkjbck", "Milica", "Milić", "", Sex.FEMALE, new DateTime(1989, 2, 7), "0702989651215468", new Address("Ulica broj", new Location(642, "Serbia", "Beograd")), "011548432181", "0685421542", "milica@email.com", "", new EmergencyContact(), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d3")));
            Patient p3 = new Patient("milee", "soihurhee", "Milan", "Milanović", "M.", Sex.MALE, new DateTime(1987, 6, 25), "560451021515122", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021745896352", "0685421542", "milan@email.com", "", new EmergencyContact("Emilija", "Milanović", "", "0658116843218"), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d3")));
            Patient p4 = new Patient("norbert4332", "ksjnskjbkd", "Norbert", "Molnar", "", Sex.MALE, new DateTime(1997, 2, 18), "054684864132184", new Address("Ulica broj", new Location(673, "Serbia", "Subotica")), "02442185156", "061218403464", "norb@email.com", "", new EmergencyContact("Milan", "Milanovic", "", "06412585432"), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d4")));
            Patient p5 = new Patient("dragana45", "udoshbdkjkdb", "Dragana", "Dragić", "M.", Sex.FEMALE, new DateTime(1993, 4, 6), "874214846545", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021745896352", "0685421542", "dragana412@email.com", "", new EmergencyContact("Milan", "Milanovic", "", "06412585432"), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d3")));
            Patient p6 = new Patient("jovana", "jdhsnmbdu", "Jovana", "Jovanović", "P.", Sex.FEMALE, new DateTime(1991, 4, 6), "546131538468", new Address("Ulica broj", new Location(642, "Serbia", "Beograd")), "021745896352", "0685421542", "pera@email.com", "", new EmergencyContact("Milan", "Milanovic", "", "06412585432"), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d4")));
            Patient p7 = new Patient("jovan78", "jsichdkjcbdkjc", "Jovan", "Jovanović", "P.", Sex.MALE, new DateTime(1993, 4, 6), "5451214012150", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021745896352", "0685421542", "pera@email.com", "", new EmergencyContact("Milan", "Milanovic", "", "06412585432"), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d2")));
            Patient p8 = new Patient("coolestguy", "sldjiuiy38kjkjk", "X Æ A-Xii", "", "", Sex.OTHER, new DateTime(2020, 4, 6), "0540211000000450", new Address("Ulica broj", new Location(831, "United States", "Los Angeles")), "09846804351", "435051542545", "xaeaxii@email.com", "", new EmergencyContact("Elon", "Musk", "", ""), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d2")));
            Patient p9 = new Patient("nidza", "jdhkjdbk", "Nikola", "Dragić", "", Sex.MALE, new DateTime(1998, 4, 6), "06049784512874", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021745896352", "0685421542", "dragicc@email.com", "", new EmergencyContact("Milan", "Milanovic", "", "06412585432"), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d3")));
            Patient p10 = new Patient("noraa475", "sjihdvwhj", "Nora", "Norić", "V.", Sex.FEMALE, new DateTime(1980, 4, 6), "05184545428", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021745896352", "0685421542", "pera@email.com", "", new EmergencyContact("Milan", "Milanovic", "", "06412585432"), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d3")));
            Patient p11 = new Patient("marija014", "jidhkjbdwm", "Marija", "Kukić", "", Sex.FEMALE, new DateTime(1999, 4, 6), "1548045132148", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021745896352", "0685421542", "pera@email.com", "", new EmergencyContact("Milan", "Milanovic", "", "06412585432"), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d4")));
            Patient p12 = new Patient("lazar78", "ojksfkbfkje", "Lazar", "Lazarić", "P.", Sex.MALE, new DateTime(1978, 4, 6), "890548401215486", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021745896352", "0685421542", "pera@email.com", "", new EmergencyContact("Milan", "Milanovic", "", "06412585432"), PatientType.GENERAL, SecretaryAppResources.GetInstance().doctorRepository.GetByID(new UserID("d4")));

            SecretaryAppResources.GetInstance().patientRepository.Create(p1);
            SecretaryAppResources.GetInstance().patientRepository.Create(p2);
            SecretaryAppResources.GetInstance().patientRepository.Create(p3);
            SecretaryAppResources.GetInstance().patientRepository.Create(p4);
            SecretaryAppResources.GetInstance().patientRepository.Create(p5);
            SecretaryAppResources.GetInstance().patientRepository.Create(p6);
            SecretaryAppResources.GetInstance().patientRepository.Create(p7);
            SecretaryAppResources.GetInstance().patientRepository.Create(p8);
            SecretaryAppResources.GetInstance().patientRepository.Create(p9);
            SecretaryAppResources.GetInstance().patientRepository.Create(p10);
            SecretaryAppResources.GetInstance().patientRepository.Create(p11);
            SecretaryAppResources.GetInstance().patientRepository.Create(p12);
        }

        private void MakeDoctors()
        {
            Doctor d1 = new Doctor("luka77", "ushdkdsbkhsbhs", "Luka", "Kričković", "", Sex.MALE, new DateTime(1998, 1, 1), "010199815104512", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021784513840", "065645128405", "luka@email.com", "", SecretaryAppResources.GetInstance().timeTableRepository.GetByID(1), null, SecretaryAppResources.GetInstance().roomRepository.GetByID(2), DocTypeEnum.CARDIOLOGIST);
            Doctor d2 = new Doctor("strangee", "jsikjbdnsbiu", "Stephen", "Strange", "", Sex.MALE, new DateTime(1989, 1, 1), "548605084505845", new Address("Ulica broj", new Location(843, "United States", "New York")), "844061208453", "06589450154", "strange@marvel.com", "", SecretaryAppResources.GetInstance().timeTableRepository.GetByID(2), null, SecretaryAppResources.GetInstance().roomRepository.GetByID(3), DocTypeEnum.SURGEON);
            Doctor d3 = new Doctor("drkon", "i9u8euhwihu", "Predrag", "Kon", "S.", Sex.MALE, new DateTime(1955, 5, 28), "05456425484521", new Address("Ulica broj", new Location(642, "Serbia", "Beograd")), "0118405150248", "065945121845", "kon@email.com", "", SecretaryAppResources.GetInstance().timeTableRepository.GetByID(3), null, SecretaryAppResources.GetInstance().roomRepository.GetByID(1), DocTypeEnum.INFECTOLOGIST);
            Doctor d4 = new Doctor("plava-macka75", "0i2jknfuhjenoij", "Darija", "Kisić-Stepavčević", "", Sex.FEMALE, new DateTime(1975, 8, 20), "848468450180485", new Address("Ulica broj", new Location(642, "Serbia", "Beograd")), "01148450549", "069695328451", "darija@pink.rs", "", SecretaryAppResources.GetInstance().timeTableRepository.GetByID(4), null, SecretaryAppResources.GetInstance().roomRepository.GetByID(2), DocTypeEnum.CARDIOLOGIST);
            Doctor d5 = new Doctor("magnet", "i9wujdnuwgid", "Branimir", "Nestorović", "", Sex.MALE, new DateTime(1954, 1, 1), "98120208451", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021784513840", "065645128405", "luka@email.com", "", SecretaryAppResources.GetInstance().timeTableRepository.GetByID(5), null, SecretaryAppResources.GetInstance().roomRepository.GetByID(2), DocTypeEnum.CARDIOLOGIST);
            Doctor d6 = new Doctor("markoo", "ijouiehjbde", "Marko", "Marković", "V.", Sex.MALE, new DateTime(1964, 11, 11), "65105480121354", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021784513840", "065645128405", "luka@email.com", "", SecretaryAppResources.GetInstance().timeTableRepository.GetByID(6), null, null, DocTypeEnum.FAMILYMEDICINE);
            Doctor d7 = new Doctor("mirjanaa4", "i9ejkjnddneijh", "Mirjana", "Mirjanić", "", Sex.FEMALE, new DateTime(1968, 7, 12), "955120401510154", new Address("Ulica broj", new Location(659, "Serbia", "Novi Sad")), "021784513840", "065645128405", "luka@email.com", "", SecretaryAppResources.GetInstance().timeTableRepository.GetByID(7), null, null, DocTypeEnum.OPHTAMOLOGIST);

            SecretaryAppResources.GetInstance().doctorRepository.Create(d1);
            SecretaryAppResources.GetInstance().doctorRepository.Create(d2);
            SecretaryAppResources.GetInstance().doctorRepository.Create(d3);
            SecretaryAppResources.GetInstance().doctorRepository.Create(d4);
            SecretaryAppResources.GetInstance().doctorRepository.Create(d5);
            SecretaryAppResources.GetInstance().doctorRepository.Create(d6);
            SecretaryAppResources.GetInstance().doctorRepository.Create(d7);
        }
    }
}
