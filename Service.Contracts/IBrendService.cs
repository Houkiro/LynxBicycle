using Shared.DataTransferObjects;
using Shared.DataTransferObjects.CreateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IBrendService
    {
        Task<IEnumerable<BrendDto>> GetAllBrendsAsync(bool trackChanges);
        Task<BrendDto> GetBrendAsync(Guid brendID, bool trackChanges);
        Task<BrendDto> CreateBrendAsync(BrendForCreationDto brend);
        Task DeleteBrendAsync(Guid brendID, bool trackChanges);
    }
}
