using SIMS.View.ViewSecretary.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SIMS.View.ViewSecretary
{
    class CentralFrameNavigator
    {
        private static CentralFrameNavigator instance = null;
        private RadioButton previouslyActive = null;
        private RadioButton currentlyActive = null;
        private Frame frame = null;

        private CentralFrameNavigator() { }

        public static CentralFrameNavigator getInstance()
        {
            if (instance == null)
            {
                instance = new CentralFrameNavigator();
            }

            return instance;
        }

        public void setFrame(Frame frame)
        {
            this.frame = frame;
        }

        public void changeContent(RadioButton btn)
        {
            previouslyActive = currentlyActive;
            currentlyActive = btn;

            switch (btn.Name)
            {
                case "btn_home":
                    frame.Content = new HomePageSecretary();
                    break;
                case "btn_appointments":
                    frame.Content = new AppointmentsPageSecretary();
                    break;
                case "btn_cancelledappointments":
                    break;
                case "btn_doctors":
                    break;
                case "btn_patients":
                    frame.Content = new PatientsPageSecretary();
                    break;
                case "btn_profile":
                    frame.Content = new ProfilePageSecretary();
                    break;
                case "btn_inbox":
                    break;
                case "btn_settings":
                    frame.Content = new SettingsPageSecretary();
                    break;
                case "btn_newpatient":
                    frame.Content = new NewPatientPageSecretary();
                    break;
            }
        }

        public void goBack()
        {
            previouslyActive.IsChecked = true;
        }


    }
}
