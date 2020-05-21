using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_manager.Model
{
    public class DoctorsList
    {
        public static ObservableCollection<Model.Doctor> Doctors;


        public DoctorsList()
        {
            Doctors = new ObservableCollection<Doctor>();

            Model.Doctor Ted = new Model.Doctor("Ted", "Mosby", @"../images/doc11.jpg", "8:00", "15:00", "Kardiologija", "+381 60 6720230", "Doktor", "13.11.1953.", "101", 1);
            Model.Doctor Marshall = new Model.Doctor("Marshall", "Ericssen", "../images/doc12.jpg", "9:00", "14:00", "Kardiologija", "+381 60 6720231", "Doktor", "29.10.1953.", "102", 2);
            Model.Doctor Barney = new Model.Doctor("Barney", "Stinson", "../images/doc13.jpg", "12:00", "13:00", "ORL", "+381 60 6720232", "Ginekologija", "28.2.1966.", "111", 3);
            Model.Doctor Jon = new Model.Doctor("Jon", "Snow", @"../images/doc21.jpg", "7:00", "18:00", "Pulmolog", "+381 60 6720233", "Doktor", "11.7.1984.", "104", 9);
            Model.Doctor Daenerys = new Model.Doctor("Daenerys", "Targaryen", @"../images/doc22.jpg", "8:00", "15:00", "Porodiliste", "+381 60 6720234", "Doktor", "8.9.1998.", "109", 4);
            Model.Doctor Ned = new Model.Doctor("Ned", "Stark", @"../images/doc23.jpg", "6:00", "11:00", "Psihologija", "+381 60 6720235", "Doktor", "22.7.1986.", "107", 5);
            Model.Doctor Leia = new Model.Doctor("Leia", "Skywalker", @"../images/doc31.jpg", "15:00", "22:00", "Pedijatrija", "+381 60 6720236", "Doktor", "28.10.1988.", "151", 6);
            Model.Doctor Luke = new Model.Doctor("Luke", "Skywalker", @"../images/doc32.jpg", "8:00", "15:00", "Pedijatrija", "+381 60 6720237", "Doktor", "15.6.1960.", "108", 7);
            Model.Doctor Han = new Model.Doctor("Han", "Solo", @"../images/doc33.jpg", "8:00", "15:00", "Portir", "+381 60 6720238", "Doktor", "11.11.1975.", "109", 8);
            Model.Doctor Anakin = new Model.Doctor("Anakin", "Skywalker", @"../images/doc4.jpg", "15:00", "18:30", "Radiologija", "+381 60 6720239", "Doktor", "11.11.1955.", "109", 10);

            Doctors.Add(Ted);
            Doctors.Add(Marshall);
            Doctors.Add(Barney);
            Doctors.Add(Jon);
            Doctors.Add(Daenerys);
            Doctors.Add(Ned);
            Doctors.Add(Leia);
            Doctors.Add(Luke);
            Doctors.Add(Han);
            Doctors.Add(Anakin);
        }
    }
}
