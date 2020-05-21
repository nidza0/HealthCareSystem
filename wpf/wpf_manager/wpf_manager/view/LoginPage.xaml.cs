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

namespace wpf_manager.view
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager mng = new Manager();
            String user = UserInput.Text;
            String pass = PassInput.Password.ToString();

            Console.WriteLine(user);
            Console.WriteLine(pass);

            if (mng.Password.Equals(pass) && mng.Username.Equals(user))
            {
                NavigationService.Navigate(new Uri("/view/ManagerMain.xaml", UriKind.Relative));
            }
            else
            {
                UserInput.Text = "Pogrešno korisničko ime ili lozinka";
                PassInput.Password = "";
            }
        }
    }
}
