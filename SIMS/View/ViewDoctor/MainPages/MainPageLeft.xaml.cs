using SIMS.Model.PatientModel;
using SIMS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace SIMS.View.ViewDoctor.MainPages
{
    /// <summary>
    /// Interaction logic for MainPageLeft.xaml
    /// </summary>
    public partial class MainPageLeft : Page
    {
        private Point startPoint;
        private Calendar cal;
        public MainPageLeft()
        {
            InitializeComponent();
            ActiveDate.SelectedDate = DateTime.Now;
            fillFrame();
            cal = new Calendar();
        }

        private void fillFrame()
        {
            //List<Appointment> data = AppResources.getInstance().appointmentRepository.GetAppointmentsByDoctor(AppResources.getLoggedInUser()).Where(
            //    app => app.TimeInterval.StartTime.Date == ActiveDate.SelectedDate.Value.Date).ToList();

            List<Appointment> data = new List<Appointment>();
            data = AppResources.getInstance().appointmentController.GetAppointmentsByDoctor(AppResources.getInstance().getLoggedInDoctor()).Where(app =>
            app.TimeInterval.StartTime == ActiveDate.SelectedDate).ToList();
            //data.Add(new Appointment(151, AppResources.getLoggedInUser(), AppResources.getInstance().patientRepository.GetPatientByDoctor(AppResources.getLoggedInUser()).SingleOrDefault(patient => patient.Name == "Mika"),
            //    new Model.UserModel.Room("111A", false, 1, Model.UserModel.RoomType.EXAMINATION), AppointmentType.checkup, new TimeInterval(DateTime.Now.AddHours(1), DateTime.Now.AddHours(1).AddMinutes(15))));

            foreach(Appointment temp in data)
            {
                cal = new Calendar();
                Appointments.AppointmentView aw = new Appointments.AppointmentView(Checkups.Width, temp);
                cal.AddAppointment(aw);
                Checkups.Content = cal;
            }

            
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            /*
            Point currPos = e.GetPosition(null);
            Vector differential = currPos - startPoint;

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(differential.X) > SystemParameters.MinimumHorizontalDragDistance)
            {
                if (differential.X > 0)
                    NavigationService.Navigate(new MainPageCenter());
                
            }*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PacijentiSpisak_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void PacijentiSpisak_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void SpisakObaveza_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void SpisakObaveza_MouseMove(object sender, MouseEventArgs e)
        {
            /*Point current = e.GetPosition(null);

            Vector diff = current - startPoint;

            if(Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance)
            {
                if(diff.X > 0)
            }
            */

            
        }

        private void SpisakObaveza_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point endP = e.GetPosition(null);
            if(Math.Abs(endP.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance) { 
                if (endP.X - startPoint.X > 0)
                {
                    DateTime selectedDate = ActiveDate.SelectedDate.GetValueOrDefault();
                    ActiveDate.SelectedDate = selectedDate.Date.AddDays(-1);
                } else if (endP.X - startPoint.X < 0)
                {
                    DateTime selectedDate = ActiveDate.SelectedDate.GetValueOrDefault();
                    ActiveDate.SelectedDate = selectedDate.AddDays(1);
                }
            }

        }

        private void ActiveDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            fillFrame();
        }

        private void Page_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Page_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point endP = e.GetPosition(null);
            if (Math.Abs(endP.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance)
            {
                if (endP.X - startPoint.X < 0)
                {
                    NavigationService.Navigate(new MainPageCenter());
                }
                
            }
        }
    }
}
