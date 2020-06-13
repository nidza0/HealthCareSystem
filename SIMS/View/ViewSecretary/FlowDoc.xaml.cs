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

namespace SIMS.View.ViewSecretary
{
    /// <summary>
    /// Interaction logic for FlowDoc.xaml
    /// </summary>
    public partial class FlowDoc : Page
    {
        private Dictionary<string, int> chartData = new Dictionary<string, int>();
        public FlowDoc()
        {
            InitializeComponent();
            LoadChartData();
            DataContext = this;
            Console.WriteLine("Chart window");
        }

        private void LoadChartData()
        {
            chartData.Add("valami", 4);
            chartData.Add("nesto", 10);
            chartData.Add("something", 2);
            chartData.Add("jbfjknkjd", 6);

        }

        public Dictionary<string, int> ChartData { get => chartData; set => chartData = value; }
    }
}
