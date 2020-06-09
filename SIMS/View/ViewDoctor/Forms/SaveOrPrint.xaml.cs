using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.View.ViewDoctor.Forms
{
    /// <summary>
    /// Interaction logic for SaveOrPrint.xaml
    /// </summary>
    public partial class SaveOrPrint : Page
    {

        public SaveOrPrint()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, RoutedEventArgs e)
        {
            new SaveFileDialog();
        }

        private void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            var pd = new System.Windows.Forms.PrintDialog();
           
            pd.ShowDialog();
            


        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
