using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_manager
{
    class Manager
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string ImageUri { get; set; }

        public string PocetakRV { get; set; }
        public string KrajRV { get; set; }

        public string Adresa { get; set; }
        
        public string Telefon { get; set; }

        public Manager()
        {
            this.Ime = "Pera";
            this.Prezime = "Detlic";
            this.Username = "pera_detlic";
            this.Password = "pera123";
            this.ImageUri = "C:/Users/vule/Desktop/hci/v3 WPF/manager_wpf/wpf_manager/wpf_manager/mImage.jpg";
            this.PocetakRV = "10.30";
            this.KrajRV = "12.00";
            this.Adresa = "Pejicevi Salasi";
            this.Telefon = "+381 21 1966 1989";
        }
    }
}
