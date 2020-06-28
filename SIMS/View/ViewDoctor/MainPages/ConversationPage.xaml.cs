using SIMS.Model.UserModel;
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

namespace SIMS.View.ViewDoctor.MainPages
{
    /// <summary>
    /// Interaction logic for ConversationPage.xaml
    /// </summary>
    public partial class ConversationPage : Page
    {
        Doctor doctor;
        Patient patient;

        public ConversationPage()
        {

        }

        public ConversationPage(Doctor doctor, Patient patient)
        {
            this.doctor = doctor;
            this.patient = patient;

            InitializeComponent();

            fillMessages(doctor, patient);
        }

        private void fillMessages(Doctor doctor, Patient patient)
        {

            // Recieved
            foreach (SIMS.Model.UserModel.Message temp in AppResources.getInstance().messageController.GetRecieved(doctor).Where(msg => msg.Sender.GetId().Equals(patient.GetId())))
            {
                Recieved.Children.Add(new Message(temp.Text, DateTime.Now.ToString()));

            }
                // Recieved
                foreach (SIMS.Model.UserModel.Message temp in AppResources.getInstance().messageController.GetSent(doctor).Where(msg => msg.Recipient.GetId().Equals(patient.GetId())))
                {
                    Sent.Children.Add(new Message(temp.Text, DateTime.Now.ToString()));
                }
            }

        public void addSentMessage(string text, string time, Doctor sender, Patient recipient)
        {
            Message newMessage = new Message(text, time);
            SIMS.Model.UserModel.Message msg = new Model.UserModel.Message(text, recipient, sender);
            AppResources.getInstance().messageController.Create(msg);
            Sent.Children.Add(newMessage);
        }

        public void addRecievedMessage(Doctor recipient, Patient sender)
        {
            foreach(SIMS.Model.UserModel.Message temp in AppResources.getInstance().messageController.GetRecieved(recipient).Where(msg => msg.Sender.GetId().Equals(sender.GetId())))
            {
                Recieved.Children.Add(new Message(temp.Text, DateTime.Now.ToString()));
            }
        }
    }
}
