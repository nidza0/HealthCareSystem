using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_manager
{
    class Manager
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string imageUri { get; set; }

        public string pocetakRV { get; set; }
        public string krajRV { get; set; }

        public string adresa { get; set; }
        
        public string telefon { get; set; }

        public Manager()
        {
            this.ime = "Pera";
            this.prezime = "Detlic";
            this.username = "pera_detlic";
            this.password = "pera123";
            this.imageUri = "C:/Users/vule/Desktop/hci/v3 WPF/manager_wpf/wpf_manager/wpf_manager/mImage.jpg";
            this.pocetakRV = "10.30";
            this.krajRV = "12.00";
            this.adresa = "Pejicevi Salasi";
            this.telefon = "+381 21 1966 1989";
        }
    }
}
