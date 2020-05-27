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
    /// Interaction logic for MainWindowSecretary.xaml
    /// </summary>
    public partial class MainWindowSecretary : Window
    {
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        public MainWindowSecretary()
        {
            InitializeComponent();
            InitializeDateTime();
            CentralFrameNavigator.getInstance().setFrame(CentralFrame);
            InitializeSidebar();
        }

        private void InitializeSidebar()
        {
            btn_home.IsChecked = true;
        }

        private void InitializeDateTime()
        {
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;

            lbl_time.Content = d.ToShortTimeString();//d.Hour + " : " + d.Minute + " : " + d.Second;
            lbl_date.Content = d.DayOfWeek + ", " + d.ToShortDateString();

        }

        private void btn_newpatient_Click(object sender, RoutedEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            CentralFrameNavigator.getInstance().changeContent(btn);
        }

        private void btn_sidebar_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            CentralFrameNavigator.getInstance().changeContent(btn);
        }

        private void btn_newappointment_Click(object sender, RoutedEventArgs e)
        {
            SideFrame.Content = new NewAppointmentPageSecretary();
        }
    }
}
