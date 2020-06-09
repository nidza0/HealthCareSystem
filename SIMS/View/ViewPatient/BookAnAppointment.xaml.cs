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
using SIMS.Util;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for BookAnAppointment.xaml
    /// </summary>
    public partial class BookAnAppointment : Window
    {
        private Doctor _doctor;
        private ObservableCollection<Appointment> appointments;
        private DateTime date;
        private DateTime firstAllowedDate;
        private String imagePath;
        private readonly int appointmentLength = 20;
        public BookAnAppointment(Doctor doctor)
        {

            date = DateTime.Now.AddDays(1);
            firstAllowedDate = DateTime.Now.AddDays(1);
            appointments = new ObservableCollection<Appointment>();
            _doctor = doctor;
            this.DataContext = this;
            run();

            InitializeComponent();

        
        }

        private void run()
        {
            appointments.Clear();
            generateAppointmentSlots(); //kreiramo prazne appointment slots
            simulateAppointmentTaken();

            refreshAppointmentList();
        }


        private void generateAppointmentSlots()
        {
            //Kreiramo prazne appointment slots.
            TimeInterval timeInterval = GetDoctorTimeIntervalForDate(date);

            if(timeInterval != null)
            {
                //Ako tad radi doktor
                DateTime currTime = timeInterval.StartTime;
                DateTime endTime = timeInterval.EndTime;

                while (currTime <= endTime)
                {
                    TimeInterval appointmentTimeInterval = new TimeInterval(currTime, endTime);
                    appointments.Add(new Appointment(Doctor, null, Doctor.Office, AppointmentType.checkup, appointmentTimeInterval));
                    currTime = currTime.AddMinutes(appointmentLength);
                }
            }

            
        }

        private void refreshAppointmentList()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Appointments);
            view.Refresh();
        }

        private void simulateAppointmentTaken()
        {
            Random randomNumberGen = new Random();
            Patient patient = new Patient(new UserID("P123"));
            Patient patient1 = new Patient(new UserID("P124"));
            foreach (Appointment appointment in Appointments)
            {
                //Po random principu "zauzimamo appointmente i tako simuliramo.
                int randNum = randomNumberGen.Next(1, 5);
                if(randNum == 3)
                {
                    appointment.Patient = patient;
                }
            }
        }

        //private void generateAppointmentsTemplate()
        //{
        //    DateTime test = DateTime.Now.AddDays(6);
        //    TimeInterval timeInterval = GetDoctorTimeIntervalForDate(test);

        //    if(timeInterval != null)
        //    {
        //        DateTime currTime = timeInterval.StartTime;
        //        DateTime endTime = timeInterval.EndTime;
        //        IEnumerable<Appointment> takenAppointments = getTakenAppointments();
        //        foreach(Appointment appointment in takenAppointments)
        //        {
        //            appointments.Add(appointment);
        //        }
        //        while (currTime <= endTime)
        //        {
        //            TimeInterval appointmentTimeInterval = new TimeInterval(currTime, endTime);
        //            if(appointments.)
        //            appointments.Add(new Appointment(Doctor, null, Doctor.Office, AppointmentType.checkup, appointmentTimeInterval));
        //            currTime = currTime.AddMinutes(appointmentLength);
        //        }
        //    }
        //    //while (test.Day == 5)
        //    //{
        //    //    Console.WriteLine(test);
        //    //    test = test.AddMinutes(appointmentLength);
        //    //}

            

        //    refreshAppointmentList();
           
        //}

        private TimeInterval GetDoctorTimeIntervalForDate(DateTime date)
        {
            TimeTable doctorTimeTable = _doctor.TimeTable;
            DayOfWeek dayOfWeek = date.DayOfWeek;
            WorkingDaysEnum workingDaysEnum = (WorkingDaysEnum)dayOfWeek;

            TimeInterval retVal = null;
            try
            {
                Dictionary<WorkingDaysEnum, TimeInterval> workingHour = doctorTimeTable.WorkingHours;
                retVal = workingHour[workingDaysEnum];
            }catch(Exception e)
            {
                
            }

            return retVal;
        }

        public Doctor Doctor { get => _doctor; set => _doctor = value; }
        public ObservableCollection<Appointment> Appointments { get => appointments; set => appointments = value; }
        public DateTime Date { get => date; set => date = value; }
        public string ImagePath { get => @"static\images\test_image.png"; set => imagePath = value; }
        public DateTime FirstAllowedDate { get => firstAllowedDate; set => firstAllowedDate = value; }

        private void BookAnAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Appointment appointment = button.DataContext as Appointment;
            appointment.Patient = HomePage.loggedPatient;
            appointment.DoctorInAppointment = Doctor;

           

            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

                //Upisi u bazu.
                Close();
                MessageBox.Show("Appointment successfully created.");
            }
            else
            {

            }


        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            run(); //update
        }
    }
}
