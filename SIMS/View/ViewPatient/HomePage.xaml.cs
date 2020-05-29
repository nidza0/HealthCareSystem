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

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public ObservableCollection<Appointment> recentAppointments = new ObservableCollection<Appointment>();
        public ObservableCollection<Notification> notifications = new ObservableCollection<Notification>();
        public ObservableCollection<Article> articles = new ObservableCollection<Article>();
        public ObservableCollection<Diagnosis> diagnosisList = new ObservableCollection<Diagnosis>();

        public HomePage()
        {
            InitializeComponent();
            Doctor doctor = new Doctor(new UserID("D333"),"pera","pera",DateTime.Now,"Nikola","Dragic","Milos",Sex.MALE,DateTime.Now,"1234567",new Address("test",new Location(1)),"555-333","zzzz","zzz","zzzzz",new TimeTable(2),new Hospital(1),new Room(2),Model.DoctorModel.DocTypeEnum.SURGEON);
            Doctor doctor2 = new Doctor(new UserID("D333"), "pera", "pera", DateTime.Now, "Nikolsdasdadasddasdadasdasdasdasdasdasdasdasdadasdasdasda", "Dragic", "Milos", Sex.MALE, DateTime.Now, "1234567", new Address("test", new Location(1)), "555-333", "zzzz", "zzz", "zzzzz", new TimeTable(2), new Hospital(1), new Room(2), Model.DoctorModel.DocTypeEnum.SURGEON);
            Room room = new Room(22, "O123", true, 2, RoomType.AFTERCARE, new List<Model.ManagerModel.InventoryItem>());
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

            //public Diagnosis(long id, Disease disease, Therapy activeTherapy, List<Therapy> previousTherapy = null)
            Symptom symptom1 = new Symptom(22,"Throat pain","Pain in the front neck region");
            Symptom symptom2 = new Symptom(22, "Nausea", "Feeling sick");
            Symptom symptom3 = new Symptom(22, "Throat pain", "Pain in the front neck region");
            List<Symptom> lista = new List<Symptom>();
            lista.Add(symptom1);
            lista.Add(symptom2);
            lista.Add(symptom3);

            Disease disease = new Disease(22, "Hashimoto's disease", " Hashimoto's disease is a condition in which your immune system" +
                                        "attacks your thyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple. The thyroid gland is part of your" +
                                        "endocrine system, which produces hormones that sadadthyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple.", true, new DiseaseType(true, true, "nmp"), lista);

            Disease disease1 = new Disease(23, "Throat cancer", " Hashimoto's disease is a condition in which your immune system" +
                                        "attacks your thyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple. The thyroid gland is part of your" +
                                        "endocrine system, which produces hormones that sadadthyroid, a small gland at the base of your neck" +
                                        "below your Adam's apple.", true, new DiseaseType(true, true, "nmp"), lista);
            Medicine medicine = new Medicine("Xanax", 20, MedicineType.PILL, 5, 2);
            Dictionary<Medicine, TherapyDose> dict = new Dictionary<Medicine, TherapyDose>();
            Dictionary<TherapyTime, double> dict_ther = new Dictionary<TherapyTime, double>();
            dict_ther.Add(TherapyTime.BeforeBed, 20);
            TherapyDose therapyDose = new TherapyDose(dict_ther);
            dict.Add(medicine, therapyDose);
            Prescription prescription = new Prescription(2, PrescriptionStatus.ACTIVE, dict);

            Therapy therapy = new Therapy(2, new TimeInterval(DateTime.Now, DateTime.Now), prescription);

            Diagnosis diagnosis = new Diagnosis(69, disease, therapy);
            Diagnosis diagnosis1 = new Diagnosis(69, disease1, therapy);

            diagnosisList.Add(diagnosis);
            diagnosisList.Add(diagnosis1);





            //string csv = appointmentConverter.ConvertEntityToCSV(appointment);
            //Console.WriteLine("Old CSV: " + csv);
            //Appointment newAppointment = appointmentConverter.ConvertCSVToEntity(csv);
            //Console.WriteLine("New CSV: " + appointmentConverter.ConvertEntityToCSV(newAppointment));
        }

        private void Messages_Button_Click(object sender, RoutedEventArgs e)
        {
            Messages messagesWindow = new Messages();
            messagesWindow.WindowState = WindowState.Maximized;
            messagesWindow.Show();
        }

        private void MyDiagnosis_Button_Click(object sender, RoutedEventArgs e)
        {
            DiagnosisOverview diagnosisOverview = new DiagnosisOverview();
            diagnosisOverview.Show();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
        }

        private void DismissNotificationClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            Notification notification = button.DataContext as Notification;
            notifications.Remove(notification);

        }

        private void ViewArticleButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("View article button clicked, TODO..");
        }
    }
}
