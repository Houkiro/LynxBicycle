using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exeptions
{
    public sealed class BrendNotFoundException : NotFoundException
    {
        public BrendNotFoundException(Guid brendID) : base($"The Brend with ID: {brendID} doesnt`t exist in the database.") { }
    }
}
