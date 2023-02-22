using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxBicycle.Models
{
    public class BicycleType
    {
        [Column("TypeID")]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(15, ErrorMessage = "Maximum lenght for the Name is 15 characters.")]
        public string? Name { get; set; }
    }
}
