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

using SIMS.View.ViewPatient.tutorial;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for VideoTutorial.xaml
    /// </summary>
    public partial class VideoTutorial : Window
    {
        private string selectedTutorial;

        public string SelectedTutorial { get => selectedTutorial; set => selectedTutorial = value; }

        public VideoTutorial()
        {
            InitializeComponent();
            this.DataContext = this;
            this.tutorialFrame.Navigate(new tutorialPreview(TutorialEnum.REGISTER));
            this.selectedTutorial = "Registration";
            label.Content = "Registration";
        }

        private void MakeAnAppointmentButton_Checked(object sender, RoutedEventArgs e)
        {
            if(this.tutorialFrame != null)
            {
                this.tutorialFrame.Navigate(new tutorialPreview(TutorialEnum.MAKE_APPOINTMENT));

                label.Content = "Make an appointment";
            }
               
        }

        private void MyAppointments_Checked(object sender, RoutedEventArgs e)
        {
            if (this.tutorialFrame != null)
            {
                this.tutorialFrame.Navigate(new tutorialPreview(TutorialEnum.MY_APPOINTMENTS));

                label.Content = "My appointments";
            }
              
        }

        private void MyTherapyButton_Checked(object sender, RoutedEventArgs e)
        {
            if (this.tutorialFrame != null)
            {
                this.tutorialFrame.Navigate(new tutorialPreview(TutorialEnum.MY_THERAPIES));
                label.Content = "My therapy";
            }
              
        }

        private void MyDiagnosisButton_Checked(object sender, RoutedEventArgs e)
        {
            if (this.tutorialFrame != null)
            {
                this.tutorialFrame.Navigate(new tutorialPreview(TutorialEnum.MY_DIAGNOSIS));

                label.Content = "My diagnosis";
            }
                
        }

        private void EditProfileButton_Checked(object sender, RoutedEventArgs e)
        {
            if (this.tutorialFrame != null)
            {
                this.tutorialFrame.Navigate(new tutorialPreview(TutorialEnum.MY_PROFILE));

                label.Content = "Edit profile";
            }
               
        }


        private void ExportButton_Checked(object sender, RoutedEventArgs e)
        {
            if (this.tutorialFrame != null)
            {
                this.tutorialFrame.Navigate(new tutorialPreview(TutorialEnum.EXPORT_APPOINTMENT));
                label.Content = "Appointments export";
            }
              
        }

        private void RegisterButton_Checked(object sender, RoutedEventArgs e)
        {
            if (this.tutorialFrame != null)
            {
                this.tutorialFrame.Navigate(new tutorialPreview(TutorialEnum.REGISTER));

                label.Content = "Registration";
            }
                
        }
    }
}
