using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetAllItemsAsync(bool trackChanges);
        Task<ItemDto> GetItemAsync(Guid itemID, bool trackChanges);
        Task<IEnumerable<ItemDto>> GetAllItemsForBrendAsync(Guid brendID, bool trackChanges);
        Task<IEnumerable<ItemDto>> GetAllItemsForTypeAsync(Guid typeID, bool trackChanges);
        Task<ItemDto> CreateItemAsync(Guid brendID, Guid typeID, ItemForCreationDto itemForCreation, bool trackChanges);
        Task DeleteItemAsync(Guid itemID, bool trackChanges);
    }
}
