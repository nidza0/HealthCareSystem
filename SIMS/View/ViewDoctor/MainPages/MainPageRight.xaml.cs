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
    /// Interaction logic for MainPageRight.xaml
    /// </summary>
    public partial class MainPageRight : Page
    {
        private Point startPoint;
        //private Model.User user;
        private ConversationPage cp;
        public MainPageRight()
        {
            InitializeComponent();
            //user = new DummyDoc().getUser();
            UpdateData();
            cp = new ConversationPage();
        }

        private void UpdateData()
        {
           /* Name_TextBlock.Text = user.Name + " " + user.Surname;
            AddedInfo_TextBlock.Text = user.DocType;
            */
        }

        private void CenterHomeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {/*
            Point currPos = e.GetPosition(null);
            Vector differential = currPos - startPoint;

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(differential.X) > SystemParameters.MinimumHorizontalDragDistance)
            {
                if (differential.X < 0)
                    NavigationService.Navigate(new MainPageCenter());
                
            }
            */
        }

        private void Page_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Point endP = e.GetPosition(null);
            if (Math.Abs(endP.X - startPoint.X) > SystemParameters.MinimumHorizontalDragDistance)
            {
                if (endP.X - startPoint.X > 0)
                {
                    NavigationService.Navigate(new MainPageCenter());
                }
                
            }
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            
            cp.addSentMessage(messageText.Text, DateTime.Now.ToString());
            MainFrame.Content = cp;
            messageText.Text = "";
        }
    }
}
