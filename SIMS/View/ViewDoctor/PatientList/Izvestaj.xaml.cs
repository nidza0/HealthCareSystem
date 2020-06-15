using SIMS.Model.PatientModel;
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

namespace SIMS.View.ViewDoctor.PatientList
{
    /// <summary>
    /// Interaction logic for Izvestaj.xaml
    /// </summary>
    public partial class Izvestaj : Page
    {
        private Model.PatientModel.Diagnosis diagnosis;
        public Izvestaj(Model.PatientModel.Diagnosis diag)
        {
            diagnosis = diag;
            InitializeComponent();
            IzvestajODijagnozi.Text = "Izveštaj o dijagnozi - " + diagnosis.DiagnosedDisease.Name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
