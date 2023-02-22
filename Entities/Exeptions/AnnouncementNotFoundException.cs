using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exeptions
{
    public sealed class AnnouncementNotFoundException : NotFoundException
    {
        public AnnouncementNotFoundException(Guid announcementID) : base($"The AD with ID: {announcementID} doesnt`t exist in the database.") { }
    }
}
