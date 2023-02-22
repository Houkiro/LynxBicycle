using LynxBicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBrendRepository
    {
        Task<IEnumerable<Brend>> GetAllBrendsAsync(bool trackChanges);
        Task<Brend> GetBrendAsync(Guid ID, bool trackChanges);
        void CreateBrend(Brend brend);
        void DeleteBrend(Brend brend);
    }
}
