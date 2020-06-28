using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.ViewSecretary.ViewModel
{
    class LocationViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> countries = new ObservableCollection<string>();
        private ObservableCollection<Location> locations = new ObservableCollection<Location>();
        private string selectedCountry;
        private Location selectedLocation;

        public LocationViewModel()
        {
            LoadAllCountries();

        }

        public ObservableCollection<string> Countries { get => countries; set => countries = value; }
        public ObservableCollection<Location> Locations { get => locations; set => locations = value; }
        public string SelectedCountry { get => selectedCountry; set { selectedCountry = value; LoadLocationsByCountry(selectedCountry); OnPropertyChanged("SelectedCountry"); } }

        public Location SelectedLocation { get => selectedLocation; set { selectedLocation = value; OnPropertyChanged("SelectedLocation"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void LoadLocationsByCountry(string country)
        {
            if (!string.IsNullOrEmpty(country))
            {
                locations.Clear();
                AppResources.getInstance().locationController.GetLocationByCountry(country).ToList().ForEach(locations.Add);
            }
        }

        private void LoadAllCountries()
        {
            var allCountries = AppResources.getInstance().locationController.GetAllCountries();
            allCountries.ToList().ForEach(countries.Add);
        }
    }
}
