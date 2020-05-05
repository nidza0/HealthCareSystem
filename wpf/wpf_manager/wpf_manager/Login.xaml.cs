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

namespace wpf_manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Page
    {
        public MainWindow()
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

            if(mng.password.Equals(pass) && mng.username.Equals(user))
            {
                windows.manager_main man_win = new windows.manager_main();
                NavigationService.Navigate(new Uri("manager_main.xaml",UriKind.Relative));
            }
            else
            {
                UserInput.Text = "Pogrešno korisničko ime ili lozinka";
                PassInput.Password = "";
            }
        }
    }
}
