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

namespace SIMS.View.ViewDoctor.Functions
{
    /// <summary>
    /// Interaction logic for NewArticle.xaml
    /// </summary>
    public partial class NewArticle : Page
    {
        public NewArticle()
        {
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            AppResources.getInstance().articleController.Create(new Model.UserModel.Article(Title_Box.Text, ShortDesc_Box.Text, Text_Box.Text, AppResources.getInstance().getLoggedInDoctor()));
            NavigationService.GoBack();
        }
    }
}
