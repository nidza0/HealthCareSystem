using SIMS.Model.UserModel;
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
    /// <summary>
    /// Interaction logic for PatientDetailsPageSecretary.xaml
    /// </summary>
    public partial class PatientDetailsPageSecretary : Page
    {
        private Patient patient;

        public Patient Patient { get => patient; set => patient = value; }

        public PatientDetailsPageSecretary(Patient p)
        {
            InitializeComponent();
            Patient = p;
            this.DataContext = this;
        }

        public PatientDetailsPageSecretary()
        {
            InitializeComponent();
        }
    }
}
