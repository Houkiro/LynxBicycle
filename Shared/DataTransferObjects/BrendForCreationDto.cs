﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.CreateDto
{
    public record BrendForCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; init; }
    }

}
