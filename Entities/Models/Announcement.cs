using Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace LynxBicycle.Models
{
    public class Announcement
    {
        [Column("AnnouncementID")]
        public Guid ID { get; set; }

        public DateTime DateOfIssue { get; set; }

        public uint Price { get; set; }

        [ForeignKey(nameof(User))]
        public string? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey(nameof(Item))]
        public Guid ItemID { get; set; }

        public Item? Item { get; set; }
    }
}
