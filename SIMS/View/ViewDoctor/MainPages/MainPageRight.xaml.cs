using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        private Patient recipient;
        public MainPageRight()
        {
            Doctor doc = AppResources.getInstance().getLoggedInDoctor();
            
            InitializeComponent();
            Name_TextBlock.Text = doc.Name + " " + doc.Surname;
            TipDoktora_TextBlock.Text = doc.DoctorType.ToString();

            Contacts_DataGrid.ItemsSource = AppResources.getInstance().patientRepository.GetPatientByDoctor(AppResources.getInstance().getLoggedInDoctor()).ToList();

            SendBtn.IsEnabled = false;

            UpdateData();
            
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
                    startPoint = endP;
                    NavigationService.Navigate(new MainPageCenter());
                }
                
            }
            
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            
            cp.addSentMessage(messageText.Text, DateTime.Now.ToString(), AppResources.getInstance().getLoggedInDoctor(), recipient);
            MainFrame.Content = cp;
            messageText.Text = "";
        }

        private void Contacts_DataGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if((Patient)Contacts_DataGrid.SelectedItem == null)
            {
                cp = new ConversationPage();
            }
            recipient = (Patient)Contacts_DataGrid.SelectedItem;
            cp = new ConversationPage(AppResources.getInstance().getLoggedInDoctor(), recipient);
            
            SendBtn.IsEnabled = true;
        }
    }
}
