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
    /// Interaction logic for NoviRecept.xaml
    /// </summary>
    public partial class NoviRecept : Page
    {

        private DateTime date;
        private double dailyDose;
        private int dayCount;

        public NoviRecept()
        {
            InitializeComponent();
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private bool isNumber(string input)
        {
            double tempD;
            int tempI;
            if (Double.TryParse(input, out tempD))
            {
                return true;
            }
            else if (int.TryParse(input, out tempI))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void OK_Button_Click(object sender, RoutedEventArgs e)
        {

            if (isNumber(DailyAmount_TextBox.Text) && isNumber(DayCount_TextBox.Text))
            {
                if (Double.Parse(DailyAmount_TextBox.Text) != 0.0)
                {

                    NavigationService.Navigate(new MainPageCenter());
                    MessageBoxButton button = MessageBoxButton.OK;
                    string caption = "Uspešno ste prepisali recept";
                    string messageBoxText = "Uspešno ste prepisali novi recept pacijentu.";
                    MessageBox.Show(messageBoxText, caption, button);
                }
            }
            else
            {
                MessageBoxButton button = MessageBoxButton.OK;
                string caption = "Greška";
                string messageBoxText = "Dnevna doza mora biti ne nula broj.";
                MessageBox.Show(messageBoxText, caption, button);
            }
        }

        private void CANCEL_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainPageCenter());
        }

        private void CheckBoxBtn_Click(object sender, RoutedEventArgs e)
        {
            Today_CheckBox.IsChecked = !Today_CheckBox.IsChecked;
            setDate();
        }

        private void setDate()
        {
            if ((bool)Today_CheckBox.IsChecked)
            {
                date = DateTime.Now;
                DatePicker.IsEnabled = false;
            }
            else
            {
                date = DatePicker.DisplayDate;
                DatePicker.IsEnabled = true;
            }
        }
    }
}
