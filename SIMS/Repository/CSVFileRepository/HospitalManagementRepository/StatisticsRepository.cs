// File:    StatisticsRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:39
// Purpose: Definition of Class StatisticsRepository

using SIMS.Model.ManagerModel;
using SIMS.Model.PatientModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.UsersRepository;
using System;
using System.Collections.Generic;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class StatisticsRepository : CSVRepository<Stats, long>, IStatisticsRepository, IEagerCSVRepository<Stats, long>
    {
        private void BindStatisticsWithDoctors(IEnumerable<StatsDoctor> statistics, IEnumerable<Doctor> doctors)
        {
            throw new NotImplementedException();
        }

        private void BindStatisticsWithInventoryItems(IEnumerable<StatsInventory> statistics, IEnumerable<InventoryItem> inverntoryItems)
        {
            throw new NotImplementedException();
        }

        private void BindStatisticsWithMedicine(IEnumerable<StatsInventory> statistics, IEnumerable<Medicine> medicine)
        {
            throw new NotImplementedException();
        }

        private void BindStatisticsWithRoom(IEnumerable<StatsRoom> statistics, IEnumerable<Room> rooms)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatsDoctor> GetDoctorStatistics()
        {
            throw new NotImplementedException();
        }

        public Doctor GetStatisticsByDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        public StatsInventory GetStatisticsByItem(Item item)
        {
            throw new NotImplementedException();
        }

        public StatsRoom GetStatisticsByRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatsRoom> GetRoomStatistics()
        {
            throw new NotImplementedException();
        }

        public StatsInventory GetInventoryStatistics()
        {
            throw new NotImplementedException();
        }

        public Stats GetEager(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Stats> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public RoomRepository roomRepository;
        public MedicineRepository medicineRepository;
        public InventoryRepository inventoryRepository;
        public DoctorRepository doctorRepository;

    }
}