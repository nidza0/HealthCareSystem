using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SIMS.View.ViewDoctor
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : UserControl
    {
        private int charactersInRow = 28;
        public Message(string text, string dateTime)
        {
            this.Height = ((text.Length * 300 / 18) / 10) + 100;
            
            InitializeComponent();
            this.messageText.Text = text;
            this.messageTime.Text = dateTime;
            
            this.messageText.Text =  Regex.Replace(this.messageText.Text, ".{18}", "$0\n");
            
            //this.TextContainer.
        }
    }
}
