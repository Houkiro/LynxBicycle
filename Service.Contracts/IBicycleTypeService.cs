using LynxBicycle.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IBicycleTypeService
    {
        Task<IEnumerable<BicycleTypeDto>> GetAllTypesAsync(bool trackChanges);
        Task<BicycleTypeDto> GetTypeAsync(Guid typeID, bool trackChanges);
        Task<BicycleTypeDto> CreateTypeAsync(TypeForCreationDto type);
        Task DeleteTypeAsync(Guid typeID, bool trackChanges);
    }
}
