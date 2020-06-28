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

namespace SIMS.View.ViewDoctor.Functions
{
    /// <summary>
    /// Interaction logic for Articles.xaml
    /// </summary>
    public partial class Articles : Page
    {
        List<Article> data;
        public Articles()
        {
            data = new List<Article>();
            InitializeComponent();
            fillDataGrid();
        }

        private void fillDataGrid()
        {
            data = AppResources.getInstance().articleController.GetAll().ToList();
            ArtikliSpisak.ItemsSource = data;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void NoviArtikal_Btn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewArticle());
        }
    }
}
