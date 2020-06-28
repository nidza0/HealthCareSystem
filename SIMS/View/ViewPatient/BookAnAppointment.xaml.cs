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

using SIMS.View.ViewPatient.RepoSimulator;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for BookAnAppointment.xaml
    /// </summary>
    public partial class BookAnAppointment : Window
    {

        private UserRepo userRepo;
        private DoctorAppointmentsRepo doctorAppointmentsRepo;

        private Doctor _doctor;
        private ObservableCollection<Appointment> appointments;
        private DateTime date;
        private DateTime firstAllowedDate;
        private String imagePath;
        private DateTime selectedDate;
        public BookAnAppointment(Doctor doctor)
        {
            SelectedDate = DateTime.Now.AddDays(1);
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

            check();

            refreshAppointmentList();
        }

        private void check()
        {
            
            List<Appointment> takenAppointments = AppResources.getInstance().appointmentController.GetAppointmentsByDoctor(_doctor).ToList();

            foreach (Appointment appointment in appointments)
            {
                foreach(Appointment checkAppointment in takenAppointments)
                {
                    Console.WriteLine("Free appointment : " + appointment.TimeInterval.StartTime + " - " + appointment.TimeInterval.EndTime);
                    if (checkAppointment.TimeInterval.IsTimeBetween(appointment.TimeInterval))
                    {

                        Console.WriteLine("equals");
                        appointment.Patient = new Patient(new UserID("P100000000"));
                    }
                }
            }
            
        }

        private bool sameDayCheck(TimeInterval timeInterval1, TimeInterval timeInterval2)
        {
            return timeInterval1.StartTime == timeInterval2.StartTime && timeInterval1.EndTime == timeInterval2.EndTime;
        }


        //private void performTakenAppointmentSimulation()
        //{
        //    List<Appointment> takenAppointments = doctorAppointmentsRepo.GetTakenAppointments(_doctor);

        //    foreach(Appointment appointment in Appointments)
        //    {
        //        foreach(Appointment app in takenAppointments)
        //        {
        //            if (appointment.TimeInterval.IsOverlappingWith(app.TimeInterval))
        //            {
        //                appointment.Patient = app.Patient;
        //            }
        //        }
        //    }

        //}


        private void generateAppointmentSlots()
        {
            //Kreiramo prazne appointment slots.
            TimeInterval timeInterval = GetDoctorTimeIntervalForDate(SelectedDate);

            if(timeInterval != null)
            {

                timeInterval.StartTime = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, timeInterval.StartTime.Hour, timeInterval.StartTime.Minute, 0);
                timeInterval.EndTime = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, timeInterval.EndTime.Hour, timeInterval.EndTime.Minute, 0);




                DateTime currTime = timeInterval.StartTime;
                DateTime moveTime = timeInterval.StartTime.AddMinutes(15);
                DateTime endTime = timeInterval.EndTime;

               

                while (moveTime <= endTime)
                {
                    TimeInterval appointmentTimeInterval = new TimeInterval(currTime, moveTime);
                    appointments.Add(new Appointment(Doctor, null, Doctor.Office, AppointmentType.checkup, appointmentTimeInterval));
                    moveTime = moveTime.AddMinutes(15);
                    currTime = currTime.AddMinutes(15);
                }
            }

            
        }

        private void refreshAppointmentList()
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(Appointments);
            view.Refresh();
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
        public DateTime SelectedDate { get => selectedDate; set => selectedDate = value; }

        private void BookAnAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Appointment appointment = button.DataContext as Appointment;
       

           

            MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Confirm an appointment", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {

                //Upisi u bazu.
                //DODAJ U LISTU PATIENT APPOINTMENTS
                TimeInterval oldTimeInterval = appointment.TimeInterval;
                DateTime prevStartDate = oldTimeInterval.StartTime;
                DateTime prevEndDate = oldTimeInterval.EndTime;

                DateTime newStartDate = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, prevStartDate.Hour, prevStartDate.Minute, 0);
                DateTime newEndDate = new DateTime(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day, prevEndDate.Hour, prevEndDate.Minute, 0);

                TimeInterval newTimeInterval = new TimeInterval(newStartDate, newEndDate);

                appointment.TimeInterval = newTimeInterval;

        
                appointment.Patient = HomePage.loggedPatient;
           
                appointment.DoctorInAppointment = Doctor;

                appointments.Add(appointment);
                doctorAppointmentsRepo.takeAnAppointment(appointment);
                MyAppointmentsRepo.Instance.MyAppointments.Add(appointment);
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
