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

namespace SIMS.View.ViewDoctor.Functions
{
    /// <summary>
    /// Interaction logic for ValidacijaOdredjenogLeka.xaml
    /// </summary>
    public partial class ValidacijaOdredjenogLeka : Page
    {
        ///private Model.Lek_EXAMPLE _lek;
        /*public Model.Lek_EXAMPLE Lek
        {
            get { return _lek; }
            set { if (value != _lek) _lek = value; }
        }
        */
        private Medicine medicine;
        public ValidacijaOdredjenogLeka(Medicine lek)
        {
            InitializeComponent();
            medicine = lek;
            setFields();
        }
        


        private void setFields()
        {
            /*   if (Lek.Doza == null && Lek.AktivniSastojak == null && Lek.Naziv == null && Lek.Tip == null)
               {
                   MessageBoxButton button = MessageBoxButton.OK;
                   string caption = "Nije prenet lek";
                   string messageBoxText = "Niste preneli validan lek.";
                   MessageBox.Show(messageBoxText, caption, button);
                   NavigationService.GoBack();
               }
               else
               {
                   DrugName_TextBox.Text = Lek.Naziv;
                   DrugType_TextBox.Text = Lek.Tip;
                   Ingredient_TextBox.Text = Lek.AktivniSastojak;
                   UsedFor_TextBox.Text = "/";
               }
               */
            DrugName_TextBox.Text = medicine.Name;
            DrugType_TextBox.SelectedIndex = (int) medicine.MedicineType;
            if(medicine.Ingredient.Count > 0) { 
                Ingredient_TextBox.Text = medicine.Ingredient[0].ToString();
            } else
            {
                Ingredient_TextBox.Text = "/";
            }

            if (medicine.UsedFor.Count> 0) { 
                UsedFor_TextBox.Text = medicine.UsedFor[0].ToString();
            } else
            {
                UsedFor_TextBox.Text = "/";
            }

        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ValidacijaLekova());
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {
            correctFields();
            MessageBoxButton button = MessageBoxButton.OK;
            string caption = "Uspešno validiran lek";
            string messageBoxText = "Uspešno ste validirali "/* + Lek.Naziv + "."*/;
            MessageBox.Show(messageBoxText, caption, button);
            NavigationService.Navigate(new ValidacijaLekova());
        }

        private void correctFields()
        {
            /* Lek.Naziv = DrugName_TextBox.Text;
             Lek.Tip = DrugType_TextBox.Text;
             Lek.AktivniSastojak = Ingredient_TextBox.Text;
             Lek.Valid = true;
             //updateDataGrid();
             */

            medicine.Name = DrugName_TextBox.Text;
            medicine.MedicineType = (MedicineType) DrugType_TextBox.SelectedIndex;
            medicine.Ingredient.Add(new Ingredient(Ingredient_TextBox.Text));
            //medicine.UsedFor[0] = new Disease(UsedFor_TextBox.Text);
            flushData();
        }



        private void flushData()
        {

        }

        private void CANCEL_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ValidacijaLekova());
        }
    }
}

