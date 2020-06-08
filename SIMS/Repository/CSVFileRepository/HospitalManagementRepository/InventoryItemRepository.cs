﻿using SIMS.Model.PatientModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.MedicalRepository;
using SIMS.Specifications.Converter;
using SIMS.Util;
using System;
using System.Collections.Generic;

using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    class InventoryItemRepository : CSVRepository<InventoryItem, long>, IInventoryItemRepository, IEagerCSVRepository<InventoryItem, long>
    {
        private IRoomRepository _roomRepository;
        public InventoryItemRepository(string entityName, ICSVStream<InventoryItem> stream, ISequencer<long> sequencer, IIdGeneratorStrategy<InventoryItem, long> idGeneratorStrategy, IRoomRepository roomRepository) : base(entityName, stream, sequencer, idGeneratorStrategy)
        {
            _roomRepository = roomRepository;
        }

        public IEnumerable<InventoryItem> GetAllEager()
        {
            IEnumerable<InventoryItem> inventoryItems = GetAll();
            IEnumerable<Room> rooms = _roomRepository.GetAll();

            Bind(inventoryItems, rooms);

            return inventoryItems;
        }

        public InventoryItem GetEager(long id)
            => GetAllEager().ToList().SingleOrDefault(item => item.GetId() == id);


        private void BindInventoryItemsWithRooms(IEnumerable<InventoryItem> inventoryItems, IEnumerable<Room> rooms)
            => inventoryItems.ToList().ForEach(item => item.Room = GetRoomById(rooms, item.Id));

        private Room GetRoomById(IEnumerable<Room> rooms, long id)
            => rooms.ToList().SingleOrDefault(room => room.GetId() == id);

        public void Bind(IEnumerable<InventoryItem> inventoryItems, IEnumerable<Room> rooms)
        {
            BindInventoryItemsWithRooms(inventoryItems, rooms);
        }

        public IEnumerable<InventoryItem> GetInventoryItemsForRoom(Room room)
            => GetAll().ToList().Where(item => item.Room.Equals(room));

        public IEnumerable<InventoryItem> GetInventoryItems()
            => GetAll();
    }
}
