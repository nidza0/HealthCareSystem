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

namespace SIMS.View.ViewDoctor.Functions.Izvestaj
{
    /// <summary>
    /// Interaction logic for ListaDijagnozaZaPacijenta.xaml
    /// </summary>
    public partial class ListaDijagnozaZaPacijenta : Page
    {
        private Model.PatientModel.Diagnosis selektovanaDijagnoza;
        private Model.UserModel.Patient selektovaniPacijent;
        public ListaDijagnozaZaPacijenta(Model.UserModel.Patient selektovaniPacijent)
        {
            InitializeComponent();
            this.selektovaniPacijent = selektovaniPacijent;
        }

        private void DijagnozeSpisak_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var converter = new Utility.Converter.IzvestajConverter(selektovaniPacijent, selektovanaDijagnoza);
            string output = converter.output;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        
    }
}
