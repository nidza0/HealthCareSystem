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
    /// Interaction logic for Recepti.xaml
    /// </summary>
    public partial class Recepti : Page
    {
        Patient patient;
        public Recepti(Patient selected)
        {
            patient = selected;
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
        }

        private void NoviRecept_Button_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Izdati recepti
            NavigationService.Navigate(new NoviRecept(patient));
        }
    }
}
