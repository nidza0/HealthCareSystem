﻿using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
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

        public static ObservableCollection<Room> roomsList;

        public static ObservableCollection<Medicine> medicineList;

        public static ObservableCollection<Appointment> appointmentsList;

        public DummyDoctors()
        {
            Dictionary<WorkingDaysEnum, Util.TimeInterval> dict;
            dict = new Dictionary<WorkingDaysEnum, Util.TimeInterval>();
            dict[0] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict[WorkingDaysEnum.TUESDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict[WorkingDaysEnum.WEDNESDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict[WorkingDaysEnum.THURSDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 21, 0, 0));
            dict[WorkingDaysEnum.FRIDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict[WorkingDaysEnum.SATURDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 8, 0, 0));
            dict[WorkingDaysEnum.SUNDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 8, 0, 0));

            Dictionary<WorkingDaysEnum, Util.TimeInterval> dict2;
            dict2 = new Dictionary<WorkingDaysEnum, Util.TimeInterval>();
            dict2[0] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict2[WorkingDaysEnum.TUESDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict2[WorkingDaysEnum.WEDNESDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict2[WorkingDaysEnum.THURSDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict2[WorkingDaysEnum.FRIDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));
            dict2[WorkingDaysEnum.SATURDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 8, 0, 0));
            dict2[WorkingDaysEnum.SUNDAY] = new Util.TimeInterval(new DateTime(1, 1, 1, 8, 0, 0), new DateTime(1, 1, 1, 16, 0, 0));

            TimeTable timeTable = new TimeTable(dict);
            TimeTable timeTable2 = new TimeTable(dict2);

            doctorsList = new ObservableCollection<Model.UserModel.Doctor>();
            Model.UserModel.Doctor doc1 = new Model.UserModel.Doctor(new Model.UserModel.UserID("D1"), "aleksa_vucaj", "sifra", new DateTime(2020, 6, 8), "Aleksa", "Vucaj", "Aleksandar", Model.UserModel.Sex.MALE, new DateTime(1998, 9, 8), "123", null, null, null, null, null, timeTable, null, new Model.UserModel.Room(101), Model.DoctorModel.DocTypeEnum.FAMILYMEDICINE); ;
            Model.UserModel.Doctor doc2 = new Model.UserModel.Doctor(new Model.UserModel.UserID("D2"), "aleksa_vucaj2", "sifra", new DateTime(2020, 6, 8), "Pera", "Detlic", "Petar", Model.UserModel.Sex.MALE, new DateTime(1998, 9, 8), "123", null, null, null, null, null, timeTable2, null, new Model.UserModel.Room(102), Model.DoctorModel.DocTypeEnum.FAMILYMEDICINE);

            doctorsList.Add(doc1);
            doctorsList.Add(doc2);

            itemsList = new ObservableCollection<Model.ManagerModel.InventoryItem>();
            InventoryItem item1 = new InventoryItem("Stolica", 10, 1, new Room(101));
            InventoryItem item2 = new InventoryItem("Maske", 1000, 100, new Room(102));

            itemsList.Add(item1);
            itemsList.Add(item2);

            roomsList = new ObservableCollection<Room>();
            Room room1 = new Room(0,"101",true,2,RoomType.EXAMINATION,null);
            Room room2 = new Room(1, "102", false, 2, RoomType.EXAMINATION, null);
            Room room3 = new Room(2, "103", true, 2, RoomType.EXAMINATION, null);
            Room room4 = new Room(3, "104", false, 2, RoomType.EXAMINATION, null);
            Room room5 = new Room(4, "105", false, 2, RoomType.EXAMINATION, null);
            Room room6 = new Room(5, "201", false, 2, RoomType.OPERATION, null);
            Room room7 = new Room(6, "202", false, 2, RoomType.OPERATION, null);
            Room room8 = new Room(7, "203", true, 2, RoomType.OPERATION, null);
            Room room9 = new Room(8, "204", false, 2, RoomType.OPERATION, null);
            Room room11 = new Room(9, "301", true, 2, RoomType.AFTERCARE, null);
            Room room12 = new Room(10, "302", true, 2, RoomType.AFTERCARE, null);
            Room room13 = new Room(11, "303", false, 2, RoomType.AFTERCARE, null);
            Room room14 = new Room(12, "304", false, 2, RoomType.AFTERCARE, null);


            roomsList.Add(room1);
            roomsList.Add(room2);
            roomsList.Add(room3);
            roomsList.Add(room4);
            roomsList.Add(room5);
            roomsList.Add(room6);
            roomsList.Add(room7);
            roomsList.Add(room8);
            roomsList.Add(room9);
            roomsList.Add(room11);
            roomsList.Add(room12);
            roomsList.Add(room13);
            roomsList.Add(room14);

            medicineList = new ObservableCollection<Medicine>();

            Medicine med1 = new Medicine(0, "Xanax", 500.0, MedicineType.PILL,true,null,null, 10, 20);
            Medicine med2 = new Medicine(1, "Paracetamol", 500.0, MedicineType.PILL, false, null, null, 100, 50);
            Medicine med3 = new Medicine(2, "Panadol",152.0, MedicineType.PILL, true, null, null, 1000, 10);
            Medicine med4 = new Medicine(3, "Xanax", 500.0, MedicineType.PILL, true, null, null, 10, 20);
            Medicine med5 = new Medicine(4, "Paracetamol", 500.0, MedicineType.PILL, false, null, null, 100, 50);
            Medicine med6 = new Medicine(5, "Panadol", 152.0, MedicineType.PILL, true, null, null, 1000, 10);
            Medicine med7 = new Medicine(6, "Xanax", 500.0, MedicineType.PILL, true, null, null, 10, 20);
            Medicine med8 = new Medicine(7, "Paracetamol", 500.0, MedicineType.PILL, false, null, null, 100, 50);
            Medicine med9 = new Medicine(8, "Panadol", 152.0, MedicineType.PILL, true, null, null, 1000, 10);
            Medicine med10 = new Medicine(9, "Xanax", 500.0, MedicineType.PILL, true, null, null, 10, 20);
            Medicine med11 = new Medicine(10, "Paracetamol", 500.0, MedicineType.PILL, false, null, null, 100, 50);
            Medicine med12 = new Medicine(11, "Panadol", 152.0, MedicineType.PILL, true, null, null, 1000, 10);


            med1.IsValid = true;
            med4.IsValid = true;
            med6.IsValid = true;
            med8.IsValid = true;
            med10.IsValid = true;

            medicineList.Add(med1);
            medicineList.Add(med2);
            medicineList.Add(med3);
            medicineList.Add(med4);
            medicineList.Add(med5);
            medicineList.Add(med6);
            medicineList.Add(med7);
            medicineList.Add(med8);
            medicineList.Add(med9);
            medicineList.Add(med10);
            medicineList.Add(med11);
            medicineList.Add(med12);

            appointmentsList = new ObservableCollection<Appointment>();

            Appointment app1 = new Appointment(0, doc1,new Patient(new UserID("P01")), room1, AppointmentType.checkup, new Util.TimeInterval(new DateTime(2020, 6, 11, 20, 0, 0), new DateTime(2020, 6, 11, 20, 30, 0)));
            Appointment app2 = new Appointment(0, doc2, new Patient(new UserID("P01")), room2, AppointmentType.checkup, new Util.TimeInterval(new DateTime(2020, 6, 3, 21, 0, 0), new DateTime(2020, 6, 11, 21, 30, 0)));
            Appointment app3 = new Appointment(0, doc1, new Patient(new UserID("P01")), room3, AppointmentType.checkup, new Util.TimeInterval(new DateTime(2020, 6, 11, 22, 0, 0), new DateTime(2020, 6, 11, 22, 30, 0)));
            Appointment app4 = new Appointment(0, doc1, new Patient(new UserID("P01")), room1, AppointmentType.checkup, new Util.TimeInterval(new DateTime(2020, 11, 12, 10, 0, 0), new DateTime(2020, 6, 11, 10, 30, 0)));
            Appointment app5 = new Appointment(0, doc2, new Patient(new UserID("P01")), room2, AppointmentType.checkup, new Util.TimeInterval(new DateTime(2020, 12, 3, 8, 0, 0), new DateTime(2020, 6, 11, 9, 30, 0)));
            Appointment app6 = new Appointment(0, doc2, new Patient(new UserID("P01")), room3, AppointmentType.checkup, new Util.TimeInterval(new DateTime(2020, 5, 11, 20, 0, 0), new DateTime(2020, 6, 11, 20, 30, 0)));
            Appointment app7 = new Appointment(0, doc1, new Patient(new UserID("P01")), room1, AppointmentType.checkup, new Util.TimeInterval(new DateTime(2020, 10, 11, 20, 0, 0), new DateTime(2020, 6, 11, 20, 30, 0)));
            Appointment app8 = new Appointment(0, doc2, new Patient(new UserID("P01")), room2, AppointmentType.checkup, new Util.TimeInterval(new DateTime(2020, 6, 15, 5, 0, 0), new DateTime(2020, 6, 11, 5, 30, 0)));
            Appointment app9 = new Appointment(0, doc1, new Patient(new UserID("P01")), room3, AppointmentType.checkup, new Util.TimeInterval(new DateTime(2020, 6, 16, 20, 0, 0), new DateTime(2020, 6, 11, 20, 30, 0)));
            Appointment app10 = new Appointment(0, doc2, new Patient(new UserID("P01")), room1, AppointmentType.checkup, new Util.TimeInterval(new DateTime(2020, 3, 17, 20, 0, 0), new DateTime(2020, 6, 11, 20, 30, 0)));
            Appointment app11 = new Appointment(0, doc1, new Patient(new UserID("P01")), room1, AppointmentType.checkup, new Util.TimeInterval(new DateTime(2020, 2, 18, 10, 0, 0), new DateTime(2020, 6, 11, 10, 30, 0)));

            app1.Canceled = true;

            appointmentsList.Add(app1);
            appointmentsList.Add(app2);
            appointmentsList.Add(app3);
            appointmentsList.Add(app4);
            appointmentsList.Add(app5);

            appointmentsList.Add(app6);
            appointmentsList.Add(app7);
            appointmentsList.Add(app8);
            appointmentsList.Add(app9);
            appointmentsList.Add(app10);
            appointmentsList.Add(app11);
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
