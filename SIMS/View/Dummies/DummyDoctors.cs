using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.View.Dummies
{
    public sealed class DummyDoctors
    {

        public static ObservableCollection<Model.UserModel.Doctor> doctorsList;

        public static ObservableCollection<Model.ManagerModel.InventoryItem> itemsList;

        public DummyDoctors()
        {

            doctorsList = new ObservableCollection<Model.UserModel.Doctor>();
            Model.UserModel.Doctor doc1 = new Model.UserModel.Doctor(new Model.UserModel.UserID("D1"), "aleksa_vucaj", "sifra", new DateTime(2020, 6, 8), "Aleksa", "Vucaj", "Aleksandar", Model.UserModel.Sex.MALE, new DateTime(1998, 9, 8), "123", null, null, null, null, null, null, null, new Model.UserModel.Room(101), Model.DoctorModel.DocTypeEnum.FAMILYMEDICINE);
            Model.UserModel.Doctor doc2 = new Model.UserModel.Doctor(new Model.UserModel.UserID("D2"), "aleksa_vucaj2", "sifra", new DateTime(2020, 6, 8), "Pera", "Detlic", "Petar", Model.UserModel.Sex.MALE, new DateTime(1998, 9, 8), "123", null, null, null, null, null, null, null, new Model.UserModel.Room(102), Model.DoctorModel.DocTypeEnum.FAMILYMEDICINE);

            doctorsList.Add(doc1);
            doctorsList.Add(doc2);

            itemsList = new ObservableCollection<Model.ManagerModel.InventoryItem>();
            InventoryItem item1 = new InventoryItem("Stolica", 10, 1, new Room(101));
            InventoryItem item2 = new InventoryItem("Maske", 1000, 100, new Room(102));

            itemsList.Add(item1);
            itemsList.Add(item2);

        }

        public static DummyDoctors Instance
        {
            get
            {
                return Instance;
            }
        }
    }
}
