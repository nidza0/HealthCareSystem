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

using SIMS.Model.UserModel;
using SIMS.Model.PatientModel;
using SIMS.Model.DoctorModel;
using SIMS.Util;
using System.Collections.ObjectModel;
using System.ComponentModel;

using SIMS.View.ViewPatient.RepoSimulator;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for EditAnAppointment.xaml
    /// </summary>
    public partial class EditAnAppointment : Window
    {

        private MyAppointmentsRepo myAppointmentsRepo;
        private UserRepo userRepo;
        private DateTime firstAllowedDate;
        private Appointment appointment;
        private Doctor selectedDoctor;
        private DateTime newDate;
        private ObservableCollection<DateTime> availableTime;
        private DateTime selectedNewTime;


        
        public EditAnAppointment(Appointment appointment)
        {
            myAppointmentsRepo = MyAppointmentsRepo.Instance;
            userRepo = UserRepo.Instance;
            this.appointment = appointment;
            this.DataContext = this;

            NewDate = appointment.TimeInterval.StartTime;
            SelectedDoctor = appointment.DoctorInAppointment;
            firstAllowedDate = DateTime.Now.AddDays(1);

            InitializeComponent();


            


            timeComboBox.SelectedItem = appointment.TimeInterval.StartTime;



        } 

        public ObservableCollection<Doctor> Doctors
        {
            //returns doctors of the same type
            get
            {
                ObservableCollection<Doctor> retVal = new ObservableCollection<Doctor>();
                Console.WriteLine(GetDoctorsOfDoctorType(appointment.DoctorInAppointment.DocTypeEnum).Count);
                foreach(Doctor doctor in GetDoctorsOfDoctorType(appointment.DoctorInAppointment.DocTypeEnum))
                {
                    retVal.Add(doctor);
                }

                return retVal;
            }
        }

        private List<Doctor> GetDoctorsOfDoctorType(DocTypeEnum docTypeEnum)
        {
            List<Doctor> retVal = new List<Doctor>();

            //call controller...

            //dummy data
            return userRepo.DoctorList.Where(doc => doc.DocTypeEnum == docTypeEnum).ToList();

            //TimeInterval timeInterval = new TimeInterval(new DateTime(2020, 10, 6, 8, 0, 0), new DateTime(2020, 10, 6, 16, 0, 0));
            //Dictionary<WorkingDaysEnum, TimeInterval> dict = new Dictionary<WorkingDaysEnum, TimeInterval>();
            //dict.Add(WorkingDaysEnum.MONDAY, timeInterval);
            //dict.Add(WorkingDaysEnum.TUESDAY, timeInterval);
            //dict.Add(WorkingDaysEnum.WEDNESDAY, timeInterval);
            //dict.Add(WorkingDaysEnum.THURSDAY, timeInterval);
            //dict.Add(WorkingDaysEnum.FRIDAY, timeInterval);
            //dict.Add(WorkingDaysEnum.SATURDAY, timeInterval);
            //dict.Add(WorkingDaysEnum.SUNDAY, timeInterval);
            //TimeTable timeTable = new TimeTable(dict);
            //Doctor doctor = new Doctor(new UserID("d123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Bulevar Oslobodjenja 69", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B123", false, 5, RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            //Doctor doctor1 = new Doctor(new UserID("d1266"), "pera", "pera123", DateTime.Now, "Nikola", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-367", "zzzz"), new Room("B124", false, 5, RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            //Doctor doctor2 = new Doctor(new UserID("d1267"), "pera", "pera123", DateTime.Now, "Veljko", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-321321", "zzzz"), new Room("B125", false, 5, RoomType.EXAMINATION), DocTypeEnum.INFECTOLOGIST);
            //Doctor doctor3 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Petkovic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-6666666", "zzzz"), new Room("B126", false, 5, RoomType.EXAMINATION), DocTypeEnum.INFECTOLOGIST);
            //Doctor doctor4 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Peric", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-TEST-123", "zzzz"), new Room("B127", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);
            //Doctor doctor5 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Zeljic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-TEST2-132", "zzzz"), new Room("B128", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);

            //retVal.Add(doctor);
            //retVal.Add(doctor1);
            //retVal.Add(doctor2);
            //retVal.Add(doctor3);
            //retVal.Add(doctor4);
            //retVal.Add(doctor5);

        }

        public Appointment Appointment { get => appointment; set => appointment = value; }
        public Doctor SelectedDoctor { get => selectedDoctor; set => selectedDoctor = value; }
        public DateTime NewDate { get => newDate; set => newDate = value; }
        public ObservableCollection<DateTime> AvailableTime {
            get
            {
                List<Appointment> appointments = GetAvailableAppointments().ToList();

                ObservableCollection<DateTime> retVal = new ObservableCollection<DateTime>();
                
                foreach(Appointment appointment in appointments)
                {
                    retVal.Add(appointment.TimeInterval.StartTime);
                }

                retVal.Add(DateTime.Now);
                retVal.Add(DateTime.Now.AddMinutes(20));
                retVal.Add(DateTime.Now.AddMinutes(40));
                retVal.Add(DateTime.Now.AddMinutes(60));
                retVal.Add(DateTime.Now.AddMinutes(80));
                retVal.Add(DateTime.Now.AddMinutes(100));
    


                return retVal;
            }


            set => availableTime = value; }
        public DateTime SelectedNewTime { get => selectedNewTime; set => selectedNewTime = value; }
        public DateTime FirstAllowedDate { get => firstAllowedDate; set => firstAllowedDate = value; }

        private IEnumerable<Appointment> GetAvailableAppointments()
        {
            TimeInterval timeInterval = new TimeInterval(new DateTime(2020, 10, 6, 8, 0, 0), new DateTime(2020, 10, 6, 16, 0, 0));
            //Cpozivamo kontroler koji nam vraca slobodne termine za doktora za izabrani datum
            List<Appointment> retVal = new List<Appointment>();

            Appointment appointment = new Appointment(Appointment.DoctorInAppointment, HomePage.loggedPatient, Appointment.DoctorInAppointment.Office, AppointmentType.checkup, timeInterval);
            DateTime temp = timeInterval.StartTime.AddMinutes(20);
            DateTime tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment1 = new Appointment(Appointment.DoctorInAppointment, HomePage.loggedPatient, Appointment.DoctorInAppointment.Office, AppointmentType.operation, timeInterval);
            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);

            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);


            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment2 = new Appointment(Appointment.DoctorInAppointment, HomePage.loggedPatient, Appointment.DoctorInAppointment.Office, AppointmentType.operation, timeInterval);
            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment3 = new Appointment(Appointment.DoctorInAppointment, HomePage.loggedPatient, Appointment.DoctorInAppointment.Office, AppointmentType.checkup, timeInterval);
            timeInterval = new TimeInterval(new DateTime(2020, 6, 10, 8, 0, 0), new DateTime(2020, 6, 10, 16, 0, 0));
            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment4 = new Appointment(Appointment.DoctorInAppointment, HomePage.loggedPatient, Appointment.DoctorInAppointment.Office, AppointmentType.checkup, timeInterval);

            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment5 = new Appointment(Appointment.DoctorInAppointment, HomePage.loggedPatient, Appointment.DoctorInAppointment.Office, AppointmentType.checkup, timeInterval);


            timeInterval = new TimeInterval(new DateTime(2020, 10, 7, 8, 0, 0), new DateTime(2020, 10, 7, 16, 0, 0));


            Appointment appointment6 = new Appointment(Appointment.DoctorInAppointment, HomePage.loggedPatient, Appointment.DoctorInAppointment.Office, AppointmentType.operation, timeInterval);
            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);

            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);


            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment7 = new Appointment(Appointment.DoctorInAppointment, HomePage.loggedPatient, Appointment.DoctorInAppointment.Office, AppointmentType.operation, timeInterval);
           



            List<Appointment> patientAppointments = new List<Appointment>();

            patientAppointments.Add(appointment);
            patientAppointments.Add(appointment1);
            patientAppointments.Add(appointment2);
            patientAppointments.Add(appointment3);
            patientAppointments.Add(appointment4);
            patientAppointments.Add(appointment5);
            patientAppointments.Add(appointment6);
            patientAppointments.Add(appointment7);

            foreach(Appointment app in patientAppointments)
            {
                //ako je onog dana kada je izabrano, prikazacemo
                //if (NewDate.Date.Equals(app.TimeInterval.StartTime.Date))
                Console.WriteLine(app.TimeInterval.StartTime.Date);
                Console.WriteLine(NewDate.Date);
                if (NewDate.Date.Equals(app.TimeInterval.StartTime.Date)) 
                {
                    retVal.Add(app);
                }
                    
            }

            bool found = false;
            foreach(Appointment app in patientAppointments)
            {
                if (app.TimeInterval.StartTime.Equals(this.appointment.TimeInterval.StartTime))
                {
                    found = true;
                }
            }

            if (!found)
            {
                Appointment appointment8 = new Appointment(Appointment.DoctorInAppointment, HomePage.loggedPatient, Appointment.DoctorInAppointment.Office, AppointmentType.operation, this.appointment.TimeInterval);

                retVal.Add(appointment8);
            }

            //if (!retVal.Contains(appointment.TimeInterval.StartTime))
            //{
            //    timeComboBox.Items.Add(appointment.TimeInterval.StartTime);

            //}

            return retVal;

        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(timeComboBox != null)
            {
                Int32 selectedIndex = timeComboBox.SelectedIndex;
                timeComboBox.SelectedIndex = -1;
                timeComboBox.Items.Refresh();
                timeComboBox.SelectedIndex = selectedIndex;

            }

            refreshAppointmentList();
        }

        private void refreshAppointmentList()
        {
            AvailableTime.Clear();
            ICollectionView view = CollectionViewSource.GetDefaultView(AvailableTime);
            view.Refresh();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to cancel this action?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }

            //else
            this.Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to edit this appointment?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                return;
            }

            //Call controller and check if everythign okey
            this.Close();

            Doctor newDoctor = (Doctor)doctorComboBox.SelectedItem;
            DateTime newStartTime = (DateTime)timeComboBox.SelectedItem;
            DateTime newEndTime = ((DateTime)timeComboBox.SelectedItem).AddMinutes(20);
            TimeInterval newTimeInterval = new TimeInterval(newStartTime, newEndTime);
            Appointment newAppointment = new Appointment(appointment.GetId(),newDoctor,appointment.Patient,appointment.Room,appointment.AppointmentType,newTimeInterval);

            myAppointmentsRepo.updateAppointment(newAppointment);

            
            MessageBox.Show("Appointment successfully changed!");
        }
    }
}
