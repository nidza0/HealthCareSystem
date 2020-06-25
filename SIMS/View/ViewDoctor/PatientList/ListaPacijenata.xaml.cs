﻿using SIMS.Model.UserModel;
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
    /// Interaction logic for ListaPacijenata.xaml
    /// </summary>
    public partial class ListaPacijenata : Page
    {

        //private List<string> data = new List<string>();
        private List<Patient> data = new List<Patient>();

        public ListaPacijenata()
        {
            InitializeComponent();
            fillList();
        }

        private void fillList()
        {
            AppResources ar = AppResources.getInstance();
            //patients = AppResources.getInstance().patientRepository.GetPatientByDoctor(AppResources.getLoggedInUser()).ToList();
            data = AppResources.getInstance().patientController.GetPatientByDoctor(AppResources.getLoggedInUser()).ToList();
            
            PacijentiSpisak.ItemsSource = data;
            
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
                PacijentiSpisak.ItemsSource = data.Where(patient => patient.Name.Trim().ToLower().StartsWith(UnosZaSearch.Text.ToLower().Trim()));
            else
                resetDataGrid();
                
        }

        private void resetDataGrid()
        {
            PacijentiSpisak.ItemsSource = data;
        }



        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
        }

        private void PacijentiSpisak_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            SelektovaniPacijent next = new SelektovaniPacijent((Patient) PacijentiSpisak.SelectedItem);

            NavigationService.Navigate(next);
        }

        private void UnosZaSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                filterResults();
            }
        }

        private void PacijentiSpisak_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelektovaniPacijent next = new SelektovaniPacijent((Patient)PacijentiSpisak.SelectedItem);

            NavigationService.Navigate(next);
        }

        private void UnosZaSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterResults();
        }
    }
}
