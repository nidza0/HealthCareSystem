﻿using System;
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

using SIMS.Model.DoctorModel;
using SIMS.Model.UserModel;
using SIMS.Model.PatientModel;
using System.Collections.ObjectModel;
using SIMS.Util;
using System.ComponentModel;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for MyAppointments.xaml
    /// </summary>
    public partial class MyAppointments : Window
    {
        private DocTypeEnum selectedFilterDoctorType;
        private Doctor selectedFilterDoctor;
        private DateTime firstAllowedDate;
        private AppointmentType selectedFilterAppointmentType;
        private ObservableCollection<Appointment> allAppointments;
        private Appointment selectedAppointment;

        private DateTime selectedStartDate = DateTime.Now;

        private DateTime selectedEndDate = DateTime.Now;

        public MyAppointments()
        {
            firstAllowedDate = DateTime.Now.AddDays(1);
            AllAppointments = GetAllObservablePatientAppointments();
            this.DataContext = this;
            InitializeComponent();

            doctorTypeComboBox.ItemsSource = Enum.GetValues(typeof(DocTypeEnum)).Cast<DocTypeEnum>();
            appointmentTypeComboBox.ItemsSource = Enum.GetValues(typeof(AppointmentType)).Cast<AppointmentType>();
        }

        public DocTypeEnum SelectedFilterDoctorType { get => selectedFilterDoctorType; set => selectedFilterDoctorType = value; }
        public Doctor SelectedFilterDoctor { get => selectedFilterDoctor; set => selectedFilterDoctor = value; }

        public ObservableCollection<Doctor> PatientDoctors
        {
            get { 
                List<Doctor> patientDoctors = GetAllPatientAppointments().ToList().Select(appointment => appointment.DoctorInAppointment).Distinct().ToList();
                ObservableCollection<Doctor> retVal = new ObservableCollection<Doctor>();
                foreach(Doctor doctor in patientDoctors)
                {
                    retVal.Add(doctor);
                }

                return retVal;
            }
        }

        public DateTime FirstAllowedDate { get => firstAllowedDate; set => firstAllowedDate = value; }
        public DateTime SelectedStartDate { get => selectedStartDate; set => selectedStartDate = value; }
        public DateTime SelectedEndDate { get => selectedEndDate; set => selectedEndDate = value; }
        public AppointmentType SelectedFilterAppointmentType { get => selectedFilterAppointmentType; set => selectedFilterAppointmentType = value; }
        public ObservableCollection<Appointment> AllAppointments { get => allAppointments; set => allAppointments = value; }
        public Appointment SelectedAppointment { get => selectedAppointment; set => selectedAppointment = value; }

        private ObservableCollection<Appointment> GetAllObservablePatientAppointments()
        {
            ObservableCollection<Appointment> retVal = new ObservableCollection<Appointment>();

            foreach (Appointment appointment in GetAllPatientAppointments())
                retVal.Add(appointment);

            return retVal;
        }
        
        private IEnumerable<Appointment> GetAllPatientAppointments()
        {
            //call controller


            TimeInterval timeInterval = new TimeInterval(new DateTime(2020, 10, 6, 8, 0, 0), new DateTime(2020, 10, 6, 16, 0, 0));
            Dictionary<WorkingDaysEnum, TimeInterval> dict = new Dictionary<WorkingDaysEnum, TimeInterval>();
            dict.Add(WorkingDaysEnum.MONDAY, timeInterval);
            dict.Add(WorkingDaysEnum.TUESDAY, timeInterval);
            dict.Add(WorkingDaysEnum.WEDNESDAY, timeInterval);
            dict.Add(WorkingDaysEnum.THURSDAY, timeInterval);
            dict.Add(WorkingDaysEnum.FRIDAY, timeInterval);
            dict.Add(WorkingDaysEnum.SATURDAY, timeInterval);
            dict.Add(WorkingDaysEnum.SUNDAY, timeInterval);
            TimeTable timeTable = new TimeTable(dict);
            Doctor doctor = new Doctor(new UserID("d123"), "pera", "pera123", DateTime.Now, "Pera", "Vunic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-333", "06130959858", "pera@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Bulevar Oslobodjenja 69", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B123", false, 5, RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            Doctor doctor1 = new Doctor(new UserID("d1266"), "pera", "pera123", DateTime.Now, "Nikola", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-367", "zzzz"), new Room("B124", false, 5, RoomType.EXAMINATION), DocTypeEnum.CARDIOLOGIST);
            Doctor doctor2 = new Doctor(new UserID("d1267"), "pera", "pera123", DateTime.Now, "Veljko", "Dragic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-321321", "zzzz"), new Room("B125", false, 5, RoomType.EXAMINATION), DocTypeEnum.INFECTOLOGIST);
            Doctor doctor3 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Petkovic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-6666666", "zzzz"), new Room("B126", false, 5, RoomType.EXAMINATION), DocTypeEnum.INFECTOLOGIST);
            Doctor doctor4 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Peric", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-TEST-123", "zzzz"), new Room("B127", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);
            Doctor doctor5 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Zeljic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-TEST2-132", "zzzz"), new Room("B128", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);
            Doctor doctor6 = new Doctor(new UserID("d1262"), "pera", "pera123", DateTime.Now, "Pera", "Kupusarevic", "Puck", Sex.MALE, DateTime.Now, "12345667", new Address("Bulevar Mihajla Pupina 5", new Location(45, "Srbija", "Novi Sad")), "555-444", "0613021959858", "nikola@gmail.com", "pera111@gmail.com", timeTable, new Hospital("test", new Address("Koste Sokice 2", new Location(45, "Srbija", "Novi Sad")), "555-333", "zzzz"), new Room("B129", false, 5, RoomType.EXAMINATION), DocTypeEnum.DERMATOLOGIST);

            Appointment appointment = new Appointment(doctor1, HomePage.loggedPatient, doctor1.Office, AppointmentType.checkup, timeInterval);
            DateTime temp = timeInterval.StartTime.AddMinutes(20);
            DateTime tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment1 = new Appointment(doctor2, HomePage.loggedPatient, doctor2.Office, AppointmentType.operation, timeInterval);
            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);

            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);


            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment2 = new Appointment(doctor3, HomePage.loggedPatient, doctor3.Office, AppointmentType.operation, timeInterval);
            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment3 = new Appointment(doctor4, HomePage.loggedPatient, doctor4.Office, AppointmentType.checkup, timeInterval);
            timeInterval = new TimeInterval(new DateTime(2020, 6, 10, 8, 0, 0), new DateTime(2020, 6, 10, 16, 0, 0));
            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);

            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);

            Appointment appointment4 = new Appointment(doctor6, HomePage.loggedPatient, doctor5.Office, AppointmentType.checkup, timeInterval);
            temp = timeInterval.StartTime.AddMinutes(20);
            tempEnd = temp.AddMinutes(20);
            timeInterval = new TimeInterval(temp, tempEnd);
            Appointment appointment5 = new Appointment(doctor6, HomePage.loggedPatient, doctor5.Office, AppointmentType.checkup, timeInterval);


            List<Appointment> patientAppointments = new List<Appointment>();

            patientAppointments.Add(appointment);
            patientAppointments.Add(appointment1);
            patientAppointments.Add(appointment2);
            patientAppointments.Add(appointment3);
            patientAppointments.Add(appointment4);
            patientAppointments.Add(appointment5);


            return patientAppointments;

        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditAnAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Appointment appointment = button.DataContext as Appointment;

            if (!CheckIfAppointmentEditable(appointment))
            {
                MessageBox.Show("Appointment can't be changed now!");
                return;
            }

            EditAnAppointment editAnAppointment = new EditAnAppointment(appointment);
            editAnAppointment.ShowDialog();



            refreshAppointmentList();

            
        }

        private void refreshAppointmentList()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(AllAppointments);
            view.Refresh();
        }

        private bool CheckIfAppointmentEditable(Appointment appointment)
        {
            if (appointment.TimeInterval.StartTime < DateTime.Now.AddDays(1)) //ako je manje od 24 sata, ovo ce se proveravati na backendu ali i ovde ajde
                return false;

            return true;
        }

        private void CancelAnAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Appointment appointment = button.DataContext as Appointment;

            if (!CheckIfAppointmentEditable(appointment))
            {
                MessageBox.Show("Appointment can't be canceled now!");
                return;
            }

            AllAppointments.Remove(appointment);


        }



        //cancel an appointment
        //-> call update(set appointment.canceled = true)
    }
}
