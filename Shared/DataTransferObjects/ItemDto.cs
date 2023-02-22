using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ItemDto(Guid ID, string Name, Guid BicycleTypeID, string Model, Guid BrendID);
}
