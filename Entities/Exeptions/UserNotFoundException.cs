using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exeptions
{
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string userId) : base($"The User with ID: {userId} doesnt`t exist in the database.") { }
    }
}
