using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryManager
    {
        IAnnouncementRepository Announcement { get; }
        IBrendRepository Brend { get; }
        IItemRepository Item { get; }
        IBicycleTypeRepository BicycleType { get; }

        void Save();
        Task SaveAsync();
    }
}
