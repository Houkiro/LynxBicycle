using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxBicycle.Models
{
    public class Item
    {
        [Column("ItemID")]
        public Guid ID { get; set; }

        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(15, ErrorMessage = "Maximum lenght for the Name is 15 characters.")]
        public string? Name { get; set; }

        [ForeignKey(nameof(BicycleType))]
        public Guid BicycleTypeID { get; set; }

        public BicycleType? BicycleType { get; set; }

        public string? Model { get; set; }

        [ForeignKey(nameof(Brend))]
        public Guid BrendID { get; set; }

        public Brend? Brend { get; set; }
    }
}
