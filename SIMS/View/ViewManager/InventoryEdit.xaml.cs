using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using SIMS.Util;
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
    /// Interaction logic for InventoryEdit.xaml
    /// </summary>
    public partial class InventoryEdit : Page
    {
        private bool name = false;
        private bool inStock = false;
        private bool MinInput =false;

        private InventoryItem editedItem;
        private AppResources appResources;



        public InventoryEdit(InventoryItem item)
        {
            InitializeComponent();

            dodajButton.IsEnabled = false;

            nameInput.Text = item.Name;
            inStockInput.Text = item.InStock.ToString();
            appResources = AppResources.getInstance();
            minInput.Text = item.MinNumber.ToString();
            initCombo();

            editedItem = item;

            
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
            foreach (Room room in appResources.roomController.GetAll())
            {
                roomCombo.Items.Add(room.RoomNumber);
            }
            roomCombo.SelectedIndex = 0;
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
            if (!Regex.Match(name, Regexes.nameRegex).Success)
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
            if (name && inStock && MinInput)
                dodajButton.IsEnabled = true;
            else
                dodajButton.IsEnabled = false;
        }

        private void dodajButton_Click(object sender, RoutedEventArgs e)
        {
            editedItem.Name = nameInput.Text;
            editedItem.InStock = int.Parse(inStockInput.Text);
            editedItem.MinNumber = int.Parse(minInput.Text);
            editedItem.Room = appResources.roomController.GetRoomByName(roomCombo.SelectedItem.ToString());

            appResources.inventoryItemRepository.Update(editedItem);

            NavigationService.Navigate(new InventoryOverviewPage());
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            if (NavigationService.CanGoBack)
                NavigationService.GoBack();
        }
    }
}
