using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_manager.Model
{
    public class Doctor
    {

        public string name { get;set;} 
        public string surname { get; set;}
        public string imagePath { get; set; }
        public string startWH { get; set; }
        public string endWH { get; set; }
        public string depart { get; set; }

        public Doctor(string name, string surname, string imagePath, string startWH, string endWH, string depart)
        {
            this.name = name;
            this.surname = surname;
            this.imagePath = imagePath;
            this.startWH = startWH;
            this.endWH = endWH;
            this.depart = depart;
        }
    }

    
}
