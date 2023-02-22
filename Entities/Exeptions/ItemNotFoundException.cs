using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exeptions
{
    public sealed class ItemNotFoundException : NotFoundException
    {
        public ItemNotFoundException(Guid itemID) : base($"The Item with ID: {itemID} doesnt`t exist in the database.") { }
    }
}
