using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record AnnouncementForCreationDto : AnnouncementForManipulationDto
    {

        [Required(ErrorMessage = "Date is a required field")]
        public DateTime DateOfIssue { get; init; }

        [Required(ErrorMessage = "Price is a required field")]
        [Range(0, 100000, ErrorMessage = "Price must be greater than zero and less than one hundred thousand")]
        public uint Price { get; init; }
    }
}
