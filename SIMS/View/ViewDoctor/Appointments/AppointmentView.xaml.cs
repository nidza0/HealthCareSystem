using SIMS.Model.PatientModel;
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

namespace SIMS.View.ViewDoctor.Appointments
{
    /// <summary>
    /// Interaction logic for AppointmentView.xaml
    /// </summary>
    public partial class AppointmentView : UserControl
    {
        public AppointmentView(int width, Appointment appointment)
        {
            this.Width = width;
            InitializeComponent();
            this.Name.Text = appointment.Patient.Name + " " + appointment.Patient.Surname;
            this.Room.Text = appointment.Room.RoomNumber.ToString();
            this.Time.Text = appointment.TimeInterval.StartTime.ToString() + " - " + appointment.TimeInterval.EndTime.ToString();
        }
    }
}
