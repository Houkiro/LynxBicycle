using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IAnnouncementService AnnouncementService { get; }
        IBrendService BrendService { get; }
        IItemService ItemService { get; }
        IBicycleTypeService TypeService { get; }
        IAuthenticationService AuthenticationService { get; }

    }
}
