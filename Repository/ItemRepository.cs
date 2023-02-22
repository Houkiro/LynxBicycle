using Contracts;
using LynxBicycle.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<IEnumerable<Item>> GetAllItemsAsync(bool trackChanges) => await FindAll(trackChanges).OrderBy(i => i.Name).ToListAsync();
        public async Task<Item> GetItemAsync(Guid itemID, bool trackChanges) => await FindByCondition(i => i.ID.Equals(itemID), trackChanges).SingleOrDefaultAsync();
        public async Task<IEnumerable<Item>> GetAllItemsForBrendAsync(Guid brendID, bool trackChanges) => 
            await FindByCondition(i => i.BrendID.Equals(brendID), trackChanges)
            .OrderBy(i => i.Name).ToListAsync();
        public async Task<IEnumerable<Item>> GetAllItemsForTypeAsync(Guid typeID, bool trackChanges) => 
            await FindByCondition(i => i.BicycleTypeID.Equals(typeID), trackChanges)
            .OrderBy(i => i.Name).ToListAsync();
        public void CreateItem(Guid brendID, Guid typeID, Item item)
        {
            item.BrendID = brendID;
            item.BicycleTypeID = typeID;
            Create(item);
        }

        public void DeleteItem(Item item) => Delete(item);
    }
}
