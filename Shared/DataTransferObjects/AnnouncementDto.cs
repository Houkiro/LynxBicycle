using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record AnnouncementDto(Guid ID, DateTime DateOfIssue, uint Price, string UserId, Guid ItemID);
}
