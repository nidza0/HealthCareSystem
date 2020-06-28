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

namespace SIMS.View.ViewDoctor.PatientList
{
    /// <summary>
    /// Interaction logic for OdaberiPacijenta.xaml
    /// </summary>
    public partial class OdaberiPacijenta : Page
    {

        //  Od from zavisi gde ce dalje preusmeriti nakon selekcije.
        //  Ovako izbegavam da imam 3 razlicite klase za isti page.
        private sources from;
        private Object navigator;
        private List<Patient> data = new List<Patient>();

        public enum sources
        {
            STACIONARNO,
            LABORATORIJSKI,
            SPECIJALISTICKI,
            RECEPTI
        }

        public OdaberiPacijenta(sources from1)
        {
            InitializeComponent();
            from = from1;
            fillList();
        }

        private void fillList()
        {
            data = AppResources.getInstance().patientRepository.GetPatientByDoctor(AppResources.getInstance().getLoggedInDoctor()).ToList();
            patientList.ItemsSource = data;
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            filterResults();
        }

        private void filterResults()
        {
            if (UnosZaSearch.Text != string.Empty)
                patientList.ItemsSource = data.Where(patient => patient.Name.Trim().ToLower().StartsWith(UnosZaSearch.Text.ToLower().Trim()));
            else
                resetDataGrid();
                
        }

        private void resetDataGrid()
        {
            patientList.ItemsSource = data;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
        }



        private void navigate()
        {
            Patient selected = (Patient) patientList.SelectedItem;
            if (from == sources.STACIONARNO)
            {
                navigator = new Functions.UputZaStacionarno(selected);
            }
            else if (from == sources.SPECIJALISTICKI)
            {
                navigator = new Functions.UputZaSpecijalisticko(selected);
            }
            else if (from == sources.LABORATORIJSKI)
            {
                navigator = new Functions.UputZaLaboratoriju(selected);
            }
            else if (from == sources.RECEPTI)
            {
                navigator = new Functions.NoviRecept(selected);
            }

            NavigationService.Navigate(navigator);
        }

        private void patientList_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            navigate();
        }

        private void UnosZaSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                filterResults();
            }
        }

        private void UnosZaSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterResults();
        }
    }
}
