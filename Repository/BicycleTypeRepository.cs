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
    public class BicycleTypeRepository : RepositoryBase<BicycleType>, IBicycleTypeRepository
    {
        public BicycleTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<IEnumerable<BicycleType>> GetAllTypesAsync(bool trackChanges) => await FindAll(trackChanges).OrderBy(t => t.Name).ToListAsync();
        public async Task<BicycleType> GetTypeAsync(Guid typeID, bool trackChanges) => await FindByCondition(t => t.ID.Equals(typeID), trackChanges).SingleOrDefaultAsync();
        public void CreateType(BicycleType type) => Create(type);

        public void DeleteType(BicycleType type) => Delete(type);
    }
}
