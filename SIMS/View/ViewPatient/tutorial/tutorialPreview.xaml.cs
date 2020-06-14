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

namespace SIMS.View.ViewPatient.tutorial
{
    /// <summary>
    /// Interaction logic for tutorialPreview.xaml
    /// </summary>
    public partial class tutorialPreview : Page
    {
        private string videoPath;

        private string basePath = "View/ViewPatient/tutorial/videos/";
        public tutorialPreview(TutorialEnum tutorialEnum)
        {
            switch (tutorialEnum)
            {
                case TutorialEnum.EXPORT_APPOINTMENT:
                    videoPath = basePath + "exportAppointments.avi";
                    break;
                case TutorialEnum.MAKE_APPOINTMENT:
                    videoPath = basePath + "makeAnAppointment.avi";
                    break;
                case TutorialEnum.MY_APPOINTMENTS:
                    videoPath = basePath + "myAppointments.avi";
                    break;
                case TutorialEnum.MY_DIAGNOSIS:
                    videoPath = basePath + "myDiagnosis.avi";
                    break;
                case TutorialEnum.MY_PROFILE:
                    videoPath = basePath + "myProfile.avi";
                    break;
                case TutorialEnum.MY_THERAPIES:
                    videoPath = basePath + "myTherapies.avi";
                    break;
                case TutorialEnum.REGISTER:
                    videoPath = basePath + "register.avi";
                    break;
            }
            this.DataContext = this;
            InitializeComponent();



        }

        public string VideoPath { get => videoPath; set => videoPath = value; }
    }
}
