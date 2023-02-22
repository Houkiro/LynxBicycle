using AutoMapper;
using Contracts;
using Entities.Exeptions;
using LynxBicycle.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class ItemService : IItemService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ItemService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemDto>> GetAllItemsAsync(bool trackChanges)
        {

                var items = await _repository.Item.GetAllItemsAsync(trackChanges);

                var itemsDto = _mapper.Map<IEnumerable<ItemDto>>(items);

                return itemsDto;

        }

        public async Task<ItemDto> GetItemAsync(Guid itemID, bool trackChanges)
        {
            var item = await _repository.Item.GetItemAsync(itemID, trackChanges);
            if (item == null)
                throw new ItemNotFoundException(itemID);

            var itemDto = _mapper.Map<ItemDto>(item);

            return itemDto;
        }

        public async Task<IEnumerable<ItemDto>> GetAllItemsForBrendAsync(Guid brendID, bool trackChanges) 
        {
            var brend = await _repository.Brend.GetBrendAsync(brendID, trackChanges);
            if (brend is null)
                throw new BrendNotFoundException(brendID);

            var itemsFromDb = _repository.Item.GetAllItemsForBrendAsync(brendID, trackChanges);
            var itemsDto = _mapper.Map<IEnumerable<ItemDto>>(itemsFromDb);
            return itemsDto;

        }
        public async Task<IEnumerable<ItemDto>> GetAllItemsForTypeAsync(Guid typeID, bool trackChanges)
        {
            var type = await _repository.BicycleType.GetTypeAsync(typeID, trackChanges);
            if (type is null)
                throw new BrendNotFoundException(typeID);

            var itemsFromDb = await _repository.Item.GetAllItemsForTypeAsync(typeID, trackChanges);
            var itemsDto = _mapper.Map<IEnumerable<ItemDto>>(itemsFromDb);
            return itemsDto;
        }

        public async Task<ItemDto> CreateItemAsync(Guid brendID, Guid typeID, ItemForCreationDto itemForCreation, bool trackChanges)
        {
            var brend = await _repository.Brend.GetBrendAsync(brendID, trackChanges);
            if (brend is null)
                throw new BrendNotFoundException(brendID);
            var type = await _repository.BicycleType.GetTypeAsync(typeID, trackChanges);
            if(type is null)
                throw new BicycleTypeNotFoundException(typeID);

            var itemEntity = _mapper.Map<Item>(itemForCreation);

            _repository.Item.CreateItem(brendID, typeID, itemEntity);
            await _repository.SaveAsync();

            var itemToReturn = _mapper.Map<ItemDto>(itemEntity);

            return itemToReturn;
        }

        public async Task DeleteItemAsync(Guid itemID, bool trackChanges)
        {
            var item = await _repository.Item.GetItemAsync(itemID, trackChanges);
            if(item is null)
                throw new ItemNotFoundException(itemID);
            _repository.Item.DeleteItem(item);
            await _repository.SaveAsync();
        }
    }
}
