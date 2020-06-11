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

namespace SIMS.View.ViewSecretary.Pages
{

    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Now.AddHours(3);

            TimeSpan dt = dt2 - dt1;
            Console.WriteLine(dt.Days);
            Console.WriteLine(dt.Hours);
            Console.WriteLine(dt.Minutes);
            Console.WriteLine(dt.TotalMinutes);
        }
    }
}
