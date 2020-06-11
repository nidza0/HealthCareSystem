﻿using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
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
    /// Interaction logic for InventoryAddingPage.xaml
    /// </summary>
    public partial class InventoryAddingPage : Page
    {
        private bool name = false;
        private bool inStock = false;
        private bool MinInput = false;

        private static long id = 1;

        public InventoryAddingPage()
        {
            InitializeComponent();

            dodajButton.IsEnabled = false;

            initCombo();
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
            foreach (Room room in Login.rooms)
            {
                roomCombo.Items.Add(room.GetId());
            }
            roomCombo.SelectedIndex = 0;
        }

        private void inStockInput_LostFocus(object sender, RoutedEventArgs e)
        {
            if(verifyNumber(inStockInput.Text))
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
            if(verifyNumber(minInput.Text))
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
            if (!Regex.Match(number,"^[1-9][0-9]*$").Success)
                return true;
            return false;
        }

        private void checkButton()
        {
            if (name && inStock && MinInput)
                dodajButton.IsEnabled = true;
            else
                dodajButton.IsEnabled = false;
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            InventoryItem item = new InventoryItem(id, nameInput.Text, int.Parse(inStockInput.Text), int.Parse(minInput.Text), Login.rooms[roomCombo.SelectedIndex]);
            id++;

            Login.items.Add(item);

            NavigationService.Navigate(new InventoryOverviewPage());
        }
    }
}
