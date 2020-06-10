using SIMS.Model.UserModel;
using SIMS.View.ViewDoctor.MainPages;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace SIMS.View.ViewDoctor.Forms
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private string username;
        private string password;
        private static string filename = "../../View/ViewDoctor/Forms/Logindata.txt";
        public Login()
        {
            //redirectIfLoggedIn();
            InitializeComponent();
        }

        /*private void redirectIfLoggedIn()
        {
            if (File.Exists(filename))
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        string[] tokens = s.Split(',');
                        
                        if (bool.Parse(tokens[0]))
                        {
                            navigate();
                        }
                    }
                }
            }
        }*/

        private void navigate()
        {
            NavigationService.Navigate(new MainPageCenter());
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            fillData();
           // keepLoggedIn();

            NavigationService.Navigate(new MainPageCenter());
        }

       /* private void keepLoggedIn()
        {
            if (!(bool)KeepMeLoggedIn_CheckBox.IsChecked)
            {
                
                if (File.Exists(filename))
                {
                    using (StreamReader sr = File.OpenText(filename))
                    {
                        string s = "";
                        while ((s = sr.ReadLine()) != null)
                        {
                            string[] tokens = s.Split(',');
                            
                        }


            }
            else
            {
                if (!File.Exists(filename)) { 
                    using (FileStream fs = File.Create(filename))
                    {
                        // Add some text to file    
                        Byte[] data = new UTF8Encoding(true).GetBytes( KeepMeLoggedIn_CheckBox.IsChecked.ToString() + "," + username + "," + password + "," + DateTime.Now.ToString());
                        fs.Write(data, 0, data.Length);

                    }
                } else
                {
                    File.Delete(filename);
                    using (FileStream fs = File.Create(filename))
                    {
                        // Add some text to file    
                        Byte[] data = new UTF8Encoding(true).GetBytes(KeepMeLoggedIn_CheckBox.IsChecked.ToString() + "," + username + "," + password + "," + DateTime.Now.ToString());
                        fs.Write(data, 0, data.Length);

                    }
                }
            }
        }
        */

        private void fillData()
        {
            username = Username_TextBox.Text;
            password = Password_TextBox.Password;
        }

        private void KeepMeLoggedIn_CheckBox_Click(object sender, RoutedEventArgs e)
        {
           // KeepMeLoggedIn_CheckBox.IsChecked = !KeepMeLoggedIn_CheckBox.IsChecked;
        }

        private void Password_TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                fillData();
                // keepLoggedIn();

                NavigationService.Navigate(new MainPageCenter());
            }
            
        }
    }
}
