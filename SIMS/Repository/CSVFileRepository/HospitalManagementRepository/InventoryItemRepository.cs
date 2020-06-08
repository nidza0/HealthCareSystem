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

namespace SIMS.Repository.CSVFileRepository.HospitalManagementRepository
{
    class InventoryItemRepository : CSVRepository<InventoryItem, long>, IInventoryItemRepository, IEagerCSVRepository<InventoryItem, long>
    {
        public InventoryItemRepository(string entityName, ICSVStream<InventoryItem> stream, ISequencer<long> sequencer, IIdGeneratorStrategy<InventoryItem, long> idGeneratorStrategy) : base(entityName, stream, sequencer, idGeneratorStrategy)
        {
        }

        public IEnumerable<InventoryItem> GetAllEager()
        {
            throw new NotImplementedException();
        }

        public InventoryItem GetEager(long id)
        {
            throw new NotImplementedException();
        }


        private void BindInventoryItemsWithRooms(IEnumerable<InventoryItem> inventoryItems, IEnumerable<Room> rooms)
        {
            throw new NotImplementedException();
        }

        public void Bind(IEnumerable<InventoryItem> inventoryItems, IEnumerable<Room> rooms)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventoryItem> GetInventoryItemsForRoom(Room room)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventoryItem> GetInventoryItems()
        {
            throw new NotImplementedException();
        }
    }
}
