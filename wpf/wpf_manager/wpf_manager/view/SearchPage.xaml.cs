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

            if (name.Equals(""))
                name = "true";
            if (surname.Equals(""))
                surname = "true";
            if (room.Equals(""))
                room = "true";
            if (depart.Equals(""))
                depart = "true";



            List<Model.Doctor> doctors = new List<Model.Doctor>();

            foreach(Model.Doctor doc in Model.DoctorsList.Doctors)
            {
                if ((doc.Name.Equals(name) || name.Equals("true")) && (doc.Surname.Equals(surname)|| surname.Equals("true")) && (doc.Room.Equals(room) || room.Equals("true")) && (doc.Depart.Equals(depart) || depart.Equals("true")))
                {
                    doctors.Add(doc);
                }

            }

            Console.WriteLine(doctors.Count);

            if (doctors.Count == 0)
            {
                Console.WriteLine("Nije pronadjen");
                NameInput.Text = "Nije pronadjen ni jedan lekar";
            } 
            else if (doctors.Count == 1)
                NavigationService.Navigate(new LekarDetails(doctors[0]));
            else
                NavigationService.Navigate(new LekarFilter(doctors));

        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("view/ManagerMain.xaml", UriKind.Relative));
        }
    }
}
