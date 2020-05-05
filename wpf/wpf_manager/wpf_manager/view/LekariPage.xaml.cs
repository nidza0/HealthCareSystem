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

namespace wpf_manager.view
{
    /// <summary>
    /// Interaction logic for LekariPage.xaml
    /// </summary>
    public partial class LekariPage : Page
    {
        public static List<Model.Doctor> doctors = new List<Model.Doctor>();

        public LekariPage()
        {
            Model.Doctor Ted = new Model.Doctor("Ted", "Mosby", @"../images/doc11.jpg", "8:00","15:00","Kardiologija");
            Model.Doctor Marshall = new Model.Doctor("Marshall", "Ericssen", "../images/doc12.jpg", "9:00", "14:00", "Kardiologija");
            Model.Doctor Barney = new Model.Doctor("Barney", "Stinson", "../images/doc13.jpg", "12:00", "13:00", "ORL");
            Model.Doctor Jon = new Model.Doctor("Jon", "Snow", @"../images/doc21.jpg", "7:00", "18:00", "Pulmolog");
            Model.Doctor Daenerys = new Model.Doctor("Daenerys", "Targaryen", @"../images/doc22.jpg", "8:00", "15:00", "Porodiliste");
            Model.Doctor Ned = new Model.Doctor("Ned", "Stark", @"../images/doc23.jpg", "6:00", "11:00", "Psihologija");
            Model.Doctor Leia = new Model.Doctor("Leia", "Skywalker", @"../images/doc31.jpg", "15:00", "22:00", "Pedijatrija");
            Model.Doctor Luke = new Model.Doctor("Luke", "Skywalker", @"../images/doc32.jpg", "8:00", "15:00", "Pedijatrija");
            Model.Doctor Han = new Model.Doctor("Han", "Solo", @"../images/doc33.jpg", "8:00", "15:00", "Portir");

            doctors.Add(Ted);
            doctors.Add(Marshall);
            doctors.Add(Barney);
            doctors.Add(Jon);
            doctors.Add(Daenerys);
            doctors.Add(Ned);
            doctors.Add(Leia);
            doctors.Add(Luke);
            doctors.Add(Han);

            InitializeComponent();

            MosaicPanel.Visibility = Visibility.Visible;
        }

        private void ListButton_Click(object sender, RoutedEventArgs e)
        {
            MosaicPanel.Visibility = Visibility.Hidden;
        }

        private void MosaicButton_Click(object sender, RoutedEventArgs e)
        {
            MosaicPanel.Visibility = Visibility.Visible;
        }
    }
}
