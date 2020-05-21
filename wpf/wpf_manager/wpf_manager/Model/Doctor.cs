using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_manager.Model
{

    
    public class Doctor
    {
        public static int idCount = 0;
        public string Name { get;set;} 
        public string Surname { get; set;}
        public string ImagePath { get; set; }
        public string StartWH { get; set; }
        public string EndWH { get; set; }
        public string Depart { get; set; }
        public string Telephone { get; set; }
        public string Title { get; set; }
        public string Birth { get; set; }
        public string Room { get; set; }

        public int Id { get; set; }

        public string WorkingHours { get; set; }

        public Doctor(string name, string surname, string imagePath, string startWH, string endWH, string depart, string telephone, string title,string birth,string room, int id)
        {
            this.Name = name;
            this.Surname = surname;
            this.ImagePath = imagePath;
            this.StartWH = startWH;
            this.EndWH = endWH;
            this.Depart = depart;
            this.WorkingHours = startWH + "-" + endWH;
            this.Telephone = telephone;
            this.Title = title;
            this.Birth = birth;
            this.Room = room;
            this.Id = idCount++;
        }
    }

    
}
