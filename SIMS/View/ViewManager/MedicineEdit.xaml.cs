using SIMS.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace SIMS.View.ViewManager
{
    /// <summary>
    /// Interaction logic for MedicineEdit.xaml
    /// </summary>
    public partial class MedicineEdit : Page
    {
        private bool name = false;
        private bool inStock = false;
        private bool MinInput = false;
        private bool snaga = false;

        private AppResources appResources;

        private static int id = 2;

        private Medicine editedMedicine;

        public MedicineEdit(Medicine med)
        {
            InitializeComponent();

            appResources = AppResources.getInstance();
      
            initCombo();

            nameInput.Text = med.Name;
            weightInput.Text = med.Strength.ToString();
            minInput.Text = med.MinNumber.ToString();
            inStockInput.Text = med.InStock.ToString();

            editedMedicine = appResources.medicineController.GetByID(med.GetId());

        }
        private void nameInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (verifyName(nameInput.Text.ToString()))
            {
                nameInput.Background = Brushes.PaleVioletRed;
                name = false;
            }
            else
            {
                nameInput.Background = Brushes.Transparent;
                name = true;
                checkButton();
            }
        }

        private void initCombo()
        {
            tipCombo.Items.Add("Pilula");
            tipCombo.Items.Add("Intravenozno");
            tipCombo.Items.Add("Tečno");
            tipCombo.Items.Add("Tableta");
            tipCombo.Items.Add("Topical medicine");
            tipCombo.Items.Add("Kapi");
            tipCombo.Items.Add("Supozitroriji");
            tipCombo.Items.Add("Inhalacija");
            tipCombo.Items.Add("Injekcija");

            tipCombo.SelectedIndex = 0;
        }

        private void inStockInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (verifyNumber(inStockInput.Text))
            {
                inStockInput.Background = Brushes.PaleVioletRed;
                inStock = false;
            }
            else
            {
                inStockInput.Background = Brushes.Transparent;
                inStock = true;
                checkButton();
            }
        }



        private void minInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (verifyNumber(minInput.Text))
            {
                minInput.Background = Brushes.PaleVioletRed;
                MinInput = false;
            }
            else
            {
                minInput.Background = Brushes.Transparent;
                MinInput = true;
                checkButton();
            }
        }
        /*long id,string name, int inStock, int minNumber, Room room*/

        private bool verifyName(String name)
        {
            if (!Regex.Match(name, "^[0-9 a-zA-Z]*$").Success)
                return true;
            return false;
        }

        private bool verifyNumber(String number)
        {
            if (!Regex.Match(number, "^[1-9][0-9]*$").Success)
                return true;
            return false;
        }

        private void checkButton()
        {
            dodajButton.IsEnabled = true;
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            MedicineType medType = MedicineType.DROPS;

            switch (tipCombo.SelectedIndex)
            {
                case 0:
                    medType = MedicineType.PILL;
                    break;
                case 1:
                    medType = MedicineType.IV;
                    break;
                case 2:
                    medType = MedicineType.LIQUID;
                    break;
                case 3:
                    medType = MedicineType.TABLET;
                    break;
                case 4:
                    medType = MedicineType.TOPICAL_MEDICINE;
                    break;
                case 5:
                    medType = MedicineType.DROPS;
                    break;
                case 6:
                    medType = MedicineType.SUPPOSITORIES;
                    break;
                case 7:
                    medType = MedicineType.INHALERS;
                    break;
                case 8:
                    medType = MedicineType.INJECTIONS;
                    break;
            }

            editedMedicine.Name = nameInput.Text;
            editedMedicine.InStock = int.Parse(inStockInput.Text);
            editedMedicine.MinNumber = int.Parse(minInput.Text);
            editedMedicine.MedicineType = medType;
            editedMedicine.Strength = double.Parse(weightInput.Text);

            appResources.medicineController.Update(editedMedicine);

            NavigationService.Navigate(new MedicineOverviewPage());
        }
        private void weightInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if (verifyDouble(weightInput.Text))
            {
                weightInput.Background = Brushes.PaleVioletRed;
                snaga = false;
            }
            else
            {
                weightInput.Background = Brushes.Transparent;
                snaga = true;
                checkButton();
            }
        }

        private bool verifyDouble(String number)
        {
            if (!Regex.Match(number, "^[1-9][0-9]*$").Success)
                return true;
            return false;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}
