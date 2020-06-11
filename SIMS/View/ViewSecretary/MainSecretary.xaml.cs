using SIMS.Model.UserModel;
using SIMS.Util;
using SIMS.View.ViewSecretary.Pages;
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

namespace SIMS.View.ViewSecretary
{
    /// <summary>
    /// Interaction logic for MainSecretary.xaml
    /// </summary>
    public partial class MainSecretary : Window
    {
        public MainSecretary()
        {
            InitializeComponent();
            SecretaryAppResources.GetInstance();

            MainFrame.Navigate(new LoginPage());
        }
    }
}
