using LynxBicycle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> GetAllAnnouncementsAsync(bool trackChanges);
        Task<Announcement> GetAnnouncementAsync(string userId, Guid announcementID, bool trackChanges);
        Task<IEnumerable<Announcement>> GetAllAnnouncementsForUserAsync(string userId, bool trackChanges);
        void CreateAnnouncement(string userId, Guid itemID, Announcement announcement);
        void DeleteAnnouncement(Announcement announcement);
    }
}
