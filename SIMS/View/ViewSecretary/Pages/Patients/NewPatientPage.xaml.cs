using SIMS.Exceptions;
using SIMS.Model.UserModel;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using SIMS.View.ViewSecretary.ViewModel;
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

namespace SIMS.View.ViewSecretary.Pages.Patients
{
    public partial class NewPatientPage : Page
    {
        private PatientViewModel patientVM = new PatientViewModel();
        private LocationViewModel locationVM = new LocationViewModel();
        private int mode;
        private readonly int CREATE = 0;
        private readonly int UPDATE = 1;
        
        public NewPatientPage(PatientViewModel p)
        {
            InitializeComponent();
            patientVM = p;
            mode = UPDATE;
            DataContext = patientVM;
            textCountry.DataContext = locationVM;
            textCity.DataContext = locationVM;
            textDateOfBirth.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), DateTime.MaxValue));
            textUsername.IsEnabled = false;
            SetLocation(patientVM.Patient.Address.Location);
            SetGender();
        }

        private void SetGender()
        {
            switch (patientVM.Patient.Sex)
            {
                case (Sex.MALE):        radioMale.IsChecked = true; break;
                case (Sex.FEMALE):      radioFemale.IsChecked = true; break;
                case (Sex.OTHER):       radioOther.IsChecked = true; break;
            }
        }

        private void SetLocation(Location loc)
        {
            if(loc != null)
            {
                locationVM.SelectedCountry = loc.Country;
                locationVM.SelectedLocation = loc;
            }
        }

        public NewPatientPage()
        {
            InitializeComponent();
            mode = CREATE;
            DataContext = patientVM;
            textCountry.DataContext = locationVM;
            textCity.DataContext = locationVM;
            textDateOfBirth.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), DateTime.MaxValue));
            radioMale.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FrameManager.getInstance().CentralFrame.CanGoBack)
                FrameManager.getInstance().CentralFrame.GoBack();
        }

        private void radioMale_Checked(object sender, RoutedEventArgs e) => patientVM.Patient.Sex = Model.UserModel.Sex.MALE;

        private void radioFemale_Checked(object sender, RoutedEventArgs e) => patientVM.Patient.Sex = Model.UserModel.Sex.FEMALE;

        private void radioOther_Checked(object sender, RoutedEventArgs e) => patientVM.Patient.Sex = Model.UserModel.Sex.OTHER;

        private void textCountry_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnNewPatient_Click(object sender, RoutedEventArgs e)
        {
            if(locationVM.SelectedLocation != null)
            {
                patientVM.Patient.Address.Location = locationVM.SelectedLocation;
            }

            if (!validation())
                return;

            try
            {
                if(mode == CREATE)
                {
                    try
                    {
                        patientVM.Patient = AppResources.getInstance().patientController.Create(patientVM.Patient);
                        errUsernameNotUnique.Visibility = Visibility.Collapsed;
                        MessageBox.Show(patientVM.Patient.FullName + " as " + patientVM.Patient.UserName, "New Patient Created", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (FrameManager.getInstance().CentralFrame.CanGoBack)
                            FrameManager.getInstance().CentralFrame.GoBack();
                    }
                    catch(InvalidUserException ex)
                    {
                        MessageBox.Show(ex.Message, "New Patient Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    catch(NotUniqueException ex)
                    {
                        errUsernameNotUnique.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    try
                    {
                        AppResources.getInstance().patientController.Update(patientVM.Patient);
                        //SecretaryAppResources.GetInstance().patientRepository.Update(patientVM.Patient);
                        MessageBox.Show(patientVM.Patient.FullName + " as " + patientVM.Patient.UserName, "Patient Updated", MessageBoxButton.OK, MessageBoxImage.Information);
                        if (FrameManager.getInstance().CentralFrame.CanGoBack)
                            FrameManager.getInstance().CentralFrame.GoBack();
                    }
                    catch (InvalidUserException ex)
                    {
                        MessageBox.Show(ex.Message, "Patient Update Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                errUsernameNotUnique.Visibility = Visibility.Visible;
            }
        }

        private bool validation()
        {
            bool success = true;

            if (string.IsNullOrEmpty(patientVM.Patient.UserName))
            {
                errUsername.Visibility = Visibility.Visible;
                success = false;
            }
            else
                errUsername.Visibility = Visibility.Collapsed;

            if (string.IsNullOrEmpty(patientVM.Patient.Name))
            {
                errName.Visibility = Visibility.Visible;
                success = false;
            }
            else
                errName.Visibility = Visibility.Collapsed;

            if (string.IsNullOrEmpty(patientVM.Patient.Surname))
            {
                errSurname.Visibility = Visibility.Visible;
                success = false;
            }
            else
                errSurname.Visibility = Visibility.Collapsed;

            return success;
        }

        private void textName_GotFocus(object sender, RoutedEventArgs e) => errName.Visibility = Visibility.Collapsed;

        private void textSurname_GotFocus(object sender, RoutedEventArgs e) => errSurname.Visibility = Visibility.Collapsed;

        private void textUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            errUsername.Visibility = Visibility.Collapsed;
            errUsernameNotUnique.Visibility = Visibility.Collapsed;
        }
    }
}
