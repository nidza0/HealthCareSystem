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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SIMS.View.ViewDoctor.Functions
{
    /// <summary>
    /// Interaction logic for ValidacijaLekova.xaml
    /// </summary>
    public partial class ValidacijaLekova : Page
    {
        //private int colNum = 0;
        //private List<Model.Lek_EXAMPLE> data;
        private List<Model.PatientModel.Medicine> data;

        public ValidacijaLekova()
        {
            this.DataContext = this;
            InitializeComponent();
            fillDataGrid();
        }

        private void fillDataGrid()
        {
            data = new List<Model.PatientModel.Medicine>();
            data.Add(new Model.PatientModel.Medicine("Eferalgan", 500, MedicineType.TABLET, 100, 1));
            data.Add(new Model.PatientModel.Medicine("Strepsils", 200, MedicineType.TABLET, 100, 1));
            data.Add(new Model.PatientModel.Medicine("Brufen", 500, MedicineType.TABLET, 100, 1));
            lekoviNaValidaciji.ItemsSource = data;
            //data = new Lekovi_EXAMPLE_LIST().getUnvalidated();
            //lekoviNaValidaciji.ItemsSource = data;
        }

        public void updateDataGrid()
        {
            lekoviNaValidaciji.ItemsSource = data;
        }



        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            filterResults();
        }

        private void filterResults()
        {
            if (UnosZaSearch.Text != string.Empty)
                lekoviNaValidaciji.ItemsSource = data.Where(med => med.Name.ToLower().Trim().StartsWith(UnosZaSearch.Text.Trim().ToLower())).ToList();
            else
                updateDataGrid();
        }



        private void lekoviNaValidaciji_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            NavigationService.Navigate(new ValidacijaOdredjenogLeka((Medicine) lekoviNaValidaciji.SelectedItem));
        }

        private void UnosZaSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UnosZaSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
                filterResults();
        }
    }
}
