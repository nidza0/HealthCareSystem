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

using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;

namespace SIMS.View.ViewPatient
{
    /// <summary>
    /// Interaction logic for ArticlePreview.xaml
    /// </summary>
    public partial class ArticlePreview : Window
    {
        private Article article;
        public ArticlePreview(Article article)
        {
            this.article = article;
            this.DataContext = this;
            InitializeComponent();
        }

        public Article Article { get => article; set => article = value; }
    }
}
