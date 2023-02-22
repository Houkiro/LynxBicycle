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
    public class BrendRepository : RepositoryBase<Brend>, IBrendRepository
    {
        public BrendRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<IEnumerable<Brend>> GetAllBrendsAsync(bool trackChanges) => await FindAll(trackChanges).OrderBy(b => b.Name).ToListAsync();
        public async Task<Brend> GetBrendAsync(Guid brendID, bool trackChanges) => await FindByCondition(b => b.ID.Equals(brendID), trackChanges).SingleOrDefaultAsync();
        public void CreateBrend(Brend brend) => Create(brend);

        public void DeleteBrend(Brend brend) => Delete(brend);
    }
}
