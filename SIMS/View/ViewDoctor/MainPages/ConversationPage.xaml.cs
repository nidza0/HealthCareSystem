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
        public ConversationPage()
        {
            InitializeComponent();
        }

        public void addSentMessage(string text, string time)
        {
            Message newMessage = new Message(text, time);
            Sent.Children.Add(newMessage);
        }
    }
}
