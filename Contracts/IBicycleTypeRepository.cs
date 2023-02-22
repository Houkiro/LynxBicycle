using LynxBicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBicycleTypeRepository
    {
        Task<IEnumerable<BicycleType>> GetAllTypesAsync(bool trackChanges);
        Task<BicycleType> GetTypeAsync(Guid ID, bool trackChanges);
        void CreateType(BicycleType type);
        void DeleteType(BicycleType type);

    }
}
