using SIMS.Model.UserModel;
using SIMS.View.ViewSecretary.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SIMS.View.ViewSecretary.Pages
{
    /// <summary>
    /// Interaction logic for FeedbackPage.xaml
    /// </summary>
    public partial class FeedbackPage : Page, INotifyPropertyChanged
    {
        private int mode;
        private readonly int CREATE = 0;
        private readonly int UPDATE = 1;

        private Question question1;
        private Question question2;
        private Question question3;
        private Question question4;

        private string comment1;
        private string comment2;
        private string comment3;
        private string comment4;

        private Feedback updateFeedback;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public Question Question1 { get => question1; set { question1 = value; NotifyPropertyChanged("Question1"); } }
        public Question Question2 { get => question2; set { question2 = value; NotifyPropertyChanged("Question2"); } }
        public Question Question3 { get => question3; set { question3 = value; NotifyPropertyChanged("Question3"); } }
        public Question Question4 { get => question4; set { question4 = value; NotifyPropertyChanged("Question4"); } }

        public string Comment1 { get => comment1; set { comment1 = value; NotifyPropertyChanged("Comment1"); } }
        public string Comment2 { get => comment2; set { comment2 = value; NotifyPropertyChanged("Comment2"); } }
        public string Comment3 { get => comment3; set { comment3 = value; NotifyPropertyChanged("Comment3"); } }
        public string Comment4 { get => comment4; set { comment4 = value; NotifyPropertyChanged("Comment4"); } }

        public FeedbackPage()
        {
            InitializeComponent();
            mode = CREATE;

            LoadQuestions();
            btnDelete.Visibility = Visibility.Collapsed;
            DataContext = this;
        }

        private void LoadQuestions()
        {
            var questions = AppResources.getInstance().feedbackController.GetQuestions();
            Question1 = questions.FirstOrDefault(q => q.GetId() == 1);
            Question2 = questions.FirstOrDefault(q => q.GetId() == 2);
            Question3 = questions.FirstOrDefault(q => q.GetId() == 3);
            Question4 = questions.FirstOrDefault(q => q.GetId() == 4);
        }

        public FeedbackPage(Feedback fb)
        {
            InitializeComponent();
            mode = UPDATE;
            updateFeedback = fb;

            btnDelete.Visibility = Visibility.Visible;
            SetProperties();
            DataContext = this;
        }

        private void SetProperties()
        {
            foreach(Question q in updateFeedback.Rating.Keys)
            {
                if(q.GetId() == 1)
                {
                    Question1 = q;
                    Comment1 = updateFeedback.Rating[q].Comment;
                    rating1.Value = updateFeedback.Rating[q].Stars;
                }
                if (q.GetId() == 2)
                {
                    Question2 = q;
                    Comment2 = updateFeedback.Rating[q].Comment;
                    rating2.Value = updateFeedback.Rating[q].Stars;
                }
                if (q.GetId() == 3)
                {
                    Question3 = q;
                    Comment3 = updateFeedback.Rating[q].Comment;
                    rating3.Value = updateFeedback.Rating[q].Stars;
                }
                if (q.GetId() == 4)
                {
                    Question4 = q;
                    Comment4 = updateFeedback.Rating[q].Comment;
                    rating4.Value = updateFeedback.Rating[q].Stars;
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (FrameManager.getInstance().SideFrame.CanGoBack)
                FrameManager.getInstance().SideFrame.GoBack();
        }

        private void btnTurnIn_Click(object sender, RoutedEventArgs e)
        {
            if(mode == CREATE)
            {
                Dictionary<Question, Rating> rating = new Dictionary<Question, Rating>();
                rating.Add(Question1, new Rating(Comment1, rating1.Value));
                rating.Add(Question2, new Rating(Comment2, rating2.Value));
                rating.Add(Question3, new Rating(Comment3, rating3.Value));
                rating.Add(Question4, new Rating(Comment4, rating4.Value));
                Feedback fb = new Feedback(UserViewModel.GetInstance().LoggedInUser, "", rating);
                if(UserViewModel.GetInstance().LoggedInUser == null)
                {
                    Console.WriteLine("Logged in user == null");
                    return;
                }
                AppResources.getInstance().feedbackController.Create(fb);
                if (FrameManager.getInstance().SideFrame.CanGoBack)
                    FrameManager.getInstance().SideFrame.GoBack();
            }
            else
            {
                Dictionary<Question, Rating> rating = new Dictionary<Question, Rating>();
                rating.Add(Question1, new Rating(Comment1, rating1.Value));
                rating.Add(Question2, new Rating(Comment2, rating2.Value));
                rating.Add(Question3, new Rating(Comment3, rating3.Value));
                rating.Add(Question4, new Rating(Comment4, rating4.Value));
                updateFeedback.Rating = rating;
                AppResources.getInstance().feedbackController.Update(updateFeedback);
                if (FrameManager.getInstance().SideFrame.CanGoBack)
                    FrameManager.getInstance().SideFrame.GoBack();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(mode == UPDATE)
            {
                AppResources.getInstance().feedbackController.Delete(updateFeedback);
                if (FrameManager.getInstance().SideFrame.CanGoBack)
                    FrameManager.getInstance().SideFrame.GoBack();
            }
        }
    }
}
