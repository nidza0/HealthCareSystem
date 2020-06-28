using SIMS.Exceptions;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Util;
using SIMS.View.ViewSecretary.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.View.ViewSecretary.Pages.Appointments
{

    public partial class CreateUpdateAppointmentPage : Page
    {
        private DoctorsViewModel doctorsVM = new DoctorsViewModel();
        private PatientsViewModel patientsVM = new PatientsViewModel();
        private RoomsViewModel roomsVM = new RoomsViewModel();
        private DateTime previousStartDate = new DateTime();
        private DateTime previousEndDate = new DateTime();

        private List<String> hours = new List<String>();
        private List<String> minutes = new List<String>();

        private int _mode;
        private readonly int CREATE = 0;
        private readonly int UPDATE = 1;

        private Appointment _appointmentUpdate;

        public CreateUpdateAppointmentPage(Appointment a)
        {
            _mode = UPDATE;
            _appointmentUpdate = a;
            LoadTime();
            InitializeComponent();

            timePanel.DataContext = this;
            doctorSelectionPanel.Visibility = Visibility.Collapsed;
            patientSelectionPanel.Visibility = Visibility.Collapsed;

            dataGridAppointmentRooms.DataContext = roomsVM;
            txtSearchRooms.DataContext = roomsVM;

            lblSelectedDoctor.Content = a.DoctorInAppointment.FullName;
            lblSelectedPatient.Content = a.Patient.FullName;

            DateTime startDate = a.TimeInterval.StartTime;
            DateTime endDate = a.TimeInterval.EndTime;
            AppointmentDatePicker.SelectedDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            StartHours.SelectedIndex = hours.FindIndex(h => h.Equals(startDate.ToString("HH")));
            StartMinutes.SelectedIndex = minutes.FindIndex(m => m.Equals(startDate.ToString("mm")));
            EndHours.SelectedIndex = hours.FindIndex(h => h.Equals(endDate.ToString("HH")));
            EndMinutes.SelectedIndex = minutes.FindIndex(m => m.Equals(endDate.ToString("mm")));

            //SET ROOM
            roomsVM.LoadAllAvailableRooms(a.TimeInterval);
            dataGridAppointmentRooms.SelectedIndex = roomsVM.Rooms.ToList().FindIndex(r => r.GetId() == a.Room.GetId());
        }

        public CreateUpdateAppointmentPage(TimeInterval time, Room room)
        {
            _mode = CREATE;
            LoadTime();
            InitializeComponent();

            timePanel.DataContext = this;

            AppointmentDatePicker.SelectedDate = new DateTime(time.StartTime.Year, time.StartTime.Month, time.StartTime.Day);
            StartHours.SelectedIndex = hours.FindIndex(h => h.Equals(time.StartTime.ToString("HH")));
            StartMinutes.SelectedIndex = minutes.FindIndex(m => m.Equals(time.StartTime.ToString("mm")));
            EndHours.SelectedIndex = hours.FindIndex(h => h.Equals(time.EndTime.ToString("HH")));
            EndMinutes.SelectedIndex = minutes.FindIndex(m => m.Equals(time.EndTime.ToString("mm")));

            dataGridAppointmentDoctors.DataContext = doctorsVM;
            txtSearchDoctors.DataContext = doctorsVM;

            txtSearchPatients.DataContext = patientsVM;
            dataGridAppointmentPatients.DataContext = patientsVM;
            checkPatients();

            dataGridAppointmentRooms.DataContext = roomsVM;
            txtSearchRooms.DataContext = roomsVM;

            //SET ROOM
            roomsVM.LoadAllAvailableRooms(time);
            dataGridAppointmentRooms.SelectedIndex = roomsVM.Rooms.ToList().FindIndex(r => r.GetId() == room.GetId());
        }

        public CreateUpdateAppointmentPage()
        {
            _mode = CREATE;
            LoadTime();
            InitializeComponent();

            timePanel.DataContext = this;

            dataGridAppointmentDoctors.DataContext = doctorsVM;
            txtSearchDoctors.DataContext = doctorsVM;

            txtSearchPatients.DataContext = patientsVM;
            dataGridAppointmentPatients.DataContext = patientsVM;
            checkPatients();

            dataGridAppointmentRooms.DataContext = roomsVM;
            txtSearchRooms.DataContext = roomsVM;
        }

        private void LoadTime()
        {
            Hours.Add("07");
            Hours.Add("08");
            Hours.Add("09");
            Hours.Add("10");
            Hours.Add("11");
            Hours.Add("12");
            Hours.Add("13");
            Hours.Add("14");
            Hours.Add("15");
            Hours.Add("16");
            Hours.Add("17");
            Hours.Add("18");

            Minutes.Add("00");
            Minutes.Add("15");
            Minutes.Add("30");
            Minutes.Add("45");
        }

        internal DoctorsViewModel DoctorsVM { get => doctorsVM; set => doctorsVM = value; }
        public List<String> Hours { get => hours; set => hours = value; }
        public List<String> Minutes { get => minutes; set => minutes = value; }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (FrameManager.getInstance().SideFrame.CanGoBack)
                FrameManager.getInstance().SideFrame.GoBack();
        }

        private void dataGridAppointmentDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridAppointmentDoctors_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(AppointmentDatePicker == null || StartHours==null || EndHours==null || StartMinutes==null || EndMinutes == null)
            {
                return;
            }
            else if(StartHours.SelectedItem == null || EndHours.SelectedItem == null || StartMinutes.SelectedItem == null || EndMinutes.SelectedItem == null)
            {
                return;
            }

            DateTime selectedDate = AppointmentDatePicker.SelectedDate.Value;
            DateTime currentStartDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, Convert.ToInt32(StartHours.SelectedItem), Convert.ToInt32(StartMinutes.SelectedItem), 0);
            DateTime currentEndDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, Convert.ToInt32(EndHours.SelectedItem), Convert.ToInt32(EndMinutes.SelectedItem), 0);

            if (!previousStartDate.Equals(currentStartDate) || !previousEndDate.Equals(currentEndDate))
            {
                if (DateTime.Compare(currentStartDate, currentEndDate) >= 0)  // if startTime is later or the same as endTime
                {
                    errTimeInvalid.Visibility = Visibility.Visible;
                }
                else
                {
                    errTimeInvalid.Visibility = Visibility.Collapsed;
                }
                //Console.WriteLine("START> " + currentStartDate + "\tEND> " + currentEndDate);
                previousStartDate = currentStartDate;
                previousEndDate = currentEndDate;

                TimeInterval time = new TimeInterval(currentStartDate, currentEndDate);

                doctorsVM.LoadAllAvailableDoctors(time);
                checkDoctors();

                roomsVM.LoadAllAvailableRooms(time);
                checkRooms();
            }
        }

        private void checkDoctors()
        {
            if(doctorsVM.Doctors != null)
            {
                if(doctorsVM.Doctors.Count > 0)
                {
                    errNoAvailableDoctors.Visibility = Visibility.Collapsed;
                }
                else
                {
                    errNoAvailableDoctors.Visibility = Visibility.Visible;
                }
            }
            else
            {
                errNoAvailableDoctors.Visibility = Visibility.Visible;
            }
        }

        private void checkPatients()
        {
            if (patientsVM.Patients != null)
            {
                if (patientsVM.Patients.Count > 0)
                {
                    errNoPatients.Visibility = Visibility.Collapsed;
                }
                else
                {
                    errNoPatients.Visibility = Visibility.Visible;
                }
            }
            else
            {
                errNoPatients.Visibility = Visibility.Visible;
            }
        }

        private void checkRooms()
        {
            if (roomsVM.Rooms != null)
            {
                if (roomsVM.Rooms.Count > 0)
                {
                    errNoAvailableRooms.Visibility = Visibility.Collapsed;
                }
                else
                {
                    errNoAvailableRooms.Visibility = Visibility.Visible;
                }
            }
            else
            {
                errNoAvailableRooms.Visibility = Visibility.Visible;
            }
        }

        private void dataGridAppointmentPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridAppointmentPatients_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            DateTime selectedDate = AppointmentDatePicker.SelectedDate.Value;
            DateTime currentStartDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, Convert.ToInt32(StartHours.SelectedItem), Convert.ToInt32(StartMinutes.SelectedItem), 0);
            DateTime currentEndDate = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, Convert.ToInt32(EndHours.SelectedItem), Convert.ToInt32(EndMinutes.SelectedItem), 0);

            if (DateTime.Compare(currentStartDate, currentEndDate) >= 0)
            {
                // TODO: Raise time interval invalid error
                return;
            }

            TimeInterval time = new TimeInterval(currentStartDate, currentEndDate);

            Doctor doctor = _mode == CREATE ? (Doctor)dataGridAppointmentDoctors.SelectedItem : _appointmentUpdate.DoctorInAppointment;
            Patient patient = _mode == CREATE ? (Patient)dataGridAppointmentPatients.SelectedItem : _appointmentUpdate.Patient;
            Room room = (Room)dataGridAppointmentRooms.SelectedItem == null ? _appointmentUpdate.Room : (Room)dataGridAppointmentRooms.SelectedItem;

            if(doctor!=null && patient!=null && room != null)
            {
                //TODO: Try create new appointment
                if(_mode == CREATE)
                {
                    MessageBoxResult r = MessageBox.Show(time.StartTime.ToString("dd.MM.yyyy. HH:mm") + " - " + time.EndTime.ToString("HH:mm") + "\nPatient: " + patient.FullName + "\nDoctor: " + doctor.FullName + "\nRoom: " + room.RoomNumber + "\n" + AppointmentType.checkup,
                        "Create Appointment?",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);
                    if(r == MessageBoxResult.Yes)
                    {
                        Appointment newAppointment = new Appointment(doctor, patient, room, AppointmentType.checkup, time);
                        try
                        {
                            AppResources.getInstance().appointmentController.Create(newAppointment);

                            if (FrameManager.getInstance().SideFrame.CanGoBack)
                                FrameManager.getInstance().SideFrame.GoBack();
                            Refresh();
                        }
                        catch(AppointmentServiceException ex)
                        {
                            MessageBox.Show(ex.Message, "Create Appointment Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else if(_mode == UPDATE)
                {
                    if (dataGridAppointmentRooms.SelectedItem != null)
                        _appointmentUpdate.Room = (Room)dataGridAppointmentRooms.SelectedItem;
                    if(!time.Equals(_appointmentUpdate.TimeInterval))
                        if(!doctorsVM.IsDoctorAvailable(_appointmentUpdate.DoctorInAppointment, time))
                        {
                            MessageBox.Show("Doctor is not available for selected time",
                                            "Appointment Error",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Error);
                                                return;
                        }

                    _appointmentUpdate.TimeInterval = time;

                    MessageBoxResult result = MessageBox.Show(time.StartTime.ToString("dd.MM.yyyy. HH:mm") + " - " + time.EndTime.ToString("HH:mm") + "\nPatient: " + patient.FullName + "\nDoctor: " + doctor.FullName + "\nRoom: " + room.RoomNumber + "\n" + AppointmentType.checkup,
                        "Reschedule Appointment?",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);
                    if(result == MessageBoxResult.Yes)
                    {
                        _appointmentUpdate.Canceled = false;
                        try
                        {
                            AppResources.getInstance().appointmentController.Update(_appointmentUpdate);
                            if (FrameManager.getInstance().SideFrame.CanGoBack)
                                FrameManager.getInstance().SideFrame.GoBack();
                            Refresh();
                        }
                        catch(AppointmentServiceException ex)
                        {
                            MessageBox.Show(ex.Message, "Appointment Update Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }

            }
            else
            {
                //TODO: Raise error, all entities must be filled
                MessageBox.Show("Doctor, patient and room must be filled.", "Appointment Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Refresh()
        {
            AppointmentsPage.GetInstance().Refresh();
            CancelledAppointmentsPage.GetInstance().Refresh();
        }
    }
}
