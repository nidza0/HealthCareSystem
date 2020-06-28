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
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Util;
using System.Collections.ObjectModel;
using SIMS.Model.DoctorModel;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public static Patient loggedPatient;
        public ObservableCollection<Appointment> recentAppointments = new ObservableCollection<Appointment>();
        public ObservableCollection<Notification> notifications = new ObservableCollection<Notification>();
        public ObservableCollection<Article> articles = new ObservableCollection<Article>();
        public ObservableCollection<Diagnosis> diagnosisList = new ObservableCollection<Diagnosis>();

        public HomePage(User loggedInPatient)
        {
            DoctorData();
            loggedPatient = AppResources.getInstance().patientController.GetByID(loggedInPatient.GetId());
            InitializeComponent();
            Doctor doctor = new Doctor(new UserID("D333"),"pera","pera",DateTime.Now,"Nikola","Dragic","Milos",Sex.MALE,DateTime.Now,"1234567",new Address("test",new Location(1)),"555-333","zzzz","zzz","zzzzz",new TimeTable(2),new Hospital(1),new Room(2),Model.DoctorModel.DoctorType.SURGEON);
            Doctor doctor2 = new Doctor(new UserID("D333"), "pera", "pera", DateTime.Now, "Pera", "Peric", "Milos", Sex.MALE, DateTime.Now, "1234567", new Address("test", new Location(1)), "555-333", "zzzz", "zzz", "zzzzz", new TimeTable(2), new Hospital(1), new Room(2), Model.DoctorModel.DoctorType.SURGEON);
            Room room = new Room(22, "O123", true, 2, RoomType.AFTERCARE);
            //AppointmentConverter appointmentConverter = new AppointmentConverter(",", ";");
            Appointment appointment = new Appointment(69, doctor, new Patient(new UserID("62")), room, AppointmentType.operation, new TimeInterval(DateTime.Now, DateTime.Now));
            Appointment appointment2 = new Appointment(70, doctor2, new Patient(new UserID("62")), new Room(3), AppointmentType.operation, new TimeInterval(DateTime.Now, DateTime.Now));
            Appointment appointment3 = new Appointment(71, doctor, new Patient(new UserID("62")), new Room(7), AppointmentType.operation, new TimeInterval(DateTime.Now, DateTime.Now));

            recentAppointments.Add(appointment);
            recentAppointments.Add(appointment2);
            recentAppointments.Add(appointment3);

            UpcomingEventsListBox.DataContext = recentAppointments;

            Notification notification = new Notification(69, "Postovani, informisem vas da je vas termin pomeren za 16:00",new Patient(new UserID("P123")),DateTime.Now);
            Notification notification1 = new Notification(70, "Postovani, informisem vas da je vas termin pomeren za 18:00", new Patient(new UserID("P124")), DateTime.Now);
            Notification notification2 = new Notification(69, "Postovani, informisem vas da je vas termin pomeren za 16:00", new Patient(new UserID("P123")), DateTime.Now);
            Notification notification3 = new Notification(70, "Postovani, informisem vas da je vas termin pomeren za 18:00", new Patient(new UserID("P124")), DateTime.Now);
            Notification notification4 = new Notification(69, "Postovani, informisem vas da je vas termin pomeren za 16:00", new Patient(new UserID("P123")), DateTime.Now);
            Notification notification5 = new Notification(70, "Postovani, informisem vas da je vas termin pomeren za 18:00", new Patient(new UserID("P124")), DateTime.Now);
            notifications.Add(notification);
            notifications.Add(notification1);
            notifications.Add(notification2);
            notifications.Add(notification3);
            notifications.Add(notification4);
            notifications.Add(notification5);

            NotificationsListBox.DataContext = notifications;
            //public Article(long id, string title, string shortDescription, string text, Employee author, DateTime dateCreated) : base(id, text, dateCreated)
            Article article1 = new Article(68, "COVID-19", "An article about COVID19 effect on human body", "The COVID-19 pandemic in Serbia is a current outbreak of Coronavirus disease 2019 in Serbia caused by SARS-CoV-2. Its first case in Serbia was reported on 6 March 2020,[1] and confirmed by Minister of Health Zlatibor Lončar,[2] the case was a 43-year-old man from Bačka Topola who had travelled to Budapest.[3]"

 + "As of 25 May 2020, 220, 344 individuals were tested of which there have been 11, 193 confirmed cases, 5, 920 recoveries and 239 deaths in Serbia." , doctor, DateTime.Now);
            Article article2 = new Article(68, "COVID-19", "An article about COVID19 effect on human body", "The COVID-19 pandemic in Serbia is a current outbreak of Coronavirus disease 2019 in Serbia caused by SARS-CoV-2. Its first case in Serbia was reported on 6 March 2020,[1] and confirmed by Minister of Health Zlatibor Lončar,[2] the case was a 43-year-old man from Bačka Topola who had travelled to Budapest.[3]"

 + "As of 25 May 2020, 220, 344 individuals were tested of which there have been 11, 193 confirmed cases, 5, 920 recoveries and 239 deaths in Serbia.", doctor2, DateTime.Now);

            articles.Add(article1);
            articles.Add(article2);

            articlesListBox.DataContext = articles;

 




            //string csv = appointmentConverter.ConvertEntityToCSV(appointment);
            //Console.WriteLine("Old CSV: " + csv);
            //Appointment newAppointment = appointmentConverter.ConvertCSVToEntity(csv);
            //Console.WriteLine("New CSV: " + appointmentConverter.ConvertEntityToCSV(newAppointment));
        }

        private void Messages_Button_Click(object sender, RoutedEventArgs e)
        {
            Messages messagesWindow = new Messages();
            messagesWindow.WindowState = WindowState.Maximized;
            messagesWindow.ShowDialog();
        }

        private void MyDiagnosis_Button_Click(object sender, RoutedEventArgs e)
        {
            DiagnosisOverview diagnosisOverview = new DiagnosisOverview();
            diagnosisOverview.ShowDialog();
        }

        private void ExitButton_Closing(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to exit the application?", "Exit confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure you want to exit the application?", "Exit confirmation", System.Windows.MessageBoxButton.YesNo);
            if (messageBoxResult != MessageBoxResult.Yes)
            {
                e.Cancel = true; //Cancel application turn off.
            }
        }

        private void MakeAnAppointment(object sender, RoutedEventArgs e)
        {
            
            double height = Application.Current.MainWindow.Height - (Application.Current.MainWindow.Height * 0.1);
            double width = Application.Current.MainWindow.Width - (Application.Current.MainWindow.Width * 0.2);

            MakeAnAppointment makeAnAppointment = new MakeAnAppointment();
            makeAnAppointment.Owner = Application.Current.MainWindow;
            makeAnAppointment.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            makeAnAppointment.Show();
            makeAnAppointment.Focus();
        }

        private void DismissNotificationClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Notification notification = button.DataContext as Notification;
            notifications.Remove(notification);

        }

        private void ViewArticleButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Article article = button.DataContext as Article;
            ArticlePreview articlePreview = new ArticlePreview(article);
            articlePreview.Show();
        }

        private void MyAppointments_Click(object sender, RoutedEventArgs e)
        {
            MyAppointments myAppointments = new MyAppointments();
            myAppointments.ShowDialog();
        }

        private void MyProfileButton_Click(object sender, RoutedEventArgs e)
        {
            //Patient p2 = new Patient(
            //                          "milic",
            //                          "PASSWORD",
            //                          "Milica",
            //                          "Mikic",
            //                          "Milos",
            //                          Sex.FEMALE,
            //                          new DateTime(1992, 11, 7),
            //                          "9876543221",
            //                          new Address("Partizanska 5", new Location(1, "Serbia", "Novi Sad")),
            //                          "0213698569",
            //                          "06454545454",
            //                          "milica@gmail.com",
            //                          "",
            //                          new EmergencyContact("Milana", "Milanović", "", "0217474859"),
            //                          PatientType.GENERAL,
            //                          null);
            Registration editProfile = new Registration(AppResources.getInstance().patientController.GetByID(loggedPatient.GetId()));
            editProfile.ShowDialog();
        }

        private void TherapyButton_Click(object sender, RoutedEventArgs e)
        {
            TherapyOverview therapyOverview = new TherapyOverview();
            therapyOverview.ShowDialog();
        }

        private void TutorialButton_Click(object sender, RoutedEventArgs e)
        {
            VideoTutorial videoTutorial = new VideoTutorial();
            videoTutorial.Show();
        }


        private void DoctorData()
        {
            Address address1 = new Address("Koste Sokice 3", AppResources.getInstance().locationController.GetByID(1));
            Address address2 = new Address("Koste Sokice 65", AppResources.getInstance().locationController.GetByID(2));
            Address address3 = new Address("Petroviceva 68", AppResources.getInstance().locationController.GetByID(3));


            TimeTable timeTable = null; //time table mi je najbitniji
            Dictionary<WorkingDaysEnum, TimeInterval> dict = new Dictionary<WorkingDaysEnum, TimeInterval>();
            TimeInterval timeInterval = new TimeInterval(new DateTime(2020, 6, 28, 8, 0, 0), new DateTime(2020, 6, 28, 16, 0, 0));
            dict.Add(WorkingDaysEnum.MONDAY, timeInterval);
            dict.Add(WorkingDaysEnum.TUESDAY, timeInterval);
            dict.Add(WorkingDaysEnum.WEDNESDAY, timeInterval);
            dict.Add(WorkingDaysEnum.THURSDAY, timeInterval);
            dict.Add(WorkingDaysEnum.FRIDAY, timeInterval);
            dict.Add(WorkingDaysEnum.SATURDAY, timeInterval);
            dict.Add(WorkingDaysEnum.SUNDAY, timeInterval);
            timeTable = new TimeTable(dict);

            timeTable = AppResources.getInstance().timeTableRepository.Create(timeTable);


            Hospital hospital1 = new Hospital("Perina bolnica", address1, "555-333", "www.sajt.com");
            Hospital hospital2 = new Hospital("Covid bolnica", address2, "555-333", "www.sajt.com");
            Hospital hospital3 = new Hospital("Infektoloska bolnica", address3, "555-333", "www.sajt.com");
            hospital1 = AppResources.getInstance().hospitalController.Create(hospital1);
            hospital2 = AppResources.getInstance().hospitalController.Create(hospital2);
            hospital3 = AppResources.getInstance().hospitalController.Create(hospital3);

            Room room1 = new Room("A123", false, 2, RoomType.EXAMINATION);
            Room room2 = new Room("A125", false, 2, RoomType.EXAMINATION);
            Room room3 = new Room("A127", false, 2, RoomType.EXAMINATION);


            room1 = AppResources.getInstance().roomController.Create(room1);
            room2 = AppResources.getInstance().roomController.Create(room2);
            room3 = AppResources.getInstance().roomController.Create(room3);
            Doctor d1 = new Doctor("drstrange", "12345678", "Stephen", "Strange", "Doctor", Sex.MALE, DateTime.Now, "4578457854444", address1, "0081747474", "0081747474", "drstrange@marvel.com", "stephen.strange@marvel.com", timeTable, hospital1, room1, DoctorType.SURGEON);
            Doctor d2 = new Doctor("p.kon", "12345678", "Predrag", "Kon", "", Sex.MALE, DateTime.Now, "1113543545488", address1, "0118754786", "0118754786", "dr.kon@zdrav.gov.rs", "dr.kon@zdrav.gov.rs", timeTable, hospital1, room2, DoctorType.INFECTOLOGIST);
            Doctor d3 = new Doctor("darija", "12345678", "Darija", "Kisic", "", Sex.FEMALE, DateTime.Now, "2251812065115", address2, "0118798449", "0118754786", "darija.kk@gmail.com", "darija.kk@gmail.com", timeTable, hospital2, room3, DoctorType.INFECTOLOGIST);
            Doctor d4 = new Doctor("doktorr", "12345678", "OKurrr", "Kisic", "", Sex.FEMALE, DateTime.Now, "3251812065115", address3, "0118798449", "0118754786", "darija.kk@gmail.com", "darija.kk@gmail.com", timeTable, hospital3, room3, DoctorType.CARDIOLOGIST);

            d1 = AppResources.getInstance().doctorController.Create(d1);
            d2 = AppResources.getInstance().doctorController.Create(d2);
            d3 = AppResources.getInstance().doctorController.Create(d3);
            d4 = AppResources.getInstance().doctorController.Create(d4);

            Patient patient = AppResources.getInstance().patientController.GetByID(AppResources.getInstance().loggedInUser.GetId());

            Appointment appointment1 = new Appointment(d1, patient, room1, AppointmentType.checkup, new TimeInterval(new DateTime(2020, 6, 30, 8, 0, 0), new DateTime(2020, 6, 30, 8, 15, 0)));
            Appointment appointment2 = new Appointment(d2, patient, room2, AppointmentType.checkup, new TimeInterval(new DateTime(2020, 6, 30, 8, 15, 0), new DateTime(2020, 6, 30, 8, 30, 0)));


           appointment1 =  AppResources.getInstance().appointmentController.Create(appointment1);
           appointment2 =  AppResources.getInstance().appointmentController.Create(appointment2);



            //List<Appointment> recommendedAppointments = AppResources.getInstance().appointmentController.GetRecommendedAppointments(new AppointmentRecommendationDTO(d1, new TimeInterval(new DateTime(2020, 6, 30, 8, 0, 0), new DateTime(2020, 7, 5, 8, 15, 0)), RecommendationPriority.DOCTOR));

            //foreach(Appointment appointment in recommendedAppointments)
            //{
            //    Console.WriteLine(appointment.DoctorInAppointment.FullName + " " + appointment.TimeInterval.StartTime + " --- " + appointment.TimeInterval.EndTime);
            //}


        }
    }
}
