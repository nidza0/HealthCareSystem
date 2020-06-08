// File:    RoomRepository.cs
// Author:  Windows 10
// Created: 23. maj 2020 15:33:38
// Purpose: Definition of Class RoomRepository

using SIMS.Model.ManagerModel;
using SIMS.Model.UserModel;
using SIMS.Repository.Abstract.HospitalManagementAbstractRepository;
using SIMS.Repository.CSVFileRepository.Csv;
using SIMS.Repository.CSVFileRepository.Csv.IdGenerator;
using SIMS.Repository.CSVFileRepository.Csv.Stream;
using SIMS.Repository.Sequencer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    public class RoomRepository : CSVRepository<Room, long>, IRoomRepository, IEagerCSVRepository<Room, long>
    {
        private IInventoryItemRepository _inventoryItemRepository;
        public RoomRepository(string entityName, ICSVStream<Room> stream, ISequencer<long> sequencer, IInventoryItemRepository inventoryItemRepository) : base(entityName, stream, sequencer, new LongIdGeneratorStrategy<Room>())
        {
            _inventoryItemRepository = inventoryItemRepository;
        }

        private void BindRoomsWithItems(IEnumerable<Room> rooms, IEnumerable<InventoryItem> inventoryItems)
            => rooms.ToList().ForEach(room => 
            {
                room.InventoryItem = GetInventoryItemsByIds(inventoryItems, room.InventoryItem.Select(item => item.Id));
            });

        private List<InventoryItem> GetInventoryItemsByIds(IEnumerable<InventoryItem> items, IEnumerable<long> ids)
            => items.Where(item => ids.Contains(item.Id)).ToList();

        public IEnumerable<Room> GetAllEager()
        {
            IEnumerable<Room> rooms = GetAll();
            IEnumerable<InventoryItem> items = _inventoryItemRepository.GetAll();

            BindRoomsWithItems(rooms, items);

            return rooms;
        }

        public Room GetEager(long id)
            => GetAllEager().SingleOrDefault(room => room.GetId() == id);

        public Room GetRoomByName(string name)
            => GetAll().SingleOrDefault(room => room.RoomNumber == name);

        public IEnumerable<Room> GetRoomsByFloor(int floor)
            => GetAll().Where(room => room.Floor == floor);

        public IEnumerable<Room> GetRoomsByType(RoomType type)
            => GetAll().Where(room => room.RoomType == type);
    }
}