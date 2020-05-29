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
using System.Windows.Shapes;


namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.username.Text = "";
            this.password.Text = "";
            confirmButton.IsEnabled = false;
            
        }



        private void ConfirmButton_Click_1(object sender, RoutedEventArgs e)
        {
            String username = this.username.Text;
            String password = this.password.Text;

            //TODO: Check if username and password valid.



            HomePage homePage = new HomePage();
            homePage.WindowState = WindowState.Maximized;

            this.Close();
            homePage.Show();
        }

        private void validateInput(object sender, TextChangedEventArgs e)
        {
            if(username == null || password == null)
            {
                confirmButton.IsEnabled = false;
                return;
            }

            if (username.Text != "" && password.Text != "") confirmButton.IsEnabled = true;
        }
    }
}
