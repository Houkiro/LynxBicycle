using LynxBicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllItemsAsync(bool trackChanges);
        Task<Item> GetItemAsync(Guid ID, bool trackChanges);
        Task<IEnumerable<Item>> GetAllItemsForBrendAsync(Guid brendID, bool trackChanges);
        Task<IEnumerable<Item>> GetAllItemsForTypeAsync(Guid typeID, bool trackChanges);
        void CreateItem(Guid brendID, Guid typeID, Item item);
        void DeleteItem(Item item);
    }
}
