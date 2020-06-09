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
    /// Interaction logic for MainPageLeft.xaml
    /// </summary>
    public partial class MainPageLeft : Page
    {
        private Point startPoint;
        public MainPageLeft()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            Point currPos = e.GetPosition(null);
            Vector differential = currPos - startPoint;

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(differential.X) > SystemParameters.MinimumHorizontalDragDistance)
            {
                if (differential.X > 0)
                    NavigationService.Navigate(new MainPageCenter());
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PacijentiSpisak_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {

        }

        private void PacijentiSpisak_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
