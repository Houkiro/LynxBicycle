using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exeptions
{
    public sealed class BicycleTypeNotFoundException : NotFoundException
    {
        public BicycleTypeNotFoundException(Guid bicycleTypeID) : base($"The Type with ID: {bicycleTypeID} doesnt`t exist in the database.") { }
    }
}
