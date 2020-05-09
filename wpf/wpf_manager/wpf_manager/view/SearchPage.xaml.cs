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
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        private void SearchButton2_Click(object sender, RoutedEventArgs e)
        {
            String name = NameInput.Text;
            String surname = SurnameInput.Text;
            String room = RoomInput.Text;
            String depart = DepartInput.Text;

            int counter = 0;


            Model.Doctor wantedDoc = null;

            foreach(Model.Doctor doc in LekariPage.Doctors)
            {
                if (doc.Name.Equals(name) &&  doc.Surname.Equals(surname))
                {
                    wantedDoc = doc;
                }

            }

            Console.WriteLine(counter);

            if (wantedDoc == null)
                Console.WriteLine("Nije pronadjen");
            else
                NavigationService.Navigate(new LekarDetails(wantedDoc));

        }
    }
}
