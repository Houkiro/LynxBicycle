using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public abstract record AnnouncementForManipulationDto
    {
        [Range(0, 100000, ErrorMessage = "Price must be greater than zero and less than one hundred thousand")]
        public uint Price { get; init; }
    }
}
